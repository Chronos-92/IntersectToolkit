using Intersect_Library;
using Intersect_Library.GameObjects;
using Intersect_Library.GameObjects.Maps;
using IntersectToolkit.Database;
using SQLiteConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace IntersectToolkit {
    public partial class MainWindow : Form {

        private SQLiteConnection DBHandler;
        private Dictionary<String, Int64> Tilesets = new Dictionary<String, Int64>();
        private Dictionary<String, Int64> Maps = new Dictionary<String, Int64>();
        private Dictionary<String, Int64> Classes = new Dictionary<String, Int64>();
        private Dictionary<String, Int64> Items = new Dictionary<String, Int64>();
        private Int32[] CurVitals;
        private Int32[] MaxVitals;
        private Int32[] Stats;
        private Tuple<Int64, Int64>[] InvItems;
        private Int64[] EquipItems;

        public MainWindow() {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e) {
            LoadOptions();
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            // Save everything by neatly closing the Database.
            if (DBHandler != null) DBHandler.Close();
        }
        private void lnkDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=silvester@vanharberden.eu&lc=US&description=Intersect%20Toolkit&currency_code=USD&bn=PP%2dDonationsBF");

        }

        #region Options
        private void LoadOptions() {
            if (!File.Exists("config.xml")) {
                MessageBox.Show("Please copy config.xml from the Intersect server to the location this tool is run from.");
                this.Close();
            }
            var config = new XmlDocument(); config.LoadXml(File.ReadAllText("config.xml"));
            Options.MapWidth = Int32.Parse(config["Config"]["Map"]["MapWidth"].InnerXml);
            Options.MapHeight = Int32.Parse(config["Config"]["Map"]["MapHeight"].InnerXml);
            Options.MaxStatValue = Int32.Parse(config["Config"]["Player"]["MaxStat"].InnerXml);
            Options.MaxLevel = Int32.Parse(config["Config"]["Player"]["MaxLevel"].InnerXml);
            Options.MaxInvItems = Int32.Parse(config["Config"]["Player"]["MaxInventory"].InnerXml);
            foreach (var x in Enumerable.Range(1, Options.MaxInvItems)) { accInvSlot.Items.Add(String.Format("{0}.", x)); }
            foreach (XmlElement e in config["Config"]["Equipment"]) { if (e.Name.StartsWith("Slot")) { accEquipSlot.Items.Add(e.InnerXml); } }
        }
        #endregion

        #region Database
        #region Refresh
        private void RefreshDB() {
            RefreshMaps();
            RefreshClasses();
            RefreshItems();
            RefreshAccounts();
            RefreshInventory();
            RefreshTilesets();
        }
        private void RefreshAccounts() {
            lstAccounts.Items.Clear();
            foreach (var u in DBHandler.ExecuteQuery<Users>("SELECT * FROM users;")) {
                lstAccounts.Items.Add(String.Format("{0}", u.user));
            }
            lstAccounts.SelectedIndex = 1; lstAccounts.SelectedIndex = 0;
        }
        private void RefreshTilesets() {
            lstTilesets.Items.Clear();
            Tilesets.Clear();
            foreach (var t in DBHandler.ExecuteQuery<Tilesets>("SELECT * FROM tilesets;")) {
                lstTilesets.Items.Add(String.Format("{1}", t.id, Encoding.Default.GetString(t.data)));
                Tilesets.Add(Encoding.Default.GetString(t.data), t.id);
            }
            if (lstTilesets.Items.Count > 0) lstTilesets.SelectedIndex = 0;
        }
        private void RefreshMaps() {
            Maps.Clear();
            accCharMap.Items.Clear();
            foreach (var m in DBHandler.ExecuteQuery<BlobObject>("SELECT * FROM maps WHERE deleted=0")) {
                var x = new MapBase((Int32)m.id, true);
                x.Load(m.data);
                Maps.Add(x.MyName, m.id);
                accCharMap.Items.Add(x.MyName);
            }
        }
        private void RefreshClasses() {
            Classes.Clear();
            accCharClass.Items.Clear();
            foreach (var c in DBHandler.ExecuteQuery<BlobObject>("SELECT * FROM classes WHERE deleted=0")) {
                var x = new ClassBase((Int32)c.id);
                x.Load(c.data);
                Classes.Add(x.Name, c.id);
                accCharClass.Items.Add(x.Name);
            }
        }
        private void RefreshItems() {
            Items.Clear();
            Items.Add("None", -1);
            accInvItem.Items.Add("None");
            foreach (var i in DBHandler.ExecuteQuery<BlobObject>("SELECT * FROM items WHERE deleted=0")) {
                var x = new ItemBase((Int32)i.id);
                x.Load(i.data);
                Items.Add(x.Name, i.id);
                accInvItem.Items.Add(x.Name);
            }
        }
        private void RefreshInventory() {
            var slot = accInvSlot.SelectedIndex == -1 ? 0 : accInvSlot.SelectedIndex;
            accInvSlot.Items.Clear();
            var t = new List<Tuple<Int64, Int64>>();
            foreach(var s in DBHandler.ExecuteQuery<Inventory>("SELECT * FROM char_inventory WHERE char_id=@charid", new Dictionary<String, Object>() { { "@charid", accCharId.Text } })) {
                t.Add(new Tuple<Int64, Int64>(s.itemnum, s.itemval));
                accInvSlot.Items.Add(String.Format("{0}. {1} x {2}", s.slot + 1, s.itemval, Items.Where(i => i.Value == s.itemnum).Select(i => i.Key).SingleOrDefault()));
            }
            InvItems = t.ToArray();
            if (accInvSlot.Items.Count> 0) {
                accInvSlot.SelectedIndex = 1; accInvSlot.SelectedIndex = 0;
                accInvSlot.SelectedIndex = slot;
            }
        }
        private void RefreshInventoryList() {
            var slot = accInvSlot.SelectedIndex == -1 ? 0 : accInvSlot.SelectedIndex;
            var slot2 = accEquipItem.SelectedIndex == -1 ? 0 : accEquipItem.SelectedIndex;
            var slot3 = accEquipSlot.SelectedIndex == -1 ? 0 : accEquipSlot.SelectedIndex;
            accInvSlot.SelectedIndexChanged -= accInvSlot_SelectedIndexChanged;
            accInvSlot.Items.Clear();
            accEquipItem.Items.Clear();
            accEquipItem.Items.Add("None");
            var t = new List<Tuple<Int64, Int64>>();
            var sl = 1;
            foreach (var s in InvItems) {
                accInvSlot.Items.Add(String.Format("{0}. {1} x {2}", sl , s.Item2, Items.Where(i => i.Value == s.Item1).Select(i => i.Key).Single()));
                accEquipItem.Items.Add(Items.Where(i => i.Value == s.Item1).Select(i => i.Key).Single());
                sl++;
            }
            accInvSlot.SelectedIndex = slot;
            accEquipItem.SelectedIndex = slot2;
            accEquipSlot.SelectedIndex = slot3;
            accInvSlot.SelectedIndexChanged += accInvSlot_SelectedIndexChanged;
        }
        #endregion

        #region Browse
        private void btnBrowse_Click(object sender, EventArgs e) {
            using (var d = new OpenFileDialog()) {
                d.Filter = "Intersect Database|*.db";
                var r = d.ShowDialog();
                if (r == DialogResult.OK) {
                    dbfile.Text = d.FileName;
                }
            }

            if (File.Exists(dbfile.Text)) {
                DBHandler = new SQLiteConnection(dbfile.Text);
                DBHandler.Open();
                RefreshDB();
                tdatabase.Enabled = true;
            }
        }
        #endregion

        #region Accounts
        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstAccounts.SelectedItem == null) return;

            ClearAllControls(this);

            // Account info
            var user = DBHandler.ExecuteQuery<Users>("SELECT * FROM users WHERE user=@user;", new Dictionary<String, Object>() { { "@user", lstAccounts.SelectedItem } }).Single();
            accUserId.Text = user.id.ToString();
            accUserName.Text = user.user;
            accUserEmail.Text = user.email;
            accUserAccess.SelectedIndex = (int)user.power;
            accUserPassword.Text = user.pass;
            accUserSalt.Text = user.salt;

            // Character info
            accCharBox.Enabled = false;
            var character = DBHandler.ExecuteQuery<Characters>("SELECT * FROM characters WHERE user_id=@user", new Dictionary<String, Object>() { { "@user", user.id } });
            if (character.Length > 0) {
                accCharBox.Enabled = true;
                var chara = character.Single();
                accCharId.Text = chara.id.ToString();
                accCharName.Text = chara.name;
                accCharMap.SelectedItem = Maps.Where(x => x.Value == chara.map).Select(x => x.Key).SingleOrDefault();
                accCharX.Text = chara.x.ToString();
                accCharY.Text = chara.y.ToString();
                accCharZ.SelectedIndex = (Int32)chara.z;
                accCharDirection.SelectedIndex = (Int32)chara.dir;
                accCharSprite.Text = chara.sprite;
                accCharFace.Text = chara.face;
                accCharClass.SelectedItem = Classes.Where(x => x.Value == chara.@class).Select(x => x.Key).SingleOrDefault();
                accCharGender.SelectedIndex = (Int32)chara.gender;
                accCharLevel.Text = chara.level.ToString();
                accCharExp.Text = chara.exp.ToString();
                accCharStatpoints.Text = chara.statpoints.ToString();

                EquipItems = chara.equipment.Split(',').Select(i=>i.ToInt64()).ToArray();

                // Max before current, as we change current to max if current is higher.
                MaxVitals = chara.maxvitals.Split(',').Select(x => x.ToInt32()).ToArray();
                CurVitals = chara.vitals.Split(',').Select(x => x.ToInt32()).ToArray();
                accCharMaxVital.SelectedIndex = 1; accCharMaxVital.SelectedIndex = 0;       // HACK: Make sure it always updates.
                accCharCurVital.SelectedIndex = 1; accCharCurVital.SelectedIndex = 0;

                Stats = chara.stats.Split(',').Select(x => x.ToInt32()).ToArray();
                accCharStat.SelectedIndex = 1; accCharStat.SelectedIndex = 0;

                RefreshInventory();
            }
        }
        private void accUserSaveChanges_Click(object sender, EventArgs e) {
            using (var tran = DBHandler.BeginTransaction()) {
                try {
                    DBHandler.ExecuteNonQuery("UPDATE users SET user=@user, email=@email, power=@power WHERE id=@id;", new Dictionary<String, Object>() { { "@user", accUserName.Text.Trim() }, { "@email", accUserEmail.Text.Trim() }, { "@power", accUserAccess.SelectedIndex }, { "@id", accUserId.Text.Trim() } }, tran);
                    DBHandler.ExecuteNonQuery("UPDATE characters SET name=@name, map=@map, x=@x, y=@y, z=@z, dir=@dir, sprite=@sprite, face=@face, class=@class, gender=@gender, level=@level, exp=@exp, statpoints=@statpoints, vitals=@vitals, maxvitals=@maxvitals, stats=@stats, equipment=@equipment WHERE id=@id;",
                        new Dictionary<String, Object>() { { "@name", accCharName.Text.Trim() }, { "@map", Maps[(String)accCharMap.SelectedItem] }, { "@x", accCharX.Text.Trim() }, { "@y", accCharY.Text.Trim() }, { "@z", accCharZ.SelectedIndex }, { "@dir", accCharDirection.SelectedIndex }, { "@sprite", accCharSprite.Text.Trim() }, { "@face", accCharFace.Text.Trim() },
                    { "@class", Classes[(String)accCharClass.SelectedItem] }, { "@gender", accCharGender.SelectedIndex }, { "@level", accCharLevel.Text.Trim() }, { "@exp", accCharExp.Text.Trim() }, { "@statpoints", accCharStatpoints.Text.Trim() }, { "@id", accCharId.Text.Trim() }, { "@vitals", String.Join(",", CurVitals.Select(x=>x.ToString())) },
                    { "@maxvitals", String.Join(",", MaxVitals.Select(x=>x.ToString())) }, { "@stats", String.Join(",", Stats.Select(x=>x.ToString())) }, { "@equipment", String.Join(",", EquipItems.Select(x=>x.ToString())) }}, tran);
                    var slot = 0;
                    foreach (var i in InvItems) {
                        DBHandler.ExecuteNonQuery("UPDATE char_inventory SET itemnum=@itemnum, itemval=@itemval WHERE char_id=@charid AND slot=@slot", new Dictionary<String, Object>() { { "@itemnum", i.Item1 }, { "@itemval", i.Item2 }, { "@charid", accCharId.Text }, { "@slot", slot } }, tran);
                        slot++;
                    }
                    tran.Commit();
                } catch (Exception ex) {
                    tran.Rollback();
                    throw ex;
                }
            }
        }
        private void accCharMaxVital_SelectedIndexChanged(object sender, EventArgs e) {
            if (MaxVitals == null | accCharMaxVital.SelectedIndex < 0) return;
            accCharMaxVitalValue.Text = MaxVitals[accCharMaxVital.SelectedIndex].ToString();
        }
        private void accCharMaxVitalValue_TextChanged(object sender, EventArgs e) {
            MaxVitals[accCharMaxVital.SelectedIndex] = accCharMaxVitalValue.Text.ToInt32();
        }
        private void accCharCurVital_SelectedIndexChanged(object sender, EventArgs e) {
            if (CurVitals == null | accCharCurVital.SelectedIndex < 0) return;
            accCharCurVitalValue.Text = CurVitals[accCharCurVital.SelectedIndex].ToString();
        }
        private void accCharCurVitalValue_TextChanged(object sender, EventArgs e) {
            if (accCharCurVitalValue.Text.ToInt32() > accCharMaxVitalValue.Text.ToInt32()) {
                accCharCurVitalValue.Text = accCharMaxVitalValue.Text;
            }
            CurVitals[accCharCurVital.SelectedIndex] = accCharCurVitalValue.Text.ToInt32();
        }
        private void accCharLevel_TextChanged(object sender, EventArgs e) {
            if (accCharLevel.Text.ToInt32() > Options.MaxLevel) accCharLevel.Text = Options.MaxLevel.ToString();
        }
        private void accCharStatValue_TextChanged(object sender, EventArgs e) {
            if (accCharStatValue.Text.ToInt32() > Options.MaxStatValue) accCharStatValue.Text = Options.MaxStatValue.ToString();
            Stats[accCharStat.SelectedIndex] = accCharStatValue.Text.ToInt32();
        }
        private void accCharStat_SelectedIndexChanged(object sender, EventArgs e) {
            if (Stats == null | accCharStat.SelectedIndex < 0) return;
            accCharStatValue.Text = Stats[accCharStat.SelectedIndex].ToString();
        }
        private void accInvSlot_SelectedIndexChanged(object sender, EventArgs e) {
            var item = (Int32)InvItems[accInvSlot.SelectedIndex].Item1;
            item = item > 0 ? item : -1;
            accInvItem.SelectedItem = Items.Where(x => x.Value == item).Select(x => x.Key).Single();
            accInvValue.Text = InvItems[accInvSlot.SelectedIndex].Item2.ToString();
        }
        private void accInvItem_SelectedIndexChanged(object sender, EventArgs e) {
            if (accInvItem.SelectedIndex < 0) return;
            var slot = accInvSlot.SelectedIndex;
            var item = Items[(String)accInvItem.SelectedItem];
            InvItems[slot] = new Tuple<Int64, Int64>(item, InvItems[slot].Item2);
            RefreshInventoryList();
        }
        private void accInvValue_TextChanged(object sender, EventArgs e) {
            var val = accInvValue.Text.ToInt32();
            var slot = accInvSlot.SelectedIndex;
            InvItems[slot] = new Tuple<Int64, Int64>(InvItems[slot].Item1, val);
            accInvValue.Text = val.ToString();
            RefreshInventoryList();
        }
        private void accEquipItem_SelectedIndexChanged(object sender, EventArgs e) {
            if (accEquipSlot.SelectedIndex < 0) return;
            EquipItems[accEquipSlot.SelectedIndex] = accEquipItem.SelectedIndex - 1;
        }
        private void accEquipSlot_SelectedIndexChanged(object sender, EventArgs e) {
            if (EquipItems == null | InvItems == null | accEquipSlot.SelectedIndex < 0) return;
            var invslot = EquipItems[accEquipSlot.SelectedIndex];
            accEquipItem.SelectedItem = invslot < 0 ? "None" : Items.Where(x => x.Value == InvItems[invslot].Item1).Select(x => x.Key).Single();
        }
        private void accDelAccount_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Deleting this account can not be reverted, are you sure you want to continue?", "Delete Account", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                var tran = DBHandler.BeginTransaction();
                try {
                    DBHandler.ExecuteNonQuery(@"
                        DELETE FROM users WHERE id=@id;
                        DELETE FROM bans WHERE id=@id;
                        DELETE FROM mutes WHERE id=@id;
                    ", new Dictionary<String, Object>() { { "@id", accUserId.Text } }, tran);
                    if (accCharId.Text.Length > 0) DBHandler.ExecuteNonQuery(@"
                        DELETE FROM characters WHERE id=@id;
                        DELETE FROM char_bank WHERE char_id=@id;
                        DELETE FROM char_hotbar WHERE char_id=@id;
                        DELETE FROM char_inventory WHERE char_id=@id;
                        DELETE FROM char_quests WHERE char_id=@id;
                        DELETE FROM char_spells WHERE char_id=@id;
                        DELETE FROM char_switches WHERE char_id=@id;
                        DELETE FROM char_variables WHERE char_id=@id;
                    ", new Dictionary<String, Object>() { { "@id", accCharId.Text } }, tran);
                    tran.Commit();
                } catch (Exception ex) {
                    tran.Rollback();
                    throw ex;
                }
                RefreshAccounts();
            }
        }
        private void accDelCharacter_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Deleting this character can not be reverted, are you sure you want to continue?", "Delete Character", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                var tran = DBHandler.BeginTransaction();
                try {
                    if (accCharId.Text.Length > 0) DBHandler.ExecuteNonQuery(@"
                        DELETE FROM characters WHERE id=@id;
                        DELETE FROM char_bank WHERE char_id=@id;
                        DELETE FROM char_hotbar WHERE char_id=@id;
                        DELETE FROM char_inventory WHERE char_id=@id;
                        DELETE FROM char_quests WHERE char_id=@id;
                        DELETE FROM char_spells WHERE char_id=@id;
                        DELETE FROM char_switches WHERE char_id=@id;
                        DELETE FROM char_variables WHERE char_id=@id;
                    ", new Dictionary<String, Object>() { { "@id", accCharId.Text } }, tran);
                    tran.Commit();
                } catch (Exception ex) {
                    tran.Rollback();
                    throw ex;
                }
                RefreshAccounts();
            }
        }
        #endregion

        #region Tilesets
        private void lstTilesets_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstTilesets.SelectedItem == null) return;

            var tileset = DBHandler.ExecuteQuery<Tilesets>("SELECT * FROM tilesets WHERE id=@id;", new Dictionary<String, Object>() { { "@id", Tilesets[(String)lstTilesets.SelectedItem] } }).Single();
            tilTilesetId.Text = tileset.id.ToString();
            tilTilesetFilename.Text = (String)lstTilesets.SelectedItem;
            tilTilesetDeleted.SelectedIndex = (Int32)tileset.deleted;
        }
        private void tilSaveChanges_Click(object sender, EventArgs e) {
            DBHandler.ExecuteNonQuery("UPDATE tilesets SET deleted=@deleted, data=@data WHERE id=@id;", new Dictionary<String, Object>() { { "@deleted", tilTilesetDeleted.SelectedIndex }, { "@data", tilTilesetFilename.Text }, { "@id", tilTilesetId.Text } });
            RefreshTilesets();
        }
        #endregion
        #endregion

        #region Graphics
        #region VX To Intersect
        private void vxinBtnInput_Click(object sender, EventArgs e) {
            var d = new FolderBrowserDialog();
            var s = d.ShowDialog();
            if (s == DialogResult.OK) {
                vxinInput.Text = d.SelectedPath;
            }
        }
        private void vxinBtnOutput_Click(object sender, EventArgs e) {
            var d = new FolderBrowserDialog();
            var s = d.ShowDialog();
            if (s == DialogResult.OK) {
                vxinOutput.Text = d.SelectedPath;
            }
        }
        private void vxBtnGo_Click(object sender, EventArgs e) {
            if (!Directory.Exists(vxinInput.Text) || !Directory.Exists(vxinOutput.Text)) {
                MessageBox.Show("Both the Input and Output folders need to be set to an existing folder!");
            } else {
                TabsMain.Enabled = false;
                vxinOutputDisplay.Items.Clear();

                var w = new BackgroundWorker();
                w.DoWork += (s, a) => {
                    var args = (String[])a.Argument;
                    var input = args[0];
                    var output = args[1];

                    foreach (var file in new DirectoryInfo(input).EnumerateFiles("*.png")) {
                        using (var tmp = Image.FromFile(file.FullName)) {
                            var width = tmp.Width / 3;
                            var height = tmp.Height / 4;

                            using (var newimage = new Bitmap(width * 4, height * 4, PixelFormat.Format32bppArgb)) {
                                using (var g = Graphics.FromImage(newimage)) {
                                    g.Clear(System.Drawing.Color.Transparent);
                                    g.DrawImage(tmp, new Rectangle(0, 0, width, height * 4), new Rectangle(width, 0, width, height * 4), GraphicsUnit.Pixel);
                                    g.DrawImage(tmp, new Rectangle(width, 0, width * 3, height * 4), new Rectangle(0, 0, width * 3, height * 4), GraphicsUnit.Pixel);
                                    g.Flush();
                                }
                                this.Invoke(new Action(() => {
                                    newimage.Save(Path.Combine(output, file.Name), ImageFormat.Png);
                                    vxinOutputDisplay.Items.Add(String.Format("Processed {0}.", file.Name));
                                    vxinOutputDisplay.TopIndex = vxinOutputDisplay.Items.Count - 1;
                                }));
                            }
                        }
                    }
                };
                w.RunWorkerCompleted += (s, a) => { this.Invoke(new Action(() => { MessageBox.Show("Task complete!"); TabsMain.Enabled = true; })); };
                w.RunWorkerAsync(new String[] { vxinInput.Text, vxinOutput.Text });
            }
        }
        #endregion

        #region Resize Graphics
        private void resizeInputBrowse_Click(object sender, EventArgs e) {
            var d = new FolderBrowserDialog();
            var s = d.ShowDialog();
            if (s == DialogResult.OK) {
                resizeInput.Text = d.SelectedPath;
            }
        }
        private void resizeOutputBrowse_Click(object sender, EventArgs e) {
            var d = new FolderBrowserDialog();
            var s = d.ShowDialog();
            if (s == DialogResult.OK) {
                resizeOutput.Text = d.SelectedPath;
            }
        }
        private void resizeBtnGo_Click(object sender, EventArgs e) {
            Double modifier;
            if (!Double.TryParse(resizeModifier.Text, out modifier)) {
                MessageBox.Show("Please enter a valid amount by which to resize the image!");
                return;
            }
            if (!Directory.Exists(resizeInput.Text) || !Directory.Exists(resizeOutput.Text)) {
                MessageBox.Show("Both the Input and Output folders need to be set to an existing folder!");
            } else {
                TabsMain.Enabled = false;
                resizeList.Items.Clear();

                var w = new BackgroundWorker();
                w.DoWork += (s, a) => {
                    var args = (String[])a.Argument;
                    var input = args[0];
                    var output = args[1];

                    foreach (var file in new DirectoryInfo(input).EnumerateFiles("*.png")) {
                        using (var tmp = Image.FromFile(file.FullName)) {

                            using (var newimage = new Bitmap((Int32)(tmp.Width * modifier), (Int32)(tmp.Height * modifier), PixelFormat.Format32bppArgb)) {
                                using (var g = Graphics.FromImage(newimage)) {
                                    g.InterpolationMode = InterpolationMode.NearestNeighbor;
                                    g.CompositingMode = CompositingMode.SourceCopy;
                                    g.CompositingQuality = CompositingQuality.HighQuality;
                                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                                    g.Clear(System.Drawing.Color.Transparent);
                                    g.DrawImage(tmp, new Rectangle(0, 0, newimage.Width, newimage.Height), new Rectangle(0, 0, tmp.Width, tmp.Height), GraphicsUnit.Pixel);
                                    g.Flush();
                                }
                                this.Invoke(new Action(() => {
                                    newimage.Save(Path.Combine(output, file.Name), ImageFormat.Png);
                                    resizeList.Items.Add(String.Format("Processed {0}.", file.Name));
                                    resizeList.TopIndex = vxinOutputDisplay.Items.Count - 1;
                                }));
                            }
                        }
                    }
                };
                w.RunWorkerCompleted += (s, a) => { this.Invoke(new Action(() => { MessageBox.Show("Task complete!"); TabsMain.Enabled = true; })); };
                w.RunWorkerAsync(new String[] { resizeInput.Text, resizeOutput.Text });
            }
        }






        #endregion

        #endregion

        void ClearAllControls(Control con) {
            foreach (var c in con.Controls) {
                if (c is TextBox) {
                    ((TextBox)c).Clear();
                } else if (c is ComboBox) {
                    ((ComboBox)c).SelectedIndex = -1;
                } else {
                    ClearAllControls((Control)c);
                }
            }
        }

    }
}
