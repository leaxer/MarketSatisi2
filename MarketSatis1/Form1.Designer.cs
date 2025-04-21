namespace MarketSatis1
{
    partial class Form1
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
            txtKasiyerAdi = new TextBox();
            txtKasiyerNo = new TextBox();
            btnGirisYap = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtKasiyerAdi
            // 
            txtKasiyerAdi.Location = new Point(296, 123);
            txtKasiyerAdi.Name = "txtKasiyerAdi";
            txtKasiyerAdi.PlaceholderText = "Adınızı giriniz.";
            txtKasiyerAdi.Size = new Size(181, 27);
            txtKasiyerAdi.TabIndex = 0;
            txtKasiyerAdi.TextChanged += textBox1_TextChanged;
            // 
            // txtKasiyerNo
            // 
            txtKasiyerNo.Location = new Point(296, 197);
            txtKasiyerNo.MaxLength = 11;
            txtKasiyerNo.Name = "txtKasiyerNo";
            txtKasiyerNo.PlaceholderText = "Kasiyer no giriniz.";
            txtKasiyerNo.Size = new Size(181, 27);
            txtKasiyerNo.TabIndex = 1;
            // 
            // btnGirisYap
            // 
            btnGirisYap.BackColor = Color.LightSteelBlue;
            btnGirisYap.Cursor = Cursors.Hand;
            btnGirisYap.FlatStyle = FlatStyle.Flat;
            btnGirisYap.Location = new Point(296, 254);
            btnGirisYap.Name = "btnGirisYap";
            btnGirisYap.Size = new Size(181, 37);
            btnGirisYap.TabIndex = 2;
            btnGirisYap.Text = "Giriş Yap";
            btnGirisYap.UseVisualStyleBackColor = false;
            btnGirisYap.Click += btnGirisYap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(296, 100);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 3;
            label1.Text = "Kasiyer Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(296, 174);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 4;
            label2.Text = "Kasiyer No:";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(800, 451);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGirisYap);
            Controls.Add(txtKasiyerNo);
            Controls.Add(txtKasiyerAdi);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKasiyerAdi;
        private TextBox txtKasiyerNo;
        private Button btnGirisYap;
        private Label label1;
        private Label label2;
    }
}
