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
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tbToolStripMenuItem = new ToolStripMenuItem();
            textBox2 = new TextBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(98, 28);
            label1.TabIndex = 1;
            label1.Text = "ÜRÜNLER";
            label1.Click += label1_Click;
            // 
            // Ürünler
            // 
            Ürünler.FormattingEnabled = true;
            Ürünler.ItemHeight = 15;
            Ürünler.Location = new Point(28, 65);
            Ürünler.Name = "Ürünler";
            Ürünler.Size = new Size(207, 229);
            Ürünler.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(69, 318);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(85, 23);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(22, 322);
            label2.Name = "label2";
            label2.Size = new Size(41, 19);
            label2.TabIndex = 4;
            label2.Text = "Adet:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(22, 371);
            label3.Name = "label3";
            label3.Size = new Size(44, 19);
            label3.TabIndex = 5;
            label3.Text = "Tutar:";
            // 
            // contextMenuStrip1
            // 
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
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(69, 373);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(85, 16);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged_1;
            // 
            // DükkanSayfa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(Ürünler);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "DükkanSayfa";
            Text = "DükkanSayfa";
            Load += DükkanSayfa_Load_1;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListBox Ürünler;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tbToolStripMenuItem;
        private TextBox textBox2;
    }
}