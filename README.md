# Terminal Assessment 1 (TA1)

## Database-Driven CRUD Application using C# WinForms and ADO.NET

This project is a fully functional database-driven desktop application developed using C# WinForms and ADO.NET. The system demonstrates all CRUD operations connected to a local SQL Server database.

The project was created as part of the Week 6 Terminal Assessment 1 (TA1).

---

# Project Objectives

The objectives of this project are:

- Create a database-driven desktop application
- Implement CRUD functionality
- Connect C# application to SQL Server
- Apply ADO.NET components
- Design a user-friendly interface
- Practice database management

---

# Technologies Used

- C#
- Windows Forms
- ADO.NET
- SQL Server
- Visual Studio

---

# Features

- Add Records
- View Records
- Update Records
- Delete Records
- SQL Server Database Connection
- DataGridView Display
- Search Function
- User-Friendly Interface

---

# Database Name

```plaintext
StudentDB
```

---

# Database Table

## Table Name

```plaintext
Students
```

---

# SQL Script

```sql
CREATE DATABASE StudentDB;
GO

USE StudentDB;
GO

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    StudentName VARCHAR(100),
    Course VARCHAR(100),
    YearLevel VARCHAR(50)
);
```

---

# Project Structure

```plaintext
CRUDApplication/
│
├── MainForm.cs
├── DatabaseHelper.cs
├── Program.cs
├── App.config
├── README.md
└── Screenshots/
```

---

# Required Controls

| Control | Name |
|---|---|
| TextBox | txtName |
| TextBox | txtCourse |
| ComboBox | cboYear |
| Button | btnAdd |
| Button | btnUpdate |
| Button | btnDelete |
| Button | btnClear |
| DataGridView | dgvStudents |
| TextBox | txtSearch |
| Button | btnSearch |

---

# App.config

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="MyConnection"
         connectionString="Data Source=.;Initial Catalog=StudentDB;Integrated Security=True"
         providerName="System.Data.SqlClient"/>
  </connectionStrings>
</configuration>
```

---

# Program.cs

```csharp
using System;
using System.Windows.Forms;

namespace CRUDApplication
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
```

---

# DatabaseHelper.cs

```csharp
using System.Configuration;
using System.Data.SqlClient;

namespace CRUDApplication
{
    public class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
    }
}
```

---

# MainForm.cs

```csharp
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUDApplication
{
    public partial class MainForm : Form
    {
        SqlConnection con = new SqlConnection(DatabaseHelper.GetConnectionString());

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
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Students", con);

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

                cmd.Parameters.AddWithValue("@id", dgvStudents.CurrentRow.Cells[0].Value);
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

                cmd.Parameters.AddWithValue("@id", dgvStudents.CurrentRow.Cells[0].Value);

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

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvStudents.CurrentRow.Cells[1].Value.ToString();
            txtCourse.Text = dgvStudents.CurrentRow.Cells[2].Value.ToString();
            cboYear.Text = dgvStudents.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Students WHERE StudentName LIKE '%" + txtSearch.Text + "%'",
                con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvStudents.DataSource = dt;
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
```

---

# Sample Workflow

```plaintext
START
   ↓
Open Application
   ↓
Connect to Database
   ↓
Add/View/Edit/Delete Records
   ↓
Display Updated Data
   ↓
Search Records
   ↓
Exit Application
   ↓
END
```

---

# CRUD Operations

| Operation | Description |
|---|---|
| Create | Add new student |
| Read | View student records |
| Update | Modify student information |
| Delete | Remove student records |

---

# How to Run the Project

1. Open SQL Server Management Studio
2. Execute the SQL script
3. Open the project in Visual Studio
4. Configure App.config connection string
5. Run the application
6. Test CRUD operations

---

# Grading Rubric

| Category | Percentage |
|---|---|
| UI Design | 20% |
| Code Logic | 40% |
| CRUD Functionality | 40% |

---

# Learning Outcomes

This project helped develop skills in:

- C# Programming
- Windows Forms Development
- Database Connectivity
- SQL Server Management
- CRUD Operations
- ADO.NET Components
- UI Design

---

# Conclusion

The Terminal Assessment successfully demonstrated the development of a fully functional database-driven desktop application using C# WinForms and ADO.NET. The application implemented all CRUD operations connected to SQL Server while maintaining proper UI design and structured code logic.

---

# Future Improvements

- Add Login System
- Add User Roles
- Add Export to Excel
- Add Report Generation
- Add Data Validation
- Improve UI Design
- Add Backup System

---

# Submitted By

| Information | Details |
|---|---|
| Name | Joezainne Melitante |
| Course & Section | 2.1 BSIT |
| Instructor | Mr. Edward James V. Grageda |
| Date Submitted | May 23, 2026 |

---
