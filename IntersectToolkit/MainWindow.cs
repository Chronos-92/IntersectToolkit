using Intersect_Library;
using Intersect_Library.GameObjects;
using Intersect_Library.GameObjects.Maps;
using IntersectToolkit.Database;
using SQLiteConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public MainWindow() {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e) {
            LoadOptions();
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
        }
        #endregion

        #region Database
        #region Refresh
        private void RefreshDB() {
            RefreshMaps();
            RefreshClasses();
            RefreshAccounts();
            RefreshTilesets();
        }
        private void RefreshAccounts() {
            lstAccounts.Items.Clear();
            foreach (var u in DBHandler.ExecuteQuery<Users>("SELECT * FROM users;")) {
                lstAccounts.Items.Add(String.Format("{0}", u.user));
            }
            if (lstAccounts.Items.Count > 0) lstAccounts.SelectedIndex = 0;
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
            foreach (var m in DBHandler.ExecuteQuery<Maps>("SELECT * FROM maps WHERE deleted=0")) {
                var x = new MapBase((Int32)m.id, true);
                x.Load(m.data);
                Maps.Add(x.MyName, m.id);
                accCharMap.Items.Add(x.MyName);
            }
        }
        private void RefreshClasses() {
            Classes.Clear();
            accCharClass.Items.Clear();
            foreach (var c in DBHandler.ExecuteQuery<Maps>("SELECT * FROM classes WHERE deleted=0")) {
                var x = new ClassBase((Int32)c.id);
                x.Load(c.data);
                Classes.Add(x.Name, c.id);
                accCharClass.Items.Add(x.Name);
            }
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
            }
        }
        private void accUserSaveChanges_Click(object sender, EventArgs e) {
            DBHandler.ExecuteNonQuery("UPDATE users SET user=@user, email=@email, power=@power WHERE id=@id;", new Dictionary<String, Object>() { { "@user", accUserName.Text.Trim() }, { "@email", accUserEmail.Text.Trim() }, { "@power", accUserAccess.SelectedIndex }, { "@id", accUserId.Text.Trim() } });
            DBHandler.ExecuteNonQuery("UPDATE characters SET name=@name, map=@map, x=@x, y=@y, z=@z, dir=@dir, sprite=@sprite, face=@face, class=@class, gender=@gender, level=@level, exp=@exp, statpoints=@statpoints WHERE id=@id;",
                new Dictionary<String, Object>() { { "@name", accCharName.Text.Trim() }, { "@map", Maps[(String)accCharMap.SelectedItem] }, { "@x", accCharX.Text.Trim() }, { "@y", accCharY.Text.Trim() }, { "@z", accCharZ.SelectedIndex }, { "@dir", accCharDirection.SelectedIndex }, { "@sprite", accCharSprite.Text.Trim() }, { "@face", accCharFace.Text.Trim() },
                    { "@class", Classes[(String)accCharClass.SelectedItem] }, { "@gender", accCharGender.SelectedIndex }, { "@level", accCharLevel.Text.Trim() }, { "@exp", accCharExp.Text.Trim() }, { "@statpoints", accCharStatpoints.Text.Trim() }, { "@id", accCharId.Text.Trim() } });
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


    }
}
