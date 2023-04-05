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
    public partial class FormStudentInfo : Form
    {
        public FormStudentInfo()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormStudent form = new FormStudent(this);
            form.ShowDialog();
        }

        private void FormStudentInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }

  

        public void LoadData()
        {
            string connectionString = "Server=LAPTOP-LLJ97LUS; Database=ManagementUniversity; Trusted_Connection=True;";
            string query = "select * from Student";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);

            DataSet set = new DataSet();

            adapter.Fill(set, "Student");
            dataGridView.DataSource = set.Tables["Student"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView.SelectedCells[0].Value.ToString());
            DbStudent.DeleteStudent(id);
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
            string name = dataGridView.CurrentRow.Cells[1].Value.ToString();
            string region = dataGridView.CurrentRow.Cells[2].Value.ToString();
            string clas = dataGridView.CurrentRow.Cells[3].Value.ToString();
            string section = dataGridView.CurrentRow.Cells[4].Value.ToString();

            Student student = new Student(name, region, clas, section);
            DbStudent.UpdateStudent(student, id);
            LoadData();

        }
    }


}
