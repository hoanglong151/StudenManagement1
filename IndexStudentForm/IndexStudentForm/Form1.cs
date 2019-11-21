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
    public partial class IndexStudenFrom : Form
    {
        private StudenManagement Business;
        public IndexStudenFrom()
        {
            InitializeComponent();
            this.Business = new StudenManagement();
            this.Load += IndexStudenFrom_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStudents.DoubleClick += grdStudents_DoubleClick;


        }

        void grdStudents_DoubleClick(object sender, EventArgs e)
        {
            var @studen = (PM20577)this.grdStudents.SelectedRows[0].DataBoundItem;
            var updateForm = new UpdateStudentForm(@studen.id);
            updateForm.ShowDialog();
            this.LoadAllStudent();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdStudents.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this?", "Confire",
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var @student = (PM20577)this.grdStudents.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteStudent(@student.id);
                    MessageBox.Show("Delete Student Successfully.");
                    this.LoadAllStudent();
                }
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateStudentForm();
            createForm.ShowDialog();
            this.LoadAllStudent();
        }

        void IndexStudenFrom_Load(object sender, EventArgs e)
        {
            this.LoadAllStudent();
        }
        private void LoadAllStudent()
        {
            var student = this.Business.GetStudent();
            this.grdStudents.DataSource = student;
        }
    }
}
