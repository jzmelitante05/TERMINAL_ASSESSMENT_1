namespace CRUDApplication
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvStudents;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCourse = new System.Windows.Forms.TextBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)
            (this.dgvStudents)).BeginInit();

            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font =
                new System.Drawing.Font("Segoe UI", 18F);

            this.lblTitle.Location =
                new System.Drawing.Point(250, 20);

            this.lblTitle.Text =
                "STUDENT MANAGEMENT SYSTEM";

            this.txtName.Location =
                new System.Drawing.Point(50, 80);

            this.txtName.Size =
                new System.Drawing.Size(200, 23);

            this.txtCourse.Location =
                new System.Drawing.Point(50, 120);

            this.txtCourse.Size =
                new System.Drawing.Size(200, 23);

            this.cboYear.Location =
                new System.Drawing.Point(50, 160);

            this.cboYear.Size =
                new System.Drawing.Size(200, 23);

            this.btnAdd.Location =
                new System.Drawing.Point(300, 80);

            this.btnAdd.Size =
                new System.Drawing.Size(100, 35);

            this.btnAdd.Text = "Add";

            this.btnAdd.Click +=
                new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location =
                new System.Drawing.Point(420, 80);

            this.btnUpdate.Size =
                new System.Drawing.Size(100, 35);

            this.btnUpdate.Text = "Update";

            this.btnUpdate.Click +=
                new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location =
                new System.Drawing.Point(540, 80);

            this.btnDelete.Size =
                new System.Drawing.Size(100, 35);

            this.btnDelete.Text = "Delete";

            this.btnDelete.Click +=
                new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location =
                new System.Drawing.Point(660, 80);

            this.btnClear.Size =
                new System.Drawing.Size(100, 35);

            this.btnClear.Text = "Clear";

            this.btnClear.Click +=
                new System.EventHandler(this.btnClear_Click);

            this.txtSearch.Location =
                new System.Drawing.Point(50, 220);

            this.txtSearch.Size =
                new System.Drawing.Size(250, 23);

            this.btnSearch.Location =
                new System.Drawing.Point(320, 220);

            this.btnSearch.Size =
                new System.Drawing.Size(100, 30);

            this.btnSearch.Text = "Search";

            this.btnSearch.Click +=
                new System.EventHandler(this.btnSearch_Click);

            this.dgvStudents.Location =
                new System.Drawing.Point(50, 280);

            this.dgvStudents.Size =
                new System.Drawing.Size(700, 250);

            this.dgvStudents.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvStudents_CellClick);

            this.ClientSize =
                new System.Drawing.Size(800, 600);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvStudents);

            this.Text = "CRUD Application";

            this.Load +=
                new System.EventHandler(this.MainForm_Load);

            ((System.ComponentModel.ISupportInitialize)
            (this.dgvStudents)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
