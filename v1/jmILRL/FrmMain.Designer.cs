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
            this.btnMini = new jmILRL.UI.ThreeDbtn();
            this.btnEx1 = new jmILRL.UI.btnEx();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.signleButton1 = new jmILRL.UI.SignleButton();
            this.SuspendLayout();
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.BackgroundImage = global::jmILRL.Properties.Resources._3btn_mini1;
            this.btnMini.Location = new System.Drawing.Point(517, 17);
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
            this.btnEx1.Location = new System.Drawing.Point(555, 20);
            this.btnEx1.Name = "btnEx1";
            this.btnEx1.Size = new System.Drawing.Size(20, 20);
            this.btnEx1.TabIndex = 9;
            this.btnEx1.Text = "btnEx1";
            this.btnEx1.Title = "title";
            this.btnEx1.UseVisualStyleBackColor = true;
            this.btnEx1.Click += new System.EventHandler(this.btnEx1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 117);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(586, 95);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // signleButton1
            // 
            this.signleButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.signleButton1.BaseColor = System.Drawing.Color.SteelBlue;
            this.signleButton1.ClickColor = System.Drawing.Color.DarkBlue;
            this.signleButton1.Colorstyle = jmILRL.common.Style.Gradient;
            this.signleButton1.EnterColor = System.Drawing.Color.RoyalBlue;
            this.signleButton1.Location = new System.Drawing.Point(499, 491);
            this.signleButton1.Name = "signleButton1";
            this.signleButton1.Size = new System.Drawing.Size(76, 39);
            this.signleButton1.TabIndex = 11;
            this.signleButton1.Text = "测  试";
            this.signleButton1.UseVisualStyleBackColor = false;
            this.signleButton1.Click += new System.EventHandler(this.signleButton1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 553);
            this.Controls.Add(this.signleButton1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnEx1);
            this.Controls.Add(this.btnMini);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(3, 80, 3, 3);
            this.Text = "插回损测试软件";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private jmILRL.UI.ThreeDbtn btnMini;
        private jmILRL.UI.btnEx btnEx1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private jmILRL.UI.SignleButton signleButton1;

    }
}

