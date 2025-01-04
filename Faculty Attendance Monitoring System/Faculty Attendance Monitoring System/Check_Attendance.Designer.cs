
namespace Faculty_Attendance_Monitoring_System
{
    partial class Check_Attendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Check_Attendance));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblname = new System.Windows.Forms.Label();
            this.btnDispose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.lblView = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCheckAttendance = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Controls.Add(this.btnDispose);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtp1);
            this.panel1.Controls.Add(this.lblView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 120);
            this.panel1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Blue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(621, 25);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(225, 32);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(23, 45);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(0, 36);
            this.lblname.TabIndex = 12;
            // 
            // btnDispose
            // 
            this.btnDispose.BackColor = System.Drawing.Color.Red;
            this.btnDispose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDispose.BackgroundImage")));
            this.btnDispose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDispose.Location = new System.Drawing.Point(875, 12);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(66, 59);
            this.btnDispose.TabIndex = 11;
            this.btnDispose.UseVisualStyleBackColor = false;
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(621, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(225, 32);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtp1
            // 
            this.dtp1.CalendarFont = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.CustomFormat = "MMMM/yyyy";
            this.dtp1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp1.Location = new System.Drawing.Point(375, 29);
            this.dtp1.MaxDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtp1.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(225, 28);
            this.dtp1.TabIndex = 9;
            this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(677, 74);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(0, 20);
            this.lblView.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCheckAttendance);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 466);
            this.panel2.TabIndex = 1;
            // 
            // dgvCheckAttendance
            // 
            this.dgvCheckAttendance.AllowUserToAddRows = false;
            this.dgvCheckAttendance.AllowUserToDeleteRows = false;
            this.dgvCheckAttendance.AllowUserToResizeColumns = false;
            this.dgvCheckAttendance.AllowUserToResizeRows = false;
            this.dgvCheckAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvCheckAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCheckAttendance.Location = new System.Drawing.Point(0, 0);
            this.dgvCheckAttendance.Name = "dgvCheckAttendance";
            this.dgvCheckAttendance.RowHeadersVisible = false;
            this.dgvCheckAttendance.RowHeadersWidth = 51;
            this.dgvCheckAttendance.RowTemplate.Height = 24;
            this.dgvCheckAttendance.Size = new System.Drawing.Size(953, 466);
            this.dgvCheckAttendance.TabIndex = 0;
            this.dgvCheckAttendance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckAttendance_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 47;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "DATE";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "TIME-IN";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "TIME-OUT";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Check_Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 586);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Check_Attendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check_Attendance";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckAttendance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDispose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.DataGridView dgvCheckAttendance;
        public System.Windows.Forms.Label lblname;
        public System.Windows.Forms.Label lblView;
    }
}