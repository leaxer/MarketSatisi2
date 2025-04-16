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
            button1 = new Button();
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
            button5 = new Button();
            button4 = new Button();
            numericUpDown2 = new NumericUpDown();
            textBox4 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            tabPage4 = new TabPage();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label10 = new Label();
            label9 = new Label();
            tabPage5 = new TabPage();
            button6 = new Button();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numUrunAdedi).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
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
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 435);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(lstUrunler);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(792, 402);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ürün Kataloğu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(339, 342);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(151, 52);
            button1.TabIndex = 2;
            button1.Text = "Satış İşlemlerine Geç";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 24);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 1;
            label1.Text = "Ürün Kataloğu";
            label1.Click += label1_Click;
            // 
            // lstUrunler
            // 
            lstUrunler.AccessibleName = "UrunlerListele";
            lstUrunler.FormattingEnabled = true;
            lstUrunler.Location = new Point(21, 70);
            lstUrunler.Margin = new Padding(3, 4, 3, 4);
            lstUrunler.Name = "lstUrunler";
            lstUrunler.Size = new Size(241, 324);
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
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(792, 402);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ürün Ekle";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(225, 347);
            btnEkle.Margin = new Padding(3, 4, 3, 4);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(86, 43);
            btnEkle.TabIndex = 11;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // button2
            // 
            button2.Location = new Point(470, 347);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(192, 43);
            button2.TabIndex = 10;
            button2.Text = "Hesap Defterini Görüntüle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // numUrunAdedi
            // 
            numUrunAdedi.Location = new Point(174, 304);
            numUrunAdedi.Margin = new Padding(3, 4, 3, 4);
            numUrunAdedi.Name = "numUrunAdedi";
            numUrunAdedi.Size = new Size(137, 27);
            numUrunAdedi.TabIndex = 9;
            // 
            // cmbUrunTanimi
            // 
            cmbUrunTanimi.FormattingEnabled = true;
            cmbUrunTanimi.Location = new Point(173, 113);
            cmbUrunTanimi.Margin = new Padding(3, 4, 3, 4);
            cmbUrunTanimi.Name = "cmbUrunTanimi";
            cmbUrunTanimi.Size = new Size(138, 28);
            cmbUrunTanimi.TabIndex = 8;
            // 
            // txtUrunAdi
            // 
            txtUrunAdi.Location = new Point(173, 175);
            txtUrunAdi.Margin = new Padding(3, 4, 3, 4);
            txtUrunAdi.Name = "txtUrunAdi";
            txtUrunAdi.Size = new Size(138, 27);
            txtUrunAdi.TabIndex = 7;
            // 
            // txtUrunKodu
            // 
            txtUrunKodu.Location = new Point(173, 44);
            txtUrunKodu.Margin = new Padding(3, 4, 3, 4);
            txtUrunKodu.Name = "txtUrunKodu";
            txtUrunKodu.Size = new Size(138, 27);
            txtUrunKodu.TabIndex = 6;
            // 
            // txtUrunFiyati
            // 
            txtUrunFiyati.Location = new Point(173, 235);
            txtUrunFiyati.Margin = new Padding(3, 4, 3, 4);
            txtUrunFiyati.Name = "txtUrunFiyati";
            txtUrunFiyati.Size = new Size(138, 27);
            txtUrunFiyati.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(71, 307);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 4;
            label6.Text = "Ürün Adedi :";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(71, 239);
            label5.Name = "label5";
            label5.Size = new Size(86, 20);
            label5.TabIndex = 3;
            label5.Text = "Ürün Fiyatı :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(71, 179);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 2;
            label4.Text = "Ürün Adı :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(71, 117);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 1;
            label3.Text = "Ürün Tanımı :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 48);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 0;
            label2.Text = "Ürün Kodu :";
            label2.Click += label2_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(numericUpDown2);
            tabPage3.Controls.Add(textBox4);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(label7);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(792, 402);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Ürün Güncelle";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(338, 180);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(97, 43);
            button5.TabIndex = 5;
            button5.Text = "Güncelle";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(255, 257);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(181, 45);
            button4.TabIndex = 4;
            button4.Text = "Hesap Defterini Görüntüle";
            button4.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(308, 111);
            numericUpDown2.Margin = new Padding(3, 4, 3, 4);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(137, 27);
            numericUpDown2.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(295, 43);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(140, 27);
            textBox4.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(142, 111);
            label8.Name = "label8";
            label8.Size = new Size(160, 20);
            label8.TabIndex = 1;
            label8.Text = "Eklenecek Ürün Adedi :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(142, 47);
            label7.Name = "label7";
            label7.Size = new Size(86, 20);
            label7.TabIndex = 0;
            label7.Text = "Ürün Kodu :";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(textBox6);
            tabPage4.Controls.Add(textBox5);
            tabPage4.Controls.Add(label10);
            tabPage4.Controls.Add(label9);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Margin = new Padding(3, 4, 3, 4);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(792, 402);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Hesap Defteri";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(316, 113);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(114, 27);
            textBox6.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(316, 43);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(114, 27);
            textBox5.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(165, 120);
            label10.Name = "label10";
            label10.Size = new Size(142, 20);
            label10.TabIndex = 1;
            label10.Text = "Toplam Satış Sayısı :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(165, 43);
            label9.Name = "label9";
            label9.Size = new Size(145, 20);
            label9.TabIndex = 0;
            label9.Text = "Stoktaki Ürün Sayısı :";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(button6);
            tabPage5.Controls.Add(textBox9);
            tabPage5.Controls.Add(textBox8);
            tabPage5.Controls.Add(textBox7);
            tabPage5.Controls.Add(label13);
            tabPage5.Controls.Add(label12);
            tabPage5.Controls.Add(label11);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Margin = new Padding(3, 4, 3, 4);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(792, 402);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Kasiyer Ekle";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(278, 251);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(99, 44);
            button6.TabIndex = 6;
            button6.Text = "Ekle";
            button6.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(241, 171);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(135, 27);
            textBox9.TabIndex = 5;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(241, 104);
            textBox8.Margin = new Padding(3, 4, 3, 4);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(135, 27);
            textBox8.TabIndex = 4;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(241, 47);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(135, 27);
            textBox7.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(127, 175);
            label13.Name = "label13";
            label13.Size = new Size(88, 20);
            label13.TabIndex = 2;
            label13.Text = "Sigorta No :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(127, 108);
            label12.Name = "label12";
            label12.Size = new Size(112, 20);
            label12.TabIndex = 1;
            label12.Text = "Kasiyer Soyadı :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(127, 51);
            label11.Name = "label11";
            label11.Size = new Size(90, 20);
            label11.TabIndex = 0;
            label11.Text = "Kasiyer Adı :";
            // 
            // KasiyerSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(tabControl1);
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
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
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
        private Button button1;
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
        private NumericUpDown numericUpDown2;
        private TextBox textBox4;
        private Label label8;
        private Label label7;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label10;
        private Label label9;
        private Label label13;
        private Label label12;
        private Label label11;
        private Button button6;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
    }
}