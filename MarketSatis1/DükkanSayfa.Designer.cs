namespace MarketSatis1
{
    partial class DükkanSayfa
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            lstUrunler = new ListBox();
            label2 = new Label();
            label3 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tbToolStripMenuItem = new ToolStripMenuItem();
            txtTutar = new TextBox();
            numAdet = new NumericUpDown();
            lstSepet = new ListBox();
            label4 = new Label();
            label5 = new Label();
            txtToplamTutar = new TextBox();
            label6 = new Label();
            txtIndirimliTutar = new TextBox();
            btnToplamTutarHesapla = new Button();
            btnHesapla = new Button();
            btnSepeteEkle = new Button();
            label7 = new Label();
            rbNakit = new RadioButton();
            rbKrediKarti = new RadioButton();
            btnDukkanIslemleri = new Button();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAdet).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(25, 14);
            label1.Name = "label1";
            label1.Size = new Size(98, 28);
            label1.TabIndex = 1;
            label1.Text = "ÜRÜNLER";
            label1.Click += label1_Click;
            // 
            // lstUrunler
            // 
            lstUrunler.FormattingEnabled = true;
            lstUrunler.ItemHeight = 15;
            lstUrunler.Location = new Point(25, 50);
            lstUrunler.Name = "lstUrunler";
            lstUrunler.Size = new Size(256, 229);
            lstUrunler.TabIndex = 2;
            lstUrunler.SelectedIndexChanged += Ürünler_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(20, 322);
            label2.Name = "label2";
            label2.Size = new Size(41, 19);
            label2.TabIndex = 4;
            label2.Text = "Adet:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(17, 371);
            label3.Name = "label3";
            label3.Size = new Size(44, 19);
            label3.TabIndex = 5;
            label3.Text = "Tutar:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tbToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(86, 26);
            // 
            // tbToolStripMenuItem
            // 
            tbToolStripMenuItem.Name = "tbToolStripMenuItem";
            tbToolStripMenuItem.Size = new Size(85, 22);
            tbToolStripMenuItem.Text = "tb";
            // 
            // txtTutar
            // 
            txtTutar.BackColor = Color.Black;
            txtTutar.BorderStyle = BorderStyle.None;
            txtTutar.Location = new Point(88, 388);
            txtTutar.Margin = new Padding(3, 2, 3, 2);
            txtTutar.Multiline = true;
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(54, 2);
            txtTutar.TabIndex = 6;
            // 
            // numAdet
            // 
            numAdet.Location = new Point(88, 318);
            numAdet.Margin = new Padding(3, 2, 3, 2);
            numAdet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAdet.Name = "numAdet";
            numAdet.Size = new Size(82, 23);
            numAdet.TabIndex = 7;
            numAdet.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lstSepet
            // 
            lstSepet.FormattingEnabled = true;
            lstSepet.ItemHeight = 15;
            lstSepet.Location = new Point(423, 67);
            lstSepet.Margin = new Padding(3, 2, 3, 2);
            lstSepet.Name = "lstSepet";
            lstSepet.Size = new Size(273, 154);
            lstSepet.TabIndex = 8;
            lstSepet.SelectedIndexChanged += Sepet_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(423, 41);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 9;
            label4.Text = "Sepet";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(407, 262);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 10;
            label5.Text = "Toplam Tutar :";
            // 
            // txtToplamTutar
            // 
            txtToplamTutar.BackColor = Color.Black;
            txtToplamTutar.BorderStyle = BorderStyle.None;
            txtToplamTutar.Location = new Point(516, 275);
            txtToplamTutar.Margin = new Padding(3, 2, 3, 2);
            txtToplamTutar.Multiline = true;
            txtToplamTutar.Name = "txtToplamTutar";
            txtToplamTutar.Size = new Size(54, 2);
            txtToplamTutar.TabIndex = 11;
            txtToplamTutar.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(407, 359);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 12;
            label6.Text = "İndirimli Tutar :";
            // 
            // txtIndirimliTutar
            // 
            txtIndirimliTutar.BackColor = Color.Black;
            txtIndirimliTutar.BorderStyle = BorderStyle.None;
            txtIndirimliTutar.Location = new Point(516, 371);
            txtIndirimliTutar.Margin = new Padding(3, 2, 3, 2);
            txtIndirimliTutar.Multiline = true;
            txtIndirimliTutar.Name = "txtIndirimliTutar";
            txtIndirimliTutar.Size = new Size(54, 2);
            txtIndirimliTutar.TabIndex = 13;
            // 
            // btnToplamTutarHesapla
            // 
            btnToplamTutarHesapla.BackColor = Color.White;
            btnToplamTutarHesapla.FlatStyle = FlatStyle.Flat;
            btnToplamTutarHesapla.Location = new Point(612, 239);
            btnToplamTutarHesapla.Margin = new Padding(3, 2, 3, 2);
            btnToplamTutarHesapla.Name = "btnToplamTutarHesapla";
            btnToplamTutarHesapla.Size = new Size(176, 50);
            btnToplamTutarHesapla.TabIndex = 14;
            btnToplamTutarHesapla.Text = "Toplam Tutar Hesapla";
            btnToplamTutarHesapla.UseVisualStyleBackColor = false;
            btnToplamTutarHesapla.Click += btnToplamTutarHesapla_Click;
            // 
            // btnHesapla
            // 
            btnHesapla.BackColor = Color.White;
            btnHesapla.FlatStyle = FlatStyle.Popup;
            btnHesapla.Location = new Point(209, 312);
            btnHesapla.Margin = new Padding(3, 2, 3, 2);
            btnHesapla.Name = "btnHesapla";
            btnHesapla.Size = new Size(98, 32);
            btnHesapla.TabIndex = 15;
            btnHesapla.Text = "Hesapla";
            btnHesapla.UseVisualStyleBackColor = false;
            btnHesapla.Click += btnHesapla_Click;
            // 
            // btnSepeteEkle
            // 
            btnSepeteEkle.BackColor = Color.White;
            btnSepeteEkle.FlatStyle = FlatStyle.Flat;
            btnSepeteEkle.Location = new Point(209, 363);
            btnSepeteEkle.Margin = new Padding(3, 2, 3, 2);
            btnSepeteEkle.Name = "btnSepeteEkle";
            btnSepeteEkle.Size = new Size(98, 35);
            btnSepeteEkle.TabIndex = 16;
            btnSepeteEkle.Text = "Sepete Ekle";
            btnSepeteEkle.UseVisualStyleBackColor = false;
            btnSepeteEkle.Click += btnSepeteEkle_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(335, 314);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 17;
            label7.Text = "Ödeme Yöntemi :";
            // 
            // rbNakit
            // 
            rbNakit.AutoSize = true;
            rbNakit.Location = new Point(465, 310);
            rbNakit.Margin = new Padding(3, 2, 3, 2);
            rbNakit.Name = "rbNakit";
            rbNakit.Size = new Size(53, 19);
            rbNakit.TabIndex = 18;
            rbNakit.TabStop = true;
            rbNakit.Text = "Nakit";
            rbNakit.UseVisualStyleBackColor = true;
            rbNakit.CheckedChanged += rbNakit_CheckedChanged_1;
            // 
            // rbKrediKarti
            // 
            rbKrediKarti.AutoSize = true;
            rbKrediKarti.Location = new Point(536, 310);
            rbKrediKarti.Margin = new Padding(3, 2, 3, 2);
            rbKrediKarti.Name = "rbKrediKarti";
            rbKrediKarti.Size = new Size(79, 19);
            rbKrediKarti.TabIndex = 19;
            rbKrediKarti.TabStop = true;
            rbKrediKarti.Text = "Kredi Kartı";
            rbKrediKarti.UseVisualStyleBackColor = true;
            rbKrediKarti.CheckedChanged += rbKrediKarti_CheckedChanged_1;
            // 
            // btnDukkanIslemleri
            // 
            btnDukkanIslemleri.BackColor = Color.White;
            btnDukkanIslemleri.FlatStyle = FlatStyle.Flat;
            btnDukkanIslemleri.Location = new Point(652, 393);
            btnDukkanIslemleri.Margin = new Padding(3, 2, 3, 2);
            btnDukkanIslemleri.Name = "btnDukkanIslemleri";
            btnDukkanIslemleri.Size = new Size(136, 46);
            btnDukkanIslemleri.TabIndex = 21;
            btnDukkanIslemleri.Text = "Dükkan İşlemleri";
            btnDukkanIslemleri.UseVisualStyleBackColor = false;
            btnDukkanIslemleri.Click += btnDukkanIslemleri_Click;
            // 
            // DükkanSayfa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDukkanIslemleri);
            Controls.Add(rbKrediKarti);
            Controls.Add(rbNakit);
            Controls.Add(label7);
            Controls.Add(btnSepeteEkle);
            Controls.Add(btnHesapla);
            Controls.Add(btnToplamTutarHesapla);
            Controls.Add(txtIndirimliTutar);
            Controls.Add(label6);
            Controls.Add(txtToplamTutar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lstSepet);
            Controls.Add(numAdet);
            Controls.Add(txtTutar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lstUrunler);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "DükkanSayfa";
            Text = "DükkanSayfa";
            Load += DükkanSayfa_Load;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numAdet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListBox lstUrunler;
        private Label label2;
        private Label label3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tbToolStripMenuItem;
        private TextBox txtTutar;
        private NumericUpDown numAdet;
        private ListBox lstSepet;
        private Label label4;
        private Label label5;
        private TextBox txtToplamTutar;
        private Label label6;
        private TextBox txtIndirimliTutar;
        private Button btnToplamTutarHesapla;
        private Button btnHesapla;
        private Button btnSepeteEkle;
        private Label label7;
        private RadioButton rbNakit;
        private RadioButton rbKrediKarti;
        private Button buttobn5;
        private Button btnSiparisiOnayla;
        private Button btnDukkanIslemleri;
    }
}