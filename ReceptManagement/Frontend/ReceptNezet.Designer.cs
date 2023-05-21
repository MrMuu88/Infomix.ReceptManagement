namespace Frontend
{
    partial class ReceptNezet
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
            btnOk = new Button();
            btnMegsem = new Button();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(148, 158);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(96, 23);
            btnOk.TabIndex = 0;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnMegsem
            // 
            btnMegsem.Location = new Point(275, 158);
            btnMegsem.Name = "btnMegsem";
            btnMegsem.Size = new Size(96, 23);
            btnMegsem.TabIndex = 1;
            btnMegsem.Text = "Mégsem";
            btnMegsem.UseVisualStyleBackColor = true;
            btnMegsem.Click += btnMegsem_Click;
            // 
            // ReceptNezet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 193);
            Controls.Add(btnMegsem);
            Controls.Add(btnOk);
            Name = "ReceptNezet";
            Text = "ReceptNezet";
            Load += ReceptNezet_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOk;
        private Button btnMegsem;
    }
}