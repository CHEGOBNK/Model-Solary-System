namespace Курсовой
{
    partial class SolarSystem
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            treeView1 = new TreeView();
            label3 = new Label();
            trackBar1 = new TrackBar();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 800);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(749, 836);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 836);
            label2.Name = "label2";
            label2.Size = new Size(336, 25);
            label2.TabIndex = 2;
            label2.Text = "Анимация работает на протяжении...";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(820, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(689, 416);
            textBox1.TabIndex = 3;
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Location = new Point(829, 446);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(399, 364);
            treeView1.TabIndex = 4;
            treeView1.AfterCheck += treeView1_AfterCheck;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1246, 446);
            label3.Name = "label3";
            label3.Size = new Size(255, 25);
            label3.TabIndex = 5;
            label3.Text = "Скорость работы анимации";
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 50;
            trackBar1.Location = new Point(1276, 474);
            trackBar1.Maximum = 500;
            trackBar1.Minimum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.RightToLeft = RightToLeft.Yes;
            trackBar1.Size = new Size(194, 45);
            trackBar1.SmallChange = 10;
            trackBar1.TabIndex = 8;
            trackBar1.Value = 100;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(1260, 525);
            button1.Name = "button1";
            button1.Size = new Size(210, 63);
            button1.TabIndex = 9;
            button1.Text = "Случайное положение планет";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SolarSystem
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1513, 870);
            Controls.Add(button1);
            Controls.Add(trackBar1);
            Controls.Add(label3);
            Controls.Add(treeView1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "SolarSystem";
            Text = "Солнечная система";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TreeView treeView1;
        private Label label3;
        private TrackBar trackBar1;
        private Button button1;
    }
}
