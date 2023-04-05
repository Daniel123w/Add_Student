using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Student
{
    class DbStudent
    {

        public static void AddStudent(Student std)

        {
            string sql = "INSERT INTO Student VALUES (@StudentName, @StudentReg, @StudentClass,@StudentSection)";
            string connectionString = "Server=LAPTOP-LLJ97LUS; Database=ManagementUniversity; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentReg", SqlDbType.VarChar).Value = std.Region;
            cmd.Parameters.Add("@StudentClass", SqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", SqlDbType.VarChar).Value = std.Section;

            try
            {
                connection.Open();
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



        public static void UpdateStudent(Student std, int id)

        {
            string sql = "UPDATE Student SET Name = @StudentName, Region = @StudentReg, Class = @StudentClass, Section = @StudentSection WHERE StudentId = @StudentID";
            string connectionString = "Server=LAPTOP-LLJ97LUS; Database=ManagementUniversity; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@StudentName", SqlDbType.VarChar).Value = std.Name;
            cmd.Parameters.Add("@StudentReg", SqlDbType.VarChar).Value = std.Region;
            cmd.Parameters.Add("@StudentClass", SqlDbType.VarChar).Value = std.Class;
            cmd.Parameters.Add("@StudentSection", SqlDbType.VarChar).Value = std.Section;
            try
            {
                connection.Open();
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


        public static void DeleteStudent(int id)

        {
            string sql = "DELETE FROM Student WHERE StudentId = @StudentID";
            string connectionString = "Server=LAPTOP-LLJ97LUS; Database=ManagementUniversity; Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = id;
            try
            {
                connection.Open();
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










    }

}