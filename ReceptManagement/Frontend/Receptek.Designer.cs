namespace Frontend
{
    partial class Receptek
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            getToolStripMenuItem = new ToolStripMenuItem();
            postToolStripMenuItem = new ToolStripMenuItem();
            putToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            listView1 = new ListView();
            PatientName = new ColumnHeader();
            PrescriptionText = new ColumnHeader();
            PrescribedDate = new ColumnHeader();
            PrescriptionId = new ColumnHeader();
            btnUjRecept = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { getToolStripMenuItem, postToolStripMenuItem, putToolStripMenuItem, deleteToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // getToolStripMenuItem
            // 
            getToolStripMenuItem.Name = "getToolStripMenuItem";
            getToolStripMenuItem.Size = new Size(39, 20);
            getToolStripMenuItem.Text = "GET";
            getToolStripMenuItem.Click += getToolStripMenuItem_Click;
            // 
            // postToolStripMenuItem
            // 
            postToolStripMenuItem.Name = "postToolStripMenuItem";
            postToolStripMenuItem.Size = new Size(47, 20);
            postToolStripMenuItem.Text = "POST";
            postToolStripMenuItem.Click += postToolStripMenuItem_Click;
            // 
            // putToolStripMenuItem
            // 
            putToolStripMenuItem.Name = "putToolStripMenuItem";
            putToolStripMenuItem.Size = new Size(40, 20);
            putToolStripMenuItem.Text = "PUT";
            putToolStripMenuItem.Click += putToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(57, 20);
            deleteToolStripMenuItem.Text = "DELETE";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { PatientName, PrescriptionText, PrescribedDate, PrescriptionId });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(0, 27);
            listView1.Name = "listView1";
            listView1.Size = new Size(796, 334);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // PatientName
            // 
            PatientName.Text = "Páciens neve";
            PatientName.Width = 125;
            // 
            // PrescriptionText
            // 
            PrescriptionText.Text = "Recept szövege";
            PrescriptionText.Width = 350;
            // 
            // PrescribedDate
            // 
            PrescribedDate.Text = "Recept felírásának ideje";
            PrescribedDate.Width = 140;
            // 
            // PrescriptionId
            // 
            PrescriptionId.Text = "PrescriptionId";
            PrescriptionId.Width = 0;
            // 
            // btnUjRecept
            // 
            btnUjRecept.Location = new Point(12, 378);
            btnUjRecept.Name = "btnUjRecept";
            btnUjRecept.Size = new Size(75, 43);
            btnUjRecept.TabIndex = 2;
            btnUjRecept.Text = "Új recept felírása";
            btnUjRecept.UseVisualStyleBackColor = true;
            btnUjRecept.Click += btnUjRecept_Click;
            // 
            // Receptek
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUjRecept);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Receptek";
            Text = "Pácienseknek felírt receptek";
            Load += Receptek_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem getToolStripMenuItem;
        private ToolStripMenuItem postToolStripMenuItem;
        private ToolStripMenuItem putToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ListView listView1;
        private ColumnHeader PatientName;
        private ColumnHeader PrescriptionText;
        private ColumnHeader PrescribedDate;
        private Button btnUjRecept;
        private ColumnHeader PrescriptionId;
    }
}