using jmILRL.BAL;
using jmILRL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jmILRL.Sections
{
    public partial class FrmEdit : FrmBase
    {
        public FrmEdit()
        {
            InitializeComponent();
            Load += FrmEdit_Load;
        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            if (Fbt != null) {
                textBox1.Text = Fbt.serialNumber;
                textBoxID.Text = Fbt.staff;
                batchNumber.Text = Fbt.batchNumber;
            }
        }

        public FBT Fbt { get; set; }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FBT f = new FBT();
            f.serialNumber = textBox1.Text;
            f.staff = textBoxID.Text.Trim();
            f.batchNumber = batchNumber.Text.Trim();
            FBTService fBTService = new FBTService();
            fBTService.editInfo(f);
            this.Close();
        }
    }
}
