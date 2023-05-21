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
            listView1 = new ListView();
            PatientName = new ColumnHeader();
            PrescriptionText = new ColumnHeader();
            PrescribedDate = new ColumnHeader();
            PrescriptionId = new ColumnHeader();
            btnUjRecept = new Button();
            btnReceptekTorlese = new Button();
            btnReceptekFrissitese = new Button();
            btnRegebbiReceptek = new Button();
            btnUjabbReceptek = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { PatientName, PrescriptionText, PrescribedDate, PrescriptionId });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(776, 349);
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
            btnUjRecept.Size = new Size(103, 43);
            btnUjRecept.TabIndex = 2;
            btnUjRecept.Text = "Új recept felírása";
            btnUjRecept.UseVisualStyleBackColor = true;
            btnUjRecept.Click += btnUjRecept_Click;
            // 
            // btnReceptekTorlese
            // 
            btnReceptekTorlese.Location = new Point(678, 378);
            btnReceptekTorlese.Name = "btnReceptekTorlese";
            btnReceptekTorlese.Size = new Size(110, 43);
            btnReceptekTorlese.TabIndex = 3;
            btnReceptekTorlese.Text = "Recept(ek) törlése";
            btnReceptekTorlese.UseVisualStyleBackColor = true;
            btnReceptekTorlese.Click += btnReceptekTorlese_Click;
            // 
            // btnReceptekFrissitese
            // 
            btnReceptekFrissitese.Location = new Point(553, 378);
            btnReceptekFrissitese.Name = "btnReceptekFrissitese";
            btnReceptekFrissitese.Size = new Size(119, 43);
            btnReceptekFrissitese.TabIndex = 4;
            btnReceptekFrissitese.Text = "Receptek frissítése";
            btnReceptekFrissitese.UseVisualStyleBackColor = true;
            btnReceptekFrissitese.Click += btnReceptekFrissitese_Click;
            // 
            // btnRegebbiReceptek
            // 
            btnRegebbiReceptek.Location = new Point(381, 378);
            btnRegebbiReceptek.Name = "btnRegebbiReceptek";
            btnRegebbiReceptek.Size = new Size(97, 43);
            btnRegebbiReceptek.TabIndex = 5;
            btnRegebbiReceptek.Text = "Régebbi receptek";
            btnRegebbiReceptek.UseVisualStyleBackColor = true;
            btnRegebbiReceptek.Click += btnRegebbiReceptek_Click;
            // 
            // btnUjabbReceptek
            // 
            btnUjabbReceptek.Location = new Point(278, 378);
            btnUjabbReceptek.Name = "btnUjabbReceptek";
            btnUjabbReceptek.Size = new Size(97, 43);
            btnUjabbReceptek.TabIndex = 6;
            btnUjabbReceptek.Text = "Újabb receptek";
            btnUjabbReceptek.UseVisualStyleBackColor = true;
            btnUjabbReceptek.Click += btnUjabbReceptek_Click;
            // 
            // Receptek
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUjabbReceptek);
            Controls.Add(btnRegebbiReceptek);
            Controls.Add(btnReceptekFrissitese);
            Controls.Add(btnReceptekTorlese);
            Controls.Add(btnUjRecept);
            Controls.Add(listView1);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Receptek";
            Text = "Pácienseknek felírt receptek";
            Load += Receptek_Load;
            ResumeLayout(false);
        }

        #endregion
        private ListView listView1;
        private ColumnHeader PatientName;
        private ColumnHeader PrescriptionText;
        private ColumnHeader PrescribedDate;
        private Button btnUjRecept;
        private ColumnHeader PrescriptionId;
        private Button btnReceptekTorlese;
        private Button btnReceptekFrissitese;
        private Button btnRegebbiReceptek;
        private Button btnUjabbReceptek;
    }
}