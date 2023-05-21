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
            btnKereses = new Button();
            lbPaciensNeve = new Label();
            lbReceptSzovege = new Label();
            lbKiallitasDatum = new Label();
            tbNev = new TextBox();
            tbReceptSzovege = new TextBox();
            dtpDatum = new DateTimePicker();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { PatientName, PrescriptionText, PrescribedDate, PrescriptionId });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(760, 453);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // PatientName
            // 
            PatientName.Text = "Páciens neve";
            PatientName.Width = 150;
            // 
            // PrescriptionText
            // 
            PrescriptionText.Text = "Recept szövege";
            PrescriptionText.Width = 400;
            // 
            // PrescribedDate
            // 
            PrescribedDate.Text = "Recept kiállítás időpontja";
            PrescribedDate.Width = 150;
            // 
            // PrescriptionId
            // 
            PrescriptionId.Text = "PrescriptionId";
            PrescriptionId.Width = 0;
            // 
            // btnUjRecept
            // 
            btnUjRecept.Location = new Point(12, 490);
            btnUjRecept.Name = "btnUjRecept";
            btnUjRecept.Size = new Size(66, 43);
            btnUjRecept.TabIndex = 2;
            btnUjRecept.Text = "Új recept felírása";
            btnUjRecept.UseVisualStyleBackColor = true;
            btnUjRecept.Click += btnUjRecept_Click;
            // 
            // btnReceptekTorlese
            // 
            btnReceptekTorlese.Location = new Point(694, 491);
            btnReceptekTorlese.Name = "btnReceptekTorlese";
            btnReceptekTorlese.Size = new Size(78, 43);
            btnReceptekTorlese.TabIndex = 3;
            btnReceptekTorlese.Text = "Recept(ek) törlése";
            btnReceptekTorlese.UseVisualStyleBackColor = true;
            btnReceptekTorlese.Click += btnReceptekTorlese_Click;
            // 
            // btnReceptekFrissitese
            // 
            btnReceptekFrissitese.Location = new Point(630, 491);
            btnReceptekFrissitese.Name = "btnReceptekFrissitese";
            btnReceptekFrissitese.Size = new Size(64, 43);
            btnReceptekFrissitese.TabIndex = 4;
            btnReceptekFrissitese.Text = "Receptek frissítése";
            btnReceptekFrissitese.UseVisualStyleBackColor = true;
            btnReceptekFrissitese.Click += btnReceptekFrissitese_Click;
            // 
            // btnRegebbiReceptek
            // 
            btnRegebbiReceptek.Location = new Point(554, 491);
            btnRegebbiReceptek.Name = "btnRegebbiReceptek";
            btnRegebbiReceptek.Size = new Size(62, 43);
            btnRegebbiReceptek.TabIndex = 5;
            btnRegebbiReceptek.Text = "Régebbi receptek";
            btnRegebbiReceptek.UseVisualStyleBackColor = true;
            btnRegebbiReceptek.Click += btnRegebbiReceptek_Click;
            // 
            // btnUjabbReceptek
            // 
            btnUjabbReceptek.Location = new Point(493, 491);
            btnUjabbReceptek.Name = "btnUjabbReceptek";
            btnUjabbReceptek.Size = new Size(60, 43);
            btnUjabbReceptek.TabIndex = 6;
            btnUjabbReceptek.Text = "Újabb receptek";
            btnUjabbReceptek.UseVisualStyleBackColor = true;
            btnUjabbReceptek.Click += btnUjabbReceptek_Click;
            // 
            // btnKereses
            // 
            btnKereses.Location = new Point(399, 471);
            btnKereses.Name = "btnKereses";
            btnKereses.Size = new Size(59, 85);
            btnKereses.TabIndex = 7;
            btnKereses.Text = "Keresés";
            btnKereses.UseVisualStyleBackColor = true;
            btnKereses.Click += btnKereses_Click;
            // 
            // lbPaciensNeve
            // 
            lbPaciensNeve.AutoSize = true;
            lbPaciensNeve.Location = new Point(104, 474);
            lbPaciensNeve.Name = "lbPaciensNeve";
            lbPaciensNeve.Size = new Size(78, 15);
            lbPaciensNeve.TabIndex = 8;
            lbPaciensNeve.Text = "Páciens neve:";
            // 
            // lbReceptSzovege
            // 
            lbReceptSzovege.AutoSize = true;
            lbReceptSzovege.Location = new Point(92, 507);
            lbReceptSzovege.Name = "lbReceptSzovege";
            lbReceptSzovege.Size = new Size(91, 15);
            lbReceptSzovege.TabIndex = 9;
            lbReceptSzovege.Text = "Recept szövege:";
            // 
            // lbKiallitasDatum
            // 
            lbKiallitasDatum.AutoSize = true;
            lbKiallitasDatum.Location = new Point(92, 538);
            lbKiallitasDatum.Name = "lbKiallitasDatum";
            lbKiallitasDatum.Size = new Size(94, 15);
            lbKiallitasDatum.TabIndex = 10;
            lbKiallitasDatum.Text = "Kiállítás dátuma:";
            // 
            // tbNev
            // 
            tbNev.Location = new Point(188, 471);
            tbNev.Name = "tbNev";
            tbNev.Size = new Size(200, 23);
            tbNev.TabIndex = 11;
            // 
            // tbReceptSzovege
            // 
            tbReceptSzovege.Location = new Point(188, 502);
            tbReceptSzovege.Name = "tbReceptSzovege";
            tbReceptSzovege.Size = new Size(200, 23);
            tbReceptSzovege.TabIndex = 12;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(188, 533);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(200, 23);
            dtpDatum.TabIndex = 13;
            // 
            // Receptek
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(dtpDatum);
            Controls.Add(tbReceptSzovege);
            Controls.Add(tbNev);
            Controls.Add(lbKiallitasDatum);
            Controls.Add(lbReceptSzovege);
            Controls.Add(lbPaciensNeve);
            Controls.Add(btnKereses);
            Controls.Add(btnUjabbReceptek);
            Controls.Add(btnRegebbiReceptek);
            Controls.Add(btnReceptekFrissitese);
            Controls.Add(btnReceptekTorlese);
            Controls.Add(btnUjRecept);
            Controls.Add(listView1);
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "Receptek";
            Text = "Pácienseknek felírt receptek";
            Load += Receptek_Load;
            ResumeLayout(false);
            PerformLayout();
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
        private Button btnKereses;
        private Label lbPaciensNeve;
        private Label lbReceptSzovege;
        private Label lbKiallitasDatum;
        private TextBox tbNev;
        private TextBox tbReceptSzovege;
        private DateTimePicker dtpDatum;
    }
}