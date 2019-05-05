namespace jmILRL.UI
{
    partial class PagerEx
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelpre = new System.Windows.Forms.Label();
            this.labelnext = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.panelbtn = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelpre
            // 
            this.labelpre.AutoSize = true;
            this.labelpre.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelpre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.labelpre.Location = new System.Drawing.Point(22, 7);
            this.labelpre.Name = "labelpre";
            this.labelpre.Size = new System.Drawing.Size(11, 12);
            this.labelpre.TabIndex = 33;
            this.labelpre.Text = "<";
            this.labelpre.Click += new System.EventHandler(this.labelpre_Click);
            // 
            // labelnext
            // 
            this.labelnext.AutoSize = true;
            this.labelnext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelnext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))));
            this.labelnext.Location = new System.Drawing.Point(187, 7);
            this.labelnext.Name = "labelnext";
            this.labelnext.Size = new System.Drawing.Size(11, 12);
            this.labelnext.TabIndex = 32;
            this.labelnext.Text = ">";
            this.labelnext.Click += new System.EventHandler(this.labelnext_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelTotal.ForeColor = System.Drawing.Color.Black;
            this.labelTotal.Location = new System.Drawing.Point(205, 7);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(35, 12);
            this.labelTotal.TabIndex = 35;
            this.labelTotal.Text = "共6页";
            // 
            // panelbtn
            // 
            this.panelbtn.Location = new System.Drawing.Point(165, 0);
            this.panelbtn.Name = "panelbtn";
            this.panelbtn.Size = new System.Drawing.Size(20, 27);
            this.panelbtn.TabIndex = 36;
            // 
            // PagerEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelbtn);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelpre);
            this.Controls.Add(this.labelnext);
            this.Name = "PagerEx";
            this.Size = new System.Drawing.Size(241, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelpre;
        private System.Windows.Forms.Label labelnext;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Panel panelbtn;
    }
}
