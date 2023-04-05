using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student
{
    public partial class FormStudent : Form
    {
        private readonly FormStudentInfo _parent;
        public FormStudent(FormStudentInfo parent)
        {
            InitializeComponent();

            _parent = parent;

        }

        public void Clear()
        {
            txtName.Text = txtReg.Text = txtClass.Text = txtSection.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student name is Empty ( > 3). ");
                return;
            }

            if (txtReg.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student Reg is Empty ( > 1). ");
                return;
            }

            if (txtClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Class is Empty ( > 1). ");
                return;
            }

            if (txtSection.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student section is Empty ( > 1). ");
                return;
            }



            Student std = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
            DbStudent.AddStudent(std);
            Clear();
            this.Close();
            _parent.LoadData();
        }
    }
}
