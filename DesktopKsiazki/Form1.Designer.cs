namespace DesktopKsiazki
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
            button1 = new Button();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(193, 315);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(442, 23);
            comboBox1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(203, 176);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(65, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(132, 217);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Napisz opinie o książce !!";
            textBox1.Size = new Size(205, 77);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(642, 315);
            button2.Name = "button2";
            button2.Size = new Size(148, 23);
            button2.TabIndex = 6;
            button2.Text = "Odśwież moją liste";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(475, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(463, 248);
            dataGridView1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 368);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridViewCellEventHandler dataGridView1_CellContentClick;
    }
}
