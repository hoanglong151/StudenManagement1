using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexStudentForm
{
    public partial class CreateStudentForm : Form
    {
        private StudenManagement Business;
        public CreateStudentForm()
        {
            InitializeComponent();
            this.Business = new StudenManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var code = this.txtCode.Text;
            var name = this.txtName.Text;
            var famale = this.rdbFemale.Checked;
            var male = this.rdbMale.Checked;
            var hometown = this.rtbHomeTown.Text;
            this.Business.CreateStudent(code, name,famale,hometown );
            MessageBox.Show("Create Student Successfully");
            this.Close();
        }
    }
}
