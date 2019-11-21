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
    public partial class UpdateStudentForm : Form
    {
        private int Student_id;
        private StudenManagement Business;
        public UpdateStudentForm(int id)
        {
            InitializeComponent();
            this.Student_id = id;
            this.Business = new StudenManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.Load += UpdateStudentForm_Load;
        }

        void UpdateStudentForm_Load(object sender, EventArgs e)
        {
            var @student = this.Business.GetStudent(this.Student_id);
            this.txtCode.Text = @student.code;
            this.txtName.Text = @student.name;
            this.rdbMale.Checked = @student.gender;
            this.rdbFemale.Checked = @student.gender;
            this.rtbHomeTown.Text = @student.hometown;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var code = this.txtCode.Text;
            var male = this.rdbMale.Checked;
            var female = this.rdbFemale.Checked;
            var hometown = this.rtbHomeTown.Text;
            this.Business.UpdateStudent(this.Student_id, code, name , female , hometown);
            MessageBox.Show("Update Student Successfully.");
            this.Close();
        }
    }
}
