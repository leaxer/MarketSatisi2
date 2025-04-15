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
            Ürünler = new ListBox();
            label2 = new Label();
            label3 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tbToolStripMenuItem = new ToolStripMenuItem();
            textBox2 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            Sepet = new ListBox();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label7 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button4 = new Button();
            button5 = new Button();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            // Ürünler
            // 
            Ürünler.FormattingEnabled = true;
            Ürünler.Location = new Point(29, 67);
            Ürünler.Margin = new Padding(3, 4, 3, 4);
            Ürünler.Name = "Ürünler";
            Ürünler.Size = new Size(236, 304);
            Ürünler.TabIndex = 2;
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
            // textBox2
            // 
            textBox2.Location = new Point(79, 491);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(112, 27);
            textBox2.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(81, 425);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(94, 27);
            numericUpDown1.TabIndex = 7;
            // 
            // Sepet
            // 
            Sepet.FormattingEnabled = true;
            Sepet.Location = new Point(483, 89);
            Sepet.Name = "Sepet";
            Sepet.Size = new Size(311, 204);
            Sepet.TabIndex = 8;
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
            label5.Location = new Point(541, 425);
            label5.Name = "label5";
            label5.Size = new Size(104, 20);
            label5.TabIndex = 10;
            label5.Text = "Toplam Tutar :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(661, 418);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(113, 27);
            textBox1.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(541, 469);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 12;
            label6.Text = "İndirimli Tutar :";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(661, 462);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(113, 27);
            textBox3.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(661, 326);
            button1.Name = "button1";
            button1.Size = new Size(201, 66);
            button1.TabIndex = 14;
            button1.Text = "Toplam Tutar Hesapla";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(239, 425);
            button2.Name = "button2";
            button2.Size = new Size(112, 43);
            button2.TabIndex = 15;
            button2.Text = "Hesapla";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(239, 491);
            button3.Name = "button3";
            button3.Size = new Size(112, 47);
            button3.TabIndex = 16;
            button3.Text = "Sepete Ekle";
            button3.UseVisualStyleBackColor = true;
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
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(465, 347);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(65, 24);
            radioButton1.TabIndex = 18;
            radioButton1.TabStop = true;
            radioButton1.Text = "Nakit";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(541, 347);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(100, 24);
            radioButton2.TabIndex = 19;
            radioButton2.TabStop = true;
            radioButton2.Text = "Kredi Kartı";
            radioButton2.UseVisualStyleBackColor = true;
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
            // button5
            // 
            button5.Location = new Point(483, 527);
            button5.Name = "button5";
            button5.Size = new Size(155, 62);
            button5.TabIndex = 21;
            button5.Text = "Dükkan İşlemleri";
            button5.UseVisualStyleBackColor = true;
            // 
            // DükkanSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(914, 600);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(Sepet);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Ürünler);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            Margin = new Padding(3, 4, 3, 4);
            Name = "DükkanSayfa";
            Text = "DükkanSayfa";
            Load += DükkanSayfa_Load_1;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListBox Ürünler;
        private Label label2;
        private Label label3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tbToolStripMenuItem;
        private TextBox textBox2;
        private NumericUpDown numericUpDown1;
        private ListBox Sepet;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private Label label6;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label7;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button4;
        private Button button5;
    }
}