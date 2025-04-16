namespace MarketSatis1
{
    partial class KasiyerSayfa
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnSatısIslemleri = new Button();
            label1 = new Label();
            lstUrunler = new ListBox();
            tabPage2 = new TabPage();
            btnEkle = new Button();
            button2 = new Button();
            numUrunAdedi = new NumericUpDown();
            cmbUrunTanimi = new ComboBox();
            txtUrunAdi = new TextBox();
            txtUrunKodu = new TextBox();
            txtUrunFiyati = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tabPage3 = new TabPage();
            btnGuncelle = new Button();
            button4 = new Button();
            numEklenecekAdet = new NumericUpDown();
            txtUrunKod = new TextBox();
            label8 = new Label();
            label7 = new Label();
            tabPage4 = new TabPage();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label10 = new Label();
            label9 = new Label();
            tabPage5 = new TabPage();
            btnKasiyerEkle = new Button();
            txtKasiyerNo = new TextBox();
            txtKasiyerSoyadi = new TextBox();
            txtKasiyerAdi = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numUrunAdedi).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEklenecekAdet).BeginInit();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(700, 326);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnSatısIslemleri);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(lstUrunler);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new Size(692, 298);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ürün Kataloğu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSatısIslemleri
            // 
            btnSatısIslemleri.Location = new Point(286, 248);
            btnSatısIslemleri.Name = "btnSatısIslemleri";
            btnSatısIslemleri.Size = new Size(132, 39);
            btnSatısIslemleri.TabIndex = 2;
            btnSatısIslemleri.Text = "Satış İşlemleri";
            btnSatısIslemleri.UseVisualStyleBackColor = true;
            btnSatısIslemleri.Click += btnSatısIslemleri_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 25);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 1;
            label1.Text = "Ürün Kataloğu";
            label1.Click += label1_Click;
            // 
            // lstUrunler
            // 
            lstUrunler.FormattingEnabled = true;
            lstUrunler.ItemHeight = 15;
            lstUrunler.Location = new Point(8, 43);
            lstUrunler.Name = "lstUrunler";
            lstUrunler.Size = new Size(255, 244);
            lstUrunler.TabIndex = 0;
            lstUrunler.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnEkle);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(numUrunAdedi);
            tabPage2.Controls.Add(cmbUrunTanimi);
            tabPage2.Controls.Add(txtUrunAdi);
            tabPage2.Controls.Add(txtUrunKodu);
            tabPage2.Controls.Add(txtUrunFiyati);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new Size(692, 298);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ürün Ekle";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(197, 260);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(75, 32);
            btnEkle.TabIndex = 6;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // button2
            // 
            button2.Location = new Point(410, 260);
            button2.Name = "button2";
            button2.Size = new Size(168, 32);
            button2.TabIndex = 7;
            button2.Text = "Hesap Defterini Görüntüle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numUrunAdedi
            // 
            numUrunAdedi.Location = new Point(152, 228);
            numUrunAdedi.Name = "numUrunAdedi";
            numUrunAdedi.Size = new Size(120, 23);
            numUrunAdedi.TabIndex = 5;
            // 
            // cmbUrunTanimi
            // 
            cmbUrunTanimi.FormattingEnabled = true;
            cmbUrunTanimi.Items.AddRange(new object[] { "Gıda", "Bakım", "Elektronik" });
            cmbUrunTanimi.Location = new Point(151, 85);
            cmbUrunTanimi.Name = "cmbUrunTanimi";
            cmbUrunTanimi.Size = new Size(121, 23);
            cmbUrunTanimi.TabIndex = 2;
            // 
            // txtUrunAdi
            // 
            txtUrunAdi.Location = new Point(151, 131);
            txtUrunAdi.Name = "txtUrunAdi";
            txtUrunAdi.Size = new Size(121, 23);
            txtUrunAdi.TabIndex = 3;
            // 
            // txtUrunKodu
            // 
            txtUrunKodu.Location = new Point(151, 33);
            txtUrunKodu.Name = "txtUrunKodu";
            txtUrunKodu.Size = new Size(121, 23);
            txtUrunKodu.TabIndex = 1;
            txtUrunKodu.TextChanged += txtUrunKodu_TextChanged;
            // 
            // txtUrunFiyati
            // 
            txtUrunFiyati.Location = new Point(151, 176);
            txtUrunFiyati.Name = "txtUrunFiyati";
            txtUrunFiyati.Size = new Size(121, 23);
            txtUrunFiyati.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(62, 230);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 9;
            label6.Text = "Ürün Adedi :";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(62, 179);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 0;
            label5.Text = "Ürün Fiyatı :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 134);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 0;
            label4.Text = "Ürün Adı :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 88);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 0;
            label3.Text = "Ürün Tanımı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 36);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 0;
            label2.Text = "Ürün Kodu :";
            label2.Click += label2_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnGuncelle);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(numEklenecekAdet);
            tabPage3.Controls.Add(txtUrunKod);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(label7);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(692, 298);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Ürün Güncelle";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(296, 135);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(85, 32);
            btnGuncelle.TabIndex = 5;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // button4
            // 
            button4.Location = new Point(223, 193);
            button4.Name = "button4";
            button4.Size = new Size(158, 34);
            button4.TabIndex = 4;
            button4.Text = "Hesap Defterini Görüntüle";
            button4.UseVisualStyleBackColor = true;
            // 
            // numEklenecekAdet
            // 
            numEklenecekAdet.Location = new Point(261, 81);
            numEklenecekAdet.Name = "numEklenecekAdet";
            numEklenecekAdet.Size = new Size(120, 23);
            numEklenecekAdet.TabIndex = 3;
            // 
            // txtUrunKod
            // 
            txtUrunKod.Location = new Point(258, 32);
            txtUrunKod.Name = "txtUrunKod";
            txtUrunKod.Size = new Size(123, 23);
            txtUrunKod.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(124, 83);
            label8.Name = "label8";
            label8.Size = new Size(128, 15);
            label8.TabIndex = 1;
            label8.Text = "Eklenecek Ürün Adedi :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(124, 35);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 0;
            label7.Text = "Ürün Kodu :";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(textBox6);
            tabPage4.Controls.Add(textBox5);
            tabPage4.Controls.Add(label10);
            tabPage4.Controls.Add(label9);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(692, 298);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Hesap Defteri";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(276, 82);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(276, 30);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(144, 87);
            label10.Name = "label10";
            label10.Size = new Size(112, 15);
            label10.TabIndex = 1;
            label10.Text = "Toplam Satış Sayısı :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(144, 32);
            label9.Name = "label9";
            label9.Size = new Size(116, 15);
            label9.TabIndex = 0;
            label9.Text = "Stoktaki Ürün Sayısı :";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(btnKasiyerEkle);
            tabPage5.Controls.Add(txtKasiyerNo);
            tabPage5.Controls.Add(txtKasiyerSoyadi);
            tabPage5.Controls.Add(txtKasiyerAdi);
            tabPage5.Controls.Add(label13);
            tabPage5.Controls.Add(label12);
            tabPage5.Controls.Add(label11);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(692, 298);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Kasiyer Ekle";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnKasiyerEkle
            // 
            btnKasiyerEkle.Location = new Point(243, 188);
            btnKasiyerEkle.Name = "btnKasiyerEkle";
            btnKasiyerEkle.Size = new Size(87, 33);
            btnKasiyerEkle.TabIndex = 6;
            btnKasiyerEkle.Text = "Ekle";
            btnKasiyerEkle.UseVisualStyleBackColor = true;
            btnKasiyerEkle.Click += btnKasiyerEkle_Click;
            // 
            // txtKasiyerNo
            // 
            txtKasiyerNo.Location = new Point(211, 128);
            txtKasiyerNo.Name = "txtKasiyerNo";
            txtKasiyerNo.Size = new Size(119, 23);
            txtKasiyerNo.TabIndex = 5;
            // 
            // txtKasiyerSoyadi
            // 
            txtKasiyerSoyadi.Location = new Point(211, 78);
            txtKasiyerSoyadi.Name = "txtKasiyerSoyadi";
            txtKasiyerSoyadi.Size = new Size(119, 23);
            txtKasiyerSoyadi.TabIndex = 4;
            // 
            // txtKasiyerAdi
            // 
            txtKasiyerAdi.Location = new Point(211, 35);
            txtKasiyerAdi.Name = "txtKasiyerAdi";
            txtKasiyerAdi.Size = new Size(119, 23);
            txtKasiyerAdi.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(111, 131);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 2;
            label13.Text = "Kasiyer No:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(111, 81);
            label12.Name = "label12";
            label12.Size = new Size(88, 15);
            label12.TabIndex = 1;
            label12.Text = "Kasiyer Soyadı :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(111, 38);
            label11.Name = "label11";
            label11.Size = new Size(71, 15);
            label11.TabIndex = 0;
            label11.Text = "Kasiyer Adı :";
            // 
            // KasiyerSayfa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "KasiyerSayfa";
            Text = "KasiyerSayfa";
            Load += KasiyerSayfa_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numUrunAdedi).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEklenecekAdet).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Label label1;
        private ListBox lstUrunler;
        private Button btnSatısIslemleri;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnEkle;
        private Button button2;
        private NumericUpDown numUrunAdedi;
        private ComboBox cmbUrunTanimi;
        private TextBox txtUrunAdi;
        private TextBox txtUrunKodu;
        private TextBox txtUrunFiyati;
        private Button button5;
        private Button button4;
        private NumericUpDown numEklenecekAdet;
        private TextBox txtUrunKod;
        private Label label8;
        private Label label7;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label10;
        private Label label9;
        private Label label13;
        private Label label12;
        private Label label11;
        private Button btnKasiyerEkle;
        private TextBox txtKasiyerNo;
        private TextBox txtKasiyerSoyadi;
        private TextBox txtKasiyerAdi;
        private Button btnGuncelle;
    }
}