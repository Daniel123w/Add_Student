using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Student
{
    internal class DbStudentBase1
    {
        public static void AddStudent(Student std)

        {
            string sql = "INSERT INTO Student VALUES (NULL, @StudentName, @StudentReg, @StudentClass,@StudentSection,NULL)";
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentReg", SqlDbType.VarChar).Value = std.Region;
            cmd.Parameters.Add("@StudentClass", SqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", SqlDbType.VarChar).Value = std.Section;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (SqlException ex)
            {
                MessageBox.Show("Student not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                connection.Close();
            }

        }


        public static void DeleteStudent(string id)

        {
            string sql = "DELETE FROM Student_tbl WHERE ID = @StudentID";
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (SqlException ex)
            {
                MessageBox.Show("Student not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {

                connection.Close();

            }
        }



        public static void UpdateStudent(Student std, string id)

        {
            string sql = "UPDATE Student_tbl SET Name = @StudentName, Reg = @StudentReg, Class = @StudentClass, Section = @StudentSection WHERE ID = @StudentID";
            SqlConnection connection = new SqlConnection();
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentReg", SqlDbType.VarChar).Value = std.Region;
            cmd.Parameters.Add("@StudentClass", SqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", SqlDbType.VarChar).Value = std.Section;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (SqlException ex)
            {
                MessageBox.Show("Student not update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            finally
            {
                connection.Close();
            }

        }
       

        
    }
}