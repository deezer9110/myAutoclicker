namespace Autoclicker
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
        private void InitializeComponent() {
            startBtn = new Button();
            stopBtn = new Button();
            aAfkBtn = new Button();
            cpsTextBox = new TextBox();
            label1 = new Label();
            updateBtn = new Button();
            label2 = new Label();
            timeTextBox = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            titleLbl = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.SkyBlue;
            startBtn.Dock = DockStyle.Fill;
            startBtn.FlatAppearance.BorderColor = Color.Black;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Font = new Font("Arial", 12F, FontStyle.Bold);
            startBtn.ForeColor = Color.White;
            startBtn.Location = new Point(3, 363);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(394, 84);
            startBtn.TabIndex = 0;
            startBtn.Text = "START";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += StartBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.BackColor = Color.SkyBlue;
            stopBtn.Dock = DockStyle.Fill;
            stopBtn.FlatAppearance.BorderColor = Color.Black;
            stopBtn.FlatStyle = FlatStyle.Flat;
            stopBtn.Font = new Font("Arial", 12F, FontStyle.Bold);
            stopBtn.ForeColor = Color.White;
            stopBtn.Location = new Point(403, 363);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(394, 84);
            stopBtn.TabIndex = 1;
            stopBtn.Text = "STOP";
            stopBtn.UseVisualStyleBackColor = false;
            stopBtn.Click += StopBtn_Click;
            // 
            // aAfkBtn
            // 
            aAfkBtn.BackColor = Color.SkyBlue;
            aAfkBtn.Dock = DockStyle.Fill;
            aAfkBtn.FlatAppearance.BorderColor = Color.Black;
            aAfkBtn.FlatStyle = FlatStyle.Flat;
            aAfkBtn.Font = new Font("Arial", 12F, FontStyle.Bold);
            aAfkBtn.ForeColor = Color.White;
            aAfkBtn.Location = new Point(403, 273);
            aAfkBtn.Name = "aAfkBtn";
            aAfkBtn.Size = new Size(394, 84);
            aAfkBtn.TabIndex = 2;
            aAfkBtn.Text = "ANTI-AFK";
            aAfkBtn.UseVisualStyleBackColor = false;
            aAfkBtn.Click += AAfkBtn_Click;
            // 
            // cpsTextBox
            // 
            cpsTextBox.Anchor = AnchorStyles.None;
            cpsTextBox.Location = new Point(3, 213);
            cpsTextBox.Name = "cpsTextBox";
            cpsTextBox.Size = new Size(394, 23);
            cpsTextBox.TabIndex = 3;
            cpsTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 90);
            label1.Name = "label1";
            label1.Size = new Size(394, 90);
            label1.TabIndex = 4;
            label1.Text = "SET CPS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.SkyBlue;
            updateBtn.Dock = DockStyle.Fill;
            updateBtn.FlatAppearance.BorderColor = Color.Black;
            updateBtn.FlatStyle = FlatStyle.Flat;
            updateBtn.Font = new Font("Arial", 12F, FontStyle.Bold);
            updateBtn.ForeColor = Color.White;
            updateBtn.Location = new Point(3, 273);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(394, 84);
            updateBtn.TabIndex = 5;
            updateBtn.Text = "UPDATE";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += UpdateBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(403, 90);
            label2.Name = "label2";
            label2.Size = new Size(394, 90);
            label2.TabIndex = 7;
            label2.Text = "SET CLICKING TIMER (IN SECONDS, OPTIONAL)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeTextBox
            // 
            timeTextBox.Anchor = AnchorStyles.None;
            timeTextBox.Location = new Point(403, 213);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(394, 23);
            timeTextBox.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(aAfkBtn, 1, 3);
            tableLayoutPanel1.Controls.Add(updateBtn, 0, 3);
            tableLayoutPanel1.Controls.Add(startBtn, 0, 4);
            tableLayoutPanel1.Controls.Add(stopBtn, 1, 4);
            tableLayoutPanel1.Controls.Add(label2, 2, 1);
            tableLayoutPanel1.Controls.Add(cpsTextBox, 0, 2);
            tableLayoutPanel1.Controls.Add(timeTextBox, 2, 2);
            tableLayoutPanel1.Controls.Add(titleLbl, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.BackColor = Color.Transparent;
            tableLayoutPanel1.SetColumnSpan(titleLbl, 2);
            titleLbl.Dock = DockStyle.Fill;
            titleLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLbl.ForeColor = Color.White;
            titleLbl.Location = new Point(3, 0);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(794, 90);
            titleLbl.TabIndex = 8;
            titleLbl.Text = "AUTOCLICKER";
            titleLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "AUTOCLICKER";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button startBtn;
        private Button stopBtn;
        private Button aAfkBtn;
        private TextBox cpsTextBox;
        private Label label1;
        private Button updateBtn;
        private Label label2;
        private TextBox timeTextBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label titleLbl;
    }
}
