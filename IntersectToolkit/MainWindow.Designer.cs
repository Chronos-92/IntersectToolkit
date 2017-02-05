namespace IntersectToolkit {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TabsMain = new System.Windows.Forms.TabControl();
            this.tabdatabase = new System.Windows.Forms.TabPage();
            this.tdatabase = new System.Windows.Forms.TabControl();
            this.tabaccounts = new System.Windows.Forms.TabPage();
            this.accCharBox = new System.Windows.Forms.GroupBox();
            this.accCharGender = new System.Windows.Forms.ComboBox();
            this.accCharStatpoints = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.accCharExp = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.accCharLevel = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.accCharFace = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.accCharSprite = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.accCharZ = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.accCharDirection = new System.Windows.Forms.ComboBox();
            this.accCharY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.accCharX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.accCharName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.accCharId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.accUserSaveChanges = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.accUserSalt = new System.Windows.Forms.TextBox();
            this.accUserPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.accUserAccess = new System.Windows.Forms.ComboBox();
            this.accUserEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.accUserName = new System.Windows.Forms.TextBox();
            this.accUserId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAccounts = new System.Windows.Forms.ListBox();
            this.tabTilesets = new System.Windows.Forms.TabPage();
            this.tilSaveChanges = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tilTilesetDeleted = new System.Windows.Forms.ComboBox();
            this.tilTilesetFilename = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tilTilesetId = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lstTilesets = new System.Windows.Forms.ListBox();
            this.dbfile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tabgraphics = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.vxinOutputDisplay = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.vxinOutput = new System.Windows.Forms.TextBox();
            this.vxinBtnOutput = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.vxinInput = new System.Windows.Forms.TextBox();
            this.vxinBtnInput = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.accCharMap = new System.Windows.Forms.ComboBox();
            this.accCharClass = new System.Windows.Forms.ComboBox();
            this.TabsMain.SuspendLayout();
            this.tabdatabase.SuspendLayout();
            this.tdatabase.SuspendLayout();
            this.tabaccounts.SuspendLayout();
            this.accCharBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabTilesets.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabgraphics.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabsMain
            // 
            this.TabsMain.Controls.Add(this.tabdatabase);
            this.TabsMain.Controls.Add(this.tabgraphics);
            this.TabsMain.Location = new System.Drawing.Point(12, 12);
            this.TabsMain.Name = "TabsMain";
            this.TabsMain.SelectedIndex = 0;
            this.TabsMain.Size = new System.Drawing.Size(760, 532);
            this.TabsMain.TabIndex = 0;
            // 
            // tabdatabase
            // 
            this.tabdatabase.Controls.Add(this.tdatabase);
            this.tabdatabase.Controls.Add(this.dbfile);
            this.tabdatabase.Controls.Add(this.btnBrowse);
            this.tabdatabase.Location = new System.Drawing.Point(4, 22);
            this.tabdatabase.Name = "tabdatabase";
            this.tabdatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabdatabase.Size = new System.Drawing.Size(752, 506);
            this.tabdatabase.TabIndex = 0;
            this.tabdatabase.Text = "Database";
            this.tabdatabase.UseVisualStyleBackColor = true;
            // 
            // tdatabase
            // 
            this.tdatabase.Controls.Add(this.tabaccounts);
            this.tdatabase.Controls.Add(this.tabTilesets);
            this.tdatabase.Enabled = false;
            this.tdatabase.Location = new System.Drawing.Point(6, 34);
            this.tdatabase.Name = "tdatabase";
            this.tdatabase.SelectedIndex = 0;
            this.tdatabase.Size = new System.Drawing.Size(740, 466);
            this.tdatabase.TabIndex = 2;
            // 
            // tabaccounts
            // 
            this.tabaccounts.Controls.Add(this.accCharBox);
            this.tabaccounts.Controls.Add(this.accUserSaveChanges);
            this.tabaccounts.Controls.Add(this.groupBox2);
            this.tabaccounts.Controls.Add(this.groupBox1);
            this.tabaccounts.Controls.Add(this.lstAccounts);
            this.tabaccounts.Location = new System.Drawing.Point(4, 22);
            this.tabaccounts.Name = "tabaccounts";
            this.tabaccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabaccounts.Size = new System.Drawing.Size(732, 440);
            this.tabaccounts.TabIndex = 0;
            this.tabaccounts.Text = "Accounts";
            this.tabaccounts.UseVisualStyleBackColor = true;
            // 
            // accCharBox
            // 
            this.accCharBox.Controls.Add(this.accCharClass);
            this.accCharBox.Controls.Add(this.accCharMap);
            this.accCharBox.Controls.Add(this.accCharGender);
            this.accCharBox.Controls.Add(this.accCharStatpoints);
            this.accCharBox.Controls.Add(this.label20);
            this.accCharBox.Controls.Add(this.accCharExp);
            this.accCharBox.Controls.Add(this.label19);
            this.accCharBox.Controls.Add(this.accCharLevel);
            this.accCharBox.Controls.Add(this.label18);
            this.accCharBox.Controls.Add(this.label17);
            this.accCharBox.Controls.Add(this.label16);
            this.accCharBox.Controls.Add(this.accCharFace);
            this.accCharBox.Controls.Add(this.label15);
            this.accCharBox.Controls.Add(this.accCharSprite);
            this.accCharBox.Controls.Add(this.label14);
            this.accCharBox.Controls.Add(this.label13);
            this.accCharBox.Controls.Add(this.accCharZ);
            this.accCharBox.Controls.Add(this.label12);
            this.accCharBox.Controls.Add(this.accCharDirection);
            this.accCharBox.Controls.Add(this.accCharY);
            this.accCharBox.Controls.Add(this.label11);
            this.accCharBox.Controls.Add(this.accCharX);
            this.accCharBox.Controls.Add(this.label10);
            this.accCharBox.Controls.Add(this.label9);
            this.accCharBox.Controls.Add(this.accCharName);
            this.accCharBox.Controls.Add(this.label8);
            this.accCharBox.Controls.Add(this.accCharId);
            this.accCharBox.Controls.Add(this.label7);
            this.accCharBox.Location = new System.Drawing.Point(132, 144);
            this.accCharBox.Name = "accCharBox";
            this.accCharBox.Size = new System.Drawing.Size(594, 261);
            this.accCharBox.TabIndex = 4;
            this.accCharBox.TabStop = false;
            this.accCharBox.Text = "Character";
            // 
            // accCharGender
            // 
            this.accCharGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accCharGender.FormattingEnabled = true;
            this.accCharGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.accCharGender.Location = new System.Drawing.Point(426, 48);
            this.accCharGender.Name = "accCharGender";
            this.accCharGender.Size = new System.Drawing.Size(162, 21);
            this.accCharGender.TabIndex = 33;
            // 
            // accCharStatpoints
            // 
            this.accCharStatpoints.Location = new System.Drawing.Point(426, 127);
            this.accCharStatpoints.Name = "accCharStatpoints";
            this.accCharStatpoints.Size = new System.Drawing.Size(162, 20);
            this.accCharStatpoints.TabIndex = 32;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(324, 130);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "Statpoints:";
            // 
            // accCharExp
            // 
            this.accCharExp.Location = new System.Drawing.Point(426, 101);
            this.accCharExp.Name = "accCharExp";
            this.accCharExp.Size = new System.Drawing.Size(162, 20);
            this.accCharExp.TabIndex = 30;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(324, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Exp:";
            // 
            // accCharLevel
            // 
            this.accCharLevel.Location = new System.Drawing.Point(426, 74);
            this.accCharLevel.Name = "accCharLevel";
            this.accCharLevel.Size = new System.Drawing.Size(162, 20);
            this.accCharLevel.TabIndex = 28;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(324, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 13);
            this.label18.TabIndex = 27;
            this.label18.Text = "Level:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(324, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Gender:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(324, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Class:";
            // 
            // accCharFace
            // 
            this.accCharFace.Location = new System.Drawing.Point(108, 230);
            this.accCharFace.Name = "accCharFace";
            this.accCharFace.Size = new System.Drawing.Size(162, 20);
            this.accCharFace.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 233);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Face:";
            // 
            // accCharSprite
            // 
            this.accCharSprite.Location = new System.Drawing.Point(108, 204);
            this.accCharSprite.Name = "accCharSprite";
            this.accCharSprite.Size = new System.Drawing.Size(162, 20);
            this.accCharSprite.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 207);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Sprite:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Z:";
            // 
            // accCharZ
            // 
            this.accCharZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accCharZ.FormattingEnabled = true;
            this.accCharZ.Items.AddRange(new object[] {
            "Lower",
            "Upper"});
            this.accCharZ.Location = new System.Drawing.Point(108, 150);
            this.accCharZ.Name = "accCharZ";
            this.accCharZ.Size = new System.Drawing.Size(162, 21);
            this.accCharZ.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Direction:";
            // 
            // accCharDirection
            // 
            this.accCharDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accCharDirection.FormattingEnabled = true;
            this.accCharDirection.Items.AddRange(new object[] {
            "Up",
            "Down",
            "Left",
            "Right"});
            this.accCharDirection.Location = new System.Drawing.Point(108, 177);
            this.accCharDirection.Name = "accCharDirection";
            this.accCharDirection.Size = new System.Drawing.Size(162, 21);
            this.accCharDirection.TabIndex = 14;
            // 
            // accCharY
            // 
            this.accCharY.Location = new System.Drawing.Point(108, 124);
            this.accCharY.Name = "accCharY";
            this.accCharY.Size = new System.Drawing.Size(162, 20);
            this.accCharY.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Y:";
            // 
            // accCharX
            // 
            this.accCharX.Location = new System.Drawing.Point(108, 98);
            this.accCharX.Name = "accCharX";
            this.accCharX.Size = new System.Drawing.Size(162, 20);
            this.accCharX.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "X:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Map:";
            // 
            // accCharName
            // 
            this.accCharName.Location = new System.Drawing.Point(108, 45);
            this.accCharName.Name = "accCharName";
            this.accCharName.Size = new System.Drawing.Size(162, 20);
            this.accCharName.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Name:";
            // 
            // accCharId
            // 
            this.accCharId.Enabled = false;
            this.accCharId.Location = new System.Drawing.Point(108, 19);
            this.accCharId.Name = "accCharId";
            this.accCharId.Size = new System.Drawing.Size(162, 20);
            this.accCharId.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Character Id:";
            // 
            // accUserSaveChanges
            // 
            this.accUserSaveChanges.Location = new System.Drawing.Point(633, 411);
            this.accUserSaveChanges.Name = "accUserSaveChanges";
            this.accUserSaveChanges.Size = new System.Drawing.Size(93, 23);
            this.accUserSaveChanges.TabIndex = 3;
            this.accUserSaveChanges.Text = "Save Changes";
            this.accUserSaveChanges.UseVisualStyleBackColor = true;
            this.accUserSaveChanges.Click += new System.EventHandler(this.accUserSaveChanges_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.accUserSalt);
            this.groupBox2.Controls.Add(this.accUserPassword);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(414, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 132);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authentication";
            // 
            // accUserSalt
            // 
            this.accUserSalt.Enabled = false;
            this.accUserSalt.Location = new System.Drawing.Point(68, 51);
            this.accUserSalt.Name = "accUserSalt";
            this.accUserSalt.Size = new System.Drawing.Size(238, 20);
            this.accUserSalt.TabIndex = 5;
            // 
            // accUserPassword
            // 
            this.accUserPassword.Enabled = false;
            this.accUserPassword.Location = new System.Drawing.Point(68, 22);
            this.accUserPassword.Name = "accUserPassword";
            this.accUserPassword.Size = new System.Drawing.Size(238, 20);
            this.accUserPassword.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Salt:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.accUserAccess);
            this.groupBox1.Controls.Add(this.accUserEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.accUserName);
            this.groupBox1.Controls.Add(this.accUserId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(132, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 132);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Access:";
            // 
            // accUserAccess
            // 
            this.accUserAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accUserAccess.FormattingEnabled = true;
            this.accUserAccess.Items.AddRange(new object[] {
            "Player",
            "Moderator",
            "Administrator"});
            this.accUserAccess.Location = new System.Drawing.Point(108, 101);
            this.accUserAccess.Name = "accUserAccess";
            this.accUserAccess.Size = new System.Drawing.Size(162, 21);
            this.accUserAccess.TabIndex = 6;
            // 
            // accUserEmail
            // 
            this.accUserEmail.Location = new System.Drawing.Point(108, 74);
            this.accUserEmail.Name = "accUserEmail";
            this.accUserEmail.Size = new System.Drawing.Size(162, 20);
            this.accUserEmail.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email:";
            // 
            // accUserName
            // 
            this.accUserName.Location = new System.Drawing.Point(108, 48);
            this.accUserName.Name = "accUserName";
            this.accUserName.Size = new System.Drawing.Size(162, 20);
            this.accUserName.TabIndex = 3;
            // 
            // accUserId
            // 
            this.accUserId.Enabled = false;
            this.accUserId.Location = new System.Drawing.Point(108, 22);
            this.accUserId.Name = "accUserId";
            this.accUserId.Size = new System.Drawing.Size(162, 20);
            this.accUserId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // lstAccounts
            // 
            this.lstAccounts.FormattingEnabled = true;
            this.lstAccounts.Location = new System.Drawing.Point(6, 6);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(120, 420);
            this.lstAccounts.TabIndex = 0;
            this.lstAccounts.SelectedIndexChanged += new System.EventHandler(this.lstAccounts_SelectedIndexChanged);
            // 
            // tabTilesets
            // 
            this.tabTilesets.Controls.Add(this.tilSaveChanges);
            this.tabTilesets.Controls.Add(this.groupBox3);
            this.tabTilesets.Controls.Add(this.lstTilesets);
            this.tabTilesets.Location = new System.Drawing.Point(4, 22);
            this.tabTilesets.Name = "tabTilesets";
            this.tabTilesets.Padding = new System.Windows.Forms.Padding(3);
            this.tabTilesets.Size = new System.Drawing.Size(732, 440);
            this.tabTilesets.TabIndex = 1;
            this.tabTilesets.Text = "Tilesets";
            this.tabTilesets.UseVisualStyleBackColor = true;
            // 
            // tilSaveChanges
            // 
            this.tilSaveChanges.Location = new System.Drawing.Point(633, 411);
            this.tilSaveChanges.Name = "tilSaveChanges";
            this.tilSaveChanges.Size = new System.Drawing.Size(93, 23);
            this.tilSaveChanges.TabIndex = 4;
            this.tilSaveChanges.Text = "Save Changes";
            this.tilSaveChanges.UseVisualStyleBackColor = true;
            this.tilSaveChanges.Click += new System.EventHandler(this.tilSaveChanges_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.tilTilesetDeleted);
            this.groupBox3.Controls.Add(this.tilTilesetFilename);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.tilTilesetId);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Location = new System.Drawing.Point(132, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 102);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 74);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "Deleted:";
            // 
            // tilTilesetDeleted
            // 
            this.tilTilesetDeleted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tilTilesetDeleted.FormattingEnabled = true;
            this.tilTilesetDeleted.Items.AddRange(new object[] {
            "False",
            "True"});
            this.tilTilesetDeleted.Location = new System.Drawing.Point(115, 71);
            this.tilTilesetDeleted.Name = "tilTilesetDeleted";
            this.tilTilesetDeleted.Size = new System.Drawing.Size(162, 21);
            this.tilTilesetDeleted.TabIndex = 8;
            // 
            // tilTilesetFilename
            // 
            this.tilTilesetFilename.Location = new System.Drawing.Point(115, 45);
            this.tilTilesetFilename.Name = "tilTilesetFilename";
            this.tilTilesetFilename.Size = new System.Drawing.Size(162, 20);
            this.tilTilesetFilename.TabIndex = 6;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(13, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 13);
            this.label22.TabIndex = 5;
            this.label22.Text = "Filename:";
            // 
            // tilTilesetId
            // 
            this.tilTilesetId.Enabled = false;
            this.tilTilesetId.Location = new System.Drawing.Point(115, 19);
            this.tilTilesetId.Name = "tilTilesetId";
            this.tilTilesetId.Size = new System.Drawing.Size(162, 20);
            this.tilTilesetId.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Tileset Id:";
            // 
            // lstTilesets
            // 
            this.lstTilesets.FormattingEnabled = true;
            this.lstTilesets.Location = new System.Drawing.Point(6, 6);
            this.lstTilesets.Name = "lstTilesets";
            this.lstTilesets.Size = new System.Drawing.Size(120, 420);
            this.lstTilesets.TabIndex = 0;
            this.lstTilesets.SelectedIndexChanged += new System.EventHandler(this.lstTilesets_SelectedIndexChanged);
            // 
            // dbfile
            // 
            this.dbfile.Enabled = false;
            this.dbfile.Location = new System.Drawing.Point(6, 8);
            this.dbfile.Name = "dbfile";
            this.dbfile.Size = new System.Drawing.Size(662, 20);
            this.dbfile.TabIndex = 1;
            this.dbfile.Text = "Please load a database file.";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(671, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tabgraphics
            // 
            this.tabgraphics.Controls.Add(this.tabControl2);
            this.tabgraphics.Location = new System.Drawing.Point(4, 22);
            this.tabgraphics.Name = "tabgraphics";
            this.tabgraphics.Padding = new System.Windows.Forms.Padding(3);
            this.tabgraphics.Size = new System.Drawing.Size(752, 506);
            this.tabgraphics.TabIndex = 1;
            this.tabgraphics.Text = "Graphics";
            this.tabgraphics.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(740, 494);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.vxinOutputDisplay);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "VX To Intersect";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // vxinOutputDisplay
            // 
            this.vxinOutputDisplay.FormattingEnabled = true;
            this.vxinOutputDisplay.Location = new System.Drawing.Point(12, 64);
            this.vxinOutputDisplay.Name = "vxinOutputDisplay";
            this.vxinOutputDisplay.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.vxinOutputDisplay.Size = new System.Drawing.Size(708, 303);
            this.vxinOutputDisplay.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 434);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(720, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Go!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.vxinOutput);
            this.groupBox5.Controls.Add(this.vxinBtnOutput);
            this.groupBox5.Location = new System.Drawing.Point(6, 376);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(720, 52);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output";
            // 
            // vxinOutput
            // 
            this.vxinOutput.Enabled = false;
            this.vxinOutput.Location = new System.Drawing.Point(6, 19);
            this.vxinOutput.Name = "vxinOutput";
            this.vxinOutput.Size = new System.Drawing.Size(627, 20);
            this.vxinOutput.TabIndex = 3;
            this.vxinOutput.Text = "Please select an output folder.";
            // 
            // vxinBtnOutput
            // 
            this.vxinBtnOutput.Location = new System.Drawing.Point(639, 17);
            this.vxinBtnOutput.Name = "vxinBtnOutput";
            this.vxinBtnOutput.Size = new System.Drawing.Size(75, 23);
            this.vxinBtnOutput.TabIndex = 2;
            this.vxinBtnOutput.Text = "Browse";
            this.vxinBtnOutput.UseVisualStyleBackColor = true;
            this.vxinBtnOutput.Click += new System.EventHandler(this.vxinBtnOutput_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.vxinInput);
            this.groupBox4.Controls.Add(this.vxinBtnInput);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(720, 52);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input";
            // 
            // vxinInput
            // 
            this.vxinInput.Enabled = false;
            this.vxinInput.Location = new System.Drawing.Point(6, 19);
            this.vxinInput.Name = "vxinInput";
            this.vxinInput.Size = new System.Drawing.Size(627, 20);
            this.vxinInput.TabIndex = 3;
            this.vxinInput.Text = "Please select an input folder.";
            // 
            // vxinBtnInput
            // 
            this.vxinBtnInput.Location = new System.Drawing.Point(639, 17);
            this.vxinBtnInput.Name = "vxinBtnInput";
            this.vxinBtnInput.Size = new System.Drawing.Size(75, 23);
            this.vxinBtnInput.TabIndex = 2;
            this.vxinBtnInput.Text = "Browse";
            this.vxinBtnInput.UseVisualStyleBackColor = true;
            this.vxinBtnInput.Click += new System.EventHandler(this.vxinBtnInput_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Resize Graphics";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // accCharMap
            // 
            this.accCharMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accCharMap.FormattingEnabled = true;
            this.accCharMap.Location = new System.Drawing.Point(108, 71);
            this.accCharMap.Name = "accCharMap";
            this.accCharMap.Size = new System.Drawing.Size(162, 21);
            this.accCharMap.TabIndex = 34;
            // 
            // accCharClass
            // 
            this.accCharClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accCharClass.FormattingEnabled = true;
            this.accCharClass.Location = new System.Drawing.Point(426, 22);
            this.accCharClass.Name = "accCharClass";
            this.accCharClass.Size = new System.Drawing.Size(162, 21);
            this.accCharClass.TabIndex = 35;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.TabsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intersect Toolkit";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.TabsMain.ResumeLayout(false);
            this.tabdatabase.ResumeLayout(false);
            this.tabdatabase.PerformLayout();
            this.tdatabase.ResumeLayout(false);
            this.tabaccounts.ResumeLayout(false);
            this.accCharBox.ResumeLayout(false);
            this.accCharBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabTilesets.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabgraphics.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabsMain;
        private System.Windows.Forms.TabPage tabdatabase;
        private System.Windows.Forms.TabControl tdatabase;
        private System.Windows.Forms.TabPage tabaccounts;
        private System.Windows.Forms.TabPage tabTilesets;
        private System.Windows.Forms.TextBox dbfile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TabPage tabgraphics;
        private System.Windows.Forms.ListBox lstAccounts;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox accUserSalt;
        private System.Windows.Forms.TextBox accUserPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox accUserAccess;
        private System.Windows.Forms.TextBox accUserEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox accUserName;
        private System.Windows.Forms.TextBox accUserId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button accUserSaveChanges;
        private System.Windows.Forms.GroupBox accCharBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox accCharName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox accCharId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox accCharSprite;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox accCharZ;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox accCharDirection;
        private System.Windows.Forms.TextBox accCharY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox accCharX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox accCharGender;
        private System.Windows.Forms.TextBox accCharStatpoints;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox accCharExp;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox accCharLevel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox accCharFace;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button tilSaveChanges;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox tilTilesetDeleted;
        private System.Windows.Forms.TextBox tilTilesetFilename;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tilTilesetId;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListBox lstTilesets;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox vxinOutput;
        private System.Windows.Forms.Button vxinBtnOutput;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox vxinInput;
        private System.Windows.Forms.Button vxinBtnInput;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox vxinOutputDisplay;
        private System.Windows.Forms.ComboBox accCharMap;
        private System.Windows.Forms.ComboBox accCharClass;
    }
}

