using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUDApplication
{
    public partial class MainForm : Form
    {
        SqlConnection con =
            new SqlConnection(DatabaseHelper.ConnectionString);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();

            cboYear.Items.Add("1st Year");
            cboYear.Items.Add("2nd Year");
            cboYear.Items.Add("3rd Year");
            cboYear.Items.Add("4th Year");
        }

        private void LoadData()
        {
            SqlDataAdapter da =
                new SqlDataAdapter("SELECT * FROM Students", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvStudents.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Students(StudentName, Course, YearLevel) VALUES(@name,@course,@year)",
                    con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@course", txtCourse.Text);
                cmd.Parameters.AddWithValue("@year", cboYear.Text);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Record Added Successfully");

                LoadData();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Students SET StudentName=@name, Course=@course, YearLevel=@year WHERE Id=@id",
                    con);

                cmd.Parameters.AddWithValue("@id",
                    dgvStudents.CurrentRow.Cells[0].Value);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@course", txtCourse.Text);
                cmd.Parameters.AddWithValue("@year", cboYear.Text);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Record Updated Successfully");

                LoadData();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Students WHERE Id=@id",
                    con);

                cmd.Parameters.AddWithValue("@id",
                    dgvStudents.CurrentRow.Cells[0].Value);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Record Deleted Successfully");

                LoadData();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT * FROM Students WHERE StudentName LIKE '%" +
                    txtSearch.Text + "%'",
                    con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvStudents.DataSource = dt;
        }

        private void dgvStudents_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            txtName.Text =
                dgvStudents.CurrentRow.Cells[1].Value.ToString();

            txtCourse.Text =
                dgvStudents.CurrentRow.Cells[2].Value.ToString();

            cboYear.Text =
                dgvStudents.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtCourse.Clear();
            cboYear.SelectedIndex = -1;
        }
    }
}
