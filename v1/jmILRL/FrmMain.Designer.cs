namespace jmILRL
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnMini = new jmILRL.UI.ThreeDbtn();
            this.btnEx1 = new jmILRL.UI.btnEx();
            this.btnTest = new jmILRL.UI.SignleButton();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.comboBoxPortType = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.batchNumber = new System.Windows.Forms.TextBox();
            this.serialNumber_pre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new jmILRL.UI.SignleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.IL4 = new System.Windows.Forms.Label();
            this.IL3 = new System.Windows.Forms.Label();
            this.IL2 = new System.Windows.Forms.Label();
            this.IL1 = new System.Windows.Forms.Label();
            this.level = new Result.Result();
            this.labelCom = new System.Windows.Forms.Label();
            this.radioButtonIL = new System.Windows.Forms.RadioButton();
            this.radioButtonRL = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxSet = new System.Windows.Forms.PictureBox();
            this.pictureBoxReview = new System.Windows.Forms.PictureBox();
            this.RL3 = new System.Windows.Forms.Label();
            this.RL2 = new System.Windows.Forms.Label();
            this.RL1 = new System.Windows.Forms.Label();
            this.RL4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.serialNumber_pix = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReview)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.BackgroundImage = global::jmILRL.Properties.Resources._3btn_mini1;
            this.btnMini.Location = new System.Drawing.Point(1116, 8);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(32, 23);
            this.btnMini.TabIndex = 6;
            this.btnMini.UseVisualStyleBackColor = true;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // btnEx1
            // 
            this.btnEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEx1.ClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEx1.EnterColor = System.Drawing.Color.Red;
            this.btnEx1.Location = new System.Drawing.Point(1152, 11);
            this.btnEx1.Name = "btnEx1";
            this.btnEx1.Size = new System.Drawing.Size(20, 20);
            this.btnEx1.TabIndex = 9;
            this.btnEx1.Text = "btnEx1";
            this.btnEx1.Title = "title";
            this.btnEx1.UseVisualStyleBackColor = true;
            this.btnEx1.Click += new System.EventHandler(this.btnEx1_Click);
            // 
            // btnTest
            // 
            this.btnTest.BaseColor = System.Drawing.Color.DodgerBlue;
            this.btnTest.ClickColor = System.Drawing.Color.DarkBlue;
            this.btnTest.Colorstyle = jmILRL.UI.SignleButton.Style.Gradient;
            this.btnTest.EnterColor = System.Drawing.Color.RoyalBlue;
            this.btnTest.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest.ForeColor = System.Drawing.Color.Black;
            this.btnTest.Location = new System.Drawing.Point(781, 518);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(89, 32);
            this.btnTest.TabIndex = 12;
            this.btnTest.Text = "测 试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxID.Location = new System.Drawing.Point(910, 316);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(214, 50);
            this.textBoxID.TabIndex = 88;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(797, 323);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(110, 37);
            this.label39.TabIndex = 87;
            this.label39.Text = "工号:";
            // 
            // comboBoxPortType
            // 
            this.comboBoxPortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPortType.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxPortType.FormattingEnabled = true;
            this.comboBoxPortType.Items.AddRange(new object[] {
            "1X1",
            "1X2",
            "1X3",
            "1X4"});
            this.comboBoxPortType.Location = new System.Drawing.Point(910, 267);
            this.comboBoxPortType.Name = "comboBoxPortType";
            this.comboBoxPortType.Size = new System.Drawing.Size(214, 45);
            this.comboBoxPortType.TabIndex = 84;
            this.comboBoxPortType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPortType_SelectedIndexChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.Location = new System.Drawing.Point(723, 266);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(184, 37);
            this.label37.TabIndex = 83;
            this.label37.Text = "端口类型:";
            // 
            // batchNumber
            // 
            this.batchNumber.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.batchNumber.Location = new System.Drawing.Point(910, 372);
            this.batchNumber.Name = "batchNumber";
            this.batchNumber.Size = new System.Drawing.Size(214, 50);
            this.batchNumber.TabIndex = 81;
            // 
            // serialNumber_pre
            // 
            this.serialNumber_pre.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serialNumber_pre.Location = new System.Drawing.Point(910, 435);
            this.serialNumber_pre.Name = "serialNumber_pre";
            this.serialNumber_pre.Size = new System.Drawing.Size(143, 50);
            this.serialNumber_pre.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(796, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 37);
            this.label1.TabIndex = 79;
            this.label1.Text = "SN号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(797, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 37);
            this.label2.TabIndex = 80;
            this.label2.Text = "单号:";
            // 
            // btnSave
            // 
            this.btnSave.BaseColor = System.Drawing.Color.ForestGreen;
            this.btnSave.ClickColor = System.Drawing.Color.DarkBlue;
            this.btnSave.Colorstyle = jmILRL.UI.SignleButton.Style.Gradient;
            this.btnSave.EnterColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(942, 518);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 32);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(723, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 37);
            this.label4.TabIndex = 91;
            this.label4.Text = "测试端口:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(779, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "IL/RL：";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(910, 216);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(214, 45);
            this.comboBoxPort.TabIndex = 0;
            this.comboBoxPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxPort_SelectedIndexChanged);
            // 
            // IL4
            // 
            this.IL4.AutoSize = true;
            this.IL4.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IL4.Location = new System.Drawing.Point(12, 322);
            this.IL4.Name = "IL4";
            this.IL4.Size = new System.Drawing.Size(92, 48);
            this.IL4.TabIndex = 0;
            this.IL4.Text = "IL4";
            // 
            // IL3
            // 
            this.IL3.AutoSize = true;
            this.IL3.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IL3.Location = new System.Drawing.Point(12, 239);
            this.IL3.Name = "IL3";
            this.IL3.Size = new System.Drawing.Size(92, 48);
            this.IL3.TabIndex = 0;
            this.IL3.Text = "IL3";
            // 
            // IL2
            // 
            this.IL2.AutoSize = true;
            this.IL2.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IL2.Location = new System.Drawing.Point(12, 159);
            this.IL2.Name = "IL2";
            this.IL2.Size = new System.Drawing.Size(92, 48);
            this.IL2.TabIndex = 0;
            this.IL2.Text = "IL2";
            // 
            // IL1
            // 
            this.IL1.AutoSize = true;
            this.IL1.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IL1.Location = new System.Drawing.Point(12, 72);
            this.IL1.Name = "IL1";
            this.IL1.Size = new System.Drawing.Size(92, 48);
            this.IL1.TabIndex = 0;
            this.IL1.Text = "IL1";
            // 
            // level
            // 
            this.level.Fontsize = 32;
            this.level.Location = new System.Drawing.Point(785, 83);
            this.level.Name = "level";
            this.level.ShowResult = Result.result.none;
            this.level.Size = new System.Drawing.Size(170, 87);
            this.level.TabIndex = 0;
            this.level.Title = "测试结果：";
            // 
            // labelCom
            // 
            this.labelCom.AutoSize = true;
            this.labelCom.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCom.Location = new System.Drawing.Point(32, 540);
            this.labelCom.Name = "labelCom";
            this.labelCom.Size = new System.Drawing.Size(42, 14);
            this.labelCom.TabIndex = 92;
            this.labelCom.Text = "COM：";
            // 
            // radioButtonIL
            // 
            this.radioButtonIL.AutoSize = true;
            this.radioButtonIL.Checked = true;
            this.radioButtonIL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonIL.Location = new System.Drawing.Point(848, 187);
            this.radioButtonIL.Name = "radioButtonIL";
            this.radioButtonIL.Size = new System.Drawing.Size(42, 20);
            this.radioButtonIL.TabIndex = 93;
            this.radioButtonIL.TabStop = true;
            this.radioButtonIL.Text = "IL";
            this.radioButtonIL.UseVisualStyleBackColor = true;
            // 
            // radioButtonRL
            // 
            this.radioButtonRL.AutoSize = true;
            this.radioButtonRL.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonRL.Location = new System.Drawing.Point(913, 187);
            this.radioButtonRL.Name = "radioButtonRL";
            this.radioButtonRL.Size = new System.Drawing.Size(42, 20);
            this.radioButtonRL.TabIndex = 93;
            this.radioButtonRL.Text = "RL";
            this.radioButtonRL.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 94;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IL1);
            this.groupBox1.Controls.Add(this.IL3);
            this.groupBox1.Controls.Add(this.IL2);
            this.groupBox1.Controls.Add(this.IL4);
            this.groupBox1.Location = new System.Drawing.Point(25, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 417);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IL";
            // 
            // pictureBoxSet
            // 
            this.pictureBoxSet.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSet.Image")));
            this.pictureBoxSet.Location = new System.Drawing.Point(799, 11);
            this.pictureBoxSet.Name = "pictureBoxSet";
            this.pictureBoxSet.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxSet.TabIndex = 97;
            this.pictureBoxSet.TabStop = false;
            this.pictureBoxSet.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBoxSet.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBoxSet.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // pictureBoxReview
            // 
            this.pictureBoxReview.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxReview.Image")));
            this.pictureBoxReview.Location = new System.Drawing.Point(838, 11);
            this.pictureBoxReview.Name = "pictureBoxReview";
            this.pictureBoxReview.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxReview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxReview.TabIndex = 98;
            this.pictureBoxReview.TabStop = false;
            this.pictureBoxReview.Click += new System.EventHandler(this.pictureBoxReview_Click);
            // 
            // RL3
            // 
            this.RL3.AutoSize = true;
            this.RL3.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RL3.Location = new System.Drawing.Point(18, 236);
            this.RL3.Name = "RL3";
            this.RL3.Size = new System.Drawing.Size(92, 48);
            this.RL3.TabIndex = 2;
            this.RL3.Text = "RL3";
            // 
            // RL2
            // 
            this.RL2.AutoSize = true;
            this.RL2.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RL2.Location = new System.Drawing.Point(18, 156);
            this.RL2.Name = "RL2";
            this.RL2.Size = new System.Drawing.Size(92, 48);
            this.RL2.TabIndex = 3;
            this.RL2.Text = "RL2";
            // 
            // RL1
            // 
            this.RL1.AutoSize = true;
            this.RL1.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RL1.Location = new System.Drawing.Point(18, 69);
            this.RL1.Name = "RL1";
            this.RL1.Size = new System.Drawing.Size(92, 48);
            this.RL1.TabIndex = 4;
            this.RL1.Text = "RL1";
            // 
            // RL4
            // 
            this.RL4.AutoSize = true;
            this.RL4.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RL4.Location = new System.Drawing.Point(18, 319);
            this.RL4.Name = "RL4";
            this.RL4.Size = new System.Drawing.Size(92, 48);
            this.RL4.TabIndex = 1;
            this.RL4.Text = "RL4";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RL4);
            this.groupBox2.Controls.Add(this.RL1);
            this.groupBox2.Controls.Add(this.RL3);
            this.groupBox2.Controls.Add(this.RL2);
            this.groupBox2.Location = new System.Drawing.Point(367, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 417);
            this.groupBox2.TabIndex = 96;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RL";
            // 
            // serialNumber_pix
            // 
            this.serialNumber_pix.Font = new System.Drawing.Font("宋体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serialNumber_pix.Location = new System.Drawing.Point(1059, 435);
            this.serialNumber_pix.Name = "serialNumber_pix";
            this.serialNumber_pix.Size = new System.Drawing.Size(119, 50);
            this.serialNumber_pix.TabIndex = 82;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(330, 492);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(433, 85);
            this.richTextBox1.TabIndex = 99;
            this.richTextBox1.Text = "";
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnTest;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1187, 583);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBoxReview);
            this.Controls.Add(this.pictureBoxSet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioButtonRL);
            this.Controls.Add(this.radioButtonIL);
            this.Controls.Add(this.labelCom);
            this.Controls.Add(this.level);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.comboBoxPortType);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.batchNumber);
            this.Controls.Add(this.serialNumber_pix);
            this.Controls.Add(this.serialNumber_pre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnEx1);
            this.Controls.Add(this.btnMini);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(3, 80, 3, 3);
            this.Text = "插回损测试软件";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReview)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private jmILRL.UI.ThreeDbtn btnMini;
        private jmILRL.UI.btnEx btnEx1;
        private UI.SignleButton btnTest;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox comboBoxPortType;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox batchNumber;
        private System.Windows.Forms.TextBox serialNumber_pre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UI.SignleButton btnSave;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label IL4;
        private System.Windows.Forms.Label IL3;
        private System.Windows.Forms.Label IL2;
        private System.Windows.Forms.Label IL1;
        private Result.Result level;
        private System.Windows.Forms.Label labelCom;
        private System.Windows.Forms.RadioButton radioButtonIL;
        private System.Windows.Forms.RadioButton radioButtonRL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxSet;
        private System.Windows.Forms.PictureBox pictureBoxReview;
        private System.Windows.Forms.Label RL3;
        private System.Windows.Forms.Label RL2;
        private System.Windows.Forms.Label RL1;
        private System.Windows.Forms.Label RL4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox serialNumber_pix;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

