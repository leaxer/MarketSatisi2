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
            button4 = new Button();
            buttobn5 = new Button();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAdet).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(29, 18);
            label1.Name = "label1";
            label1.Size = new Size(123, 35);
            label1.TabIndex = 1;
            label1.Text = "ÜRÜNLER";
            label1.Click += label1_Click;
            // 
            // lstUrunler
            // 
            lstUrunler.FormattingEnabled = true;
            lstUrunler.Location = new Point(29, 67);
            lstUrunler.Margin = new Padding(3, 4, 3, 4);
            lstUrunler.Name = "lstUrunler";
            lstUrunler.Size = new Size(292, 304);
            lstUrunler.TabIndex = 2;
            lstUrunler.SelectedIndexChanged += Ürünler_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(25, 429);
            label2.Name = "label2";
            label2.Size = new Size(50, 23);
            label2.TabIndex = 4;
            label2.Text = "Adet:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(19, 495);
            label3.Name = "label3";
            label3.Size = new Size(54, 23);
            label3.TabIndex = 5;
            label3.Text = "Tutar:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { tbToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(93, 28);
            // 
            // tbToolStripMenuItem
            // 
            tbToolStripMenuItem.Name = "tbToolStripMenuItem";
            tbToolStripMenuItem.Size = new Size(92, 24);
            tbToolStripMenuItem.Text = "tb";
            // 
            // txtTutar
            // 
            txtTutar.Location = new Point(79, 491);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(112, 27);
            txtTutar.TabIndex = 6;
            // 
            // numAdet
            // 
            numAdet.Location = new Point(81, 425);
            numAdet.Name = "numAdet";
            numAdet.Size = new Size(94, 27);
            numAdet.TabIndex = 7;
            numAdet.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lstSepet
            // 
            lstSepet.FormattingEnabled = true;
            lstSepet.Location = new Point(483, 89);
            lstSepet.Name = "lstSepet";
            lstSepet.Size = new Size(311, 204);
            lstSepet.TabIndex = 8;
            lstSepet.SelectedIndexChanged += Sepet_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(483, 55);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 9;
            label4.Text = "Sepet";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(465, 421);
            label5.Name = "label5";
            label5.Size = new Size(104, 20);
            label5.TabIndex = 10;
            label5.Text = "Toplam Tutar :";
            // 
            // txtToplamTutar
            // 
            txtToplamTutar.Location = new Point(575, 418);
            txtToplamTutar.Name = "txtToplamTutar";
            txtToplamTutar.Size = new Size(113, 27);
            txtToplamTutar.TabIndex = 11;
            txtToplamTutar.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(465, 471);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 12;
            label6.Text = "İndirimli Tutar :";
            // 
            // txtIndirimliTutar
            // 
            txtIndirimliTutar.Location = new Point(580, 468);
            txtIndirimliTutar.Name = "txtIndirimliTutar";
            txtIndirimliTutar.Size = new Size(113, 27);
            txtIndirimliTutar.TabIndex = 13;
            // 
            // btnToplamTutarHesapla
            // 
            btnToplamTutarHesapla.Location = new Point(661, 326);
            btnToplamTutarHesapla.Name = "btnToplamTutarHesapla";
            btnToplamTutarHesapla.Size = new Size(201, 66);
            btnToplamTutarHesapla.TabIndex = 14;
            btnToplamTutarHesapla.Text = "Toplam Tutar Hesapla";
            btnToplamTutarHesapla.UseVisualStyleBackColor = true;
            btnToplamTutarHesapla.Click += btnToplamTutarHesapla_Click;
            // 
            // btnHesapla
            // 
            btnHesapla.Location = new Point(239, 416);
            btnHesapla.Name = "btnHesapla";
            btnHesapla.Size = new Size(112, 43);
            btnHesapla.TabIndex = 15;
            btnHesapla.Text = "Hesapla";
            btnHesapla.UseVisualStyleBackColor = true;
            btnHesapla.Click += btnHesapla_Click;
            // 
            // btnSepeteEkle
            // 
            btnSepeteEkle.Location = new Point(239, 471);
            btnSepeteEkle.Name = "btnSepeteEkle";
            btnSepeteEkle.Size = new Size(112, 47);
            btnSepeteEkle.TabIndex = 16;
            btnSepeteEkle.Text = "Sepete Ekle";
            btnSepeteEkle.UseVisualStyleBackColor = true;
            btnSepeteEkle.Click += btnSepeteEkle_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(327, 349);
            label7.Name = "label7";
            label7.Size = new Size(123, 20);
            label7.TabIndex = 17;
            label7.Text = "Ödeme Yöntemi :";
            // 
            // rbNakit
            // 
            rbNakit.AutoSize = true;
            rbNakit.Location = new Point(465, 347);
            rbNakit.Name = "rbNakit";
            rbNakit.Size = new Size(65, 24);
            rbNakit.TabIndex = 18;
            rbNakit.TabStop = true;
            rbNakit.Text = "Nakit";
            rbNakit.UseVisualStyleBackColor = true;
            rbNakit.CheckedChanged += rbNakit_CheckedChanged_1;
            // 
            // rbKrediKarti
            // 
            rbKrediKarti.AutoSize = true;
            rbKrediKarti.Location = new Point(541, 347);
            rbKrediKarti.Name = "rbKrediKarti";
            rbKrediKarti.Size = new Size(100, 24);
            rbKrediKarti.TabIndex = 19;
            rbKrediKarti.TabStop = true;
            rbKrediKarti.Text = "Kredi Kartı";
            rbKrediKarti.UseVisualStyleBackColor = true;
            rbKrediKarti.CheckedChanged += rbKrediKarti_CheckedChanged_1;
            // 
            // button4
            // 
            button4.Location = new Point(694, 527);
            button4.Name = "button4";
            button4.Size = new Size(168, 61);
            button4.TabIndex = 20;
            button4.Text = "Yeni Satış İşlemleri";
            button4.UseVisualStyleBackColor = true;
            // 
            // buttobn5
            // 
            buttobn5.Location = new Point(483, 527);
            buttobn5.Name = "buttobn5";
            buttobn5.Size = new Size(155, 62);
            buttobn5.TabIndex = 21;
            buttobn5.Text = "Dükkan İşlemleri";
            buttobn5.UseVisualStyleBackColor = true;
            buttobn5.Click += button5_Click;
            // 
            // DükkanSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(914, 600);
            Controls.Add(buttobn5);
            Controls.Add(button4);
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
            Margin = new Padding(3, 4, 3, 4);
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
        private Button button4;
        private Button buttobn5;
        private Button btnSiparisiOnayla;
    }
}