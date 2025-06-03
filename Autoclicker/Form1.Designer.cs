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
            SuspendLayout();
            // 
            // startBtn
            // 
            startBtn.Location = new Point(62, 330);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(199, 75);
            startBtn.TabIndex = 0;
            startBtn.Text = "START";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += StartBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.Location = new Point(511, 330);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(199, 75);
            stopBtn.TabIndex = 1;
            stopBtn.Text = "STOP";
            stopBtn.UseVisualStyleBackColor = true;
            stopBtn.Click += StopBtn_Click;
            // 
            // aAfkBtn
            // 
            aAfkBtn.Location = new Point(349, 382);
            aAfkBtn.Name = "aAfkBtn";
            aAfkBtn.Size = new Size(75, 23);
            aAfkBtn.TabIndex = 2;
            aAfkBtn.Text = "ANTI-AFK";
            aAfkBtn.UseVisualStyleBackColor = true;
            aAfkBtn.Click += AAfkBtn_Click;
            // 
            // cpsTextBox
            // 
            cpsTextBox.Location = new Point(232, 186);
            cpsTextBox.Name = "cpsTextBox";
            cpsTextBox.Size = new Size(100, 23);
            cpsTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(189, 168);
            label1.Name = "label1";
            label1.Size = new Size(195, 15);
            label1.TabIndex = 4;
            label1.Text = "AUTOCLICKER CLICKS PER SECOND";
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(349, 233);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(75, 23);
            updateBtn.TabIndex = 5;
            updateBtn.Text = "UPDATE";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += UpdateBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(426, 168);
            label2.Name = "label2";
            label2.Size = new Size(169, 15);
            label2.TabIndex = 7;
            label2.Text = "SET HOW LONG TO CLICK FOR";
            // 
            // timeTextBox
            // 
            timeTextBox.Location = new Point(463, 186);
            timeTextBox.Name = "timeTextBox";
            timeTextBox.Size = new Size(100, 23);
            timeTextBox.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(timeTextBox);
            Controls.Add(updateBtn);
            Controls.Add(label1);
            Controls.Add(cpsTextBox);
            Controls.Add(aAfkBtn);
            Controls.Add(stopBtn);
            Controls.Add(startBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
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
    }
}
