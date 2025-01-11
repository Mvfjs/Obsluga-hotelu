namespace WinFormsApp1
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(352, 61);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "The Garden Hotel";
            label1.ForeColor = Color.FromArgb(58, 90, 64); // 3A5A40 (ciemny zielony)
            // 
            // button1
            // 
            button1.Location = new Point(311, 386);
            button1.Name = "button1";
            button1.Size = new Size(178, 23);
            button1.TabIndex = 1;
            button1.Text = "Panel Administratora";
            button1.UseVisualStyleBackColor = true;
            button1.BackColor = Color.FromArgb(88, 129, 87); // 588157 (zielony)
            button1.ForeColor = Color.FromArgb(218, 215, 205); // DAD7CD (jasny beż)
            button1.MouseEnter += Button_MouseEnter;
            button1.MouseLeave += Button_MouseLeave;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(311, 92);
            button2.Name = "button2";
            button2.Size = new Size(178, 23);
            button2.TabIndex = 2;
            button2.Text = "Panel Gościa";
            button2.UseVisualStyleBackColor = true;
            button2.BackColor = Color.FromArgb(88, 129, 87); // 588157 (zielony)
            button2.ForeColor = Color.FromArgb(218, 215, 205); // DAD7CD (jasny beż)
            button2.MouseEnter += Button_MouseEnter;
            button2.MouseLeave += Button_MouseLeave;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(311, 138);
            button3.Name = "button3";
            button3.Size = new Size(178, 23);
            button3.TabIndex = 3;
            button3.Text = "Rezerwacja Pokoju";
            button3.UseVisualStyleBackColor = true;
            button3.BackColor = Color.FromArgb(88, 129, 87); // 588157 (zielony)
            button3.ForeColor = Color.FromArgb(218, 215, 205); // DAD7CD (jasny beż)
            button3.MouseEnter += Button_MouseEnter;
            button3.MouseLeave += Button_MouseLeave;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            BackColor = Color.FromArgb(218, 215, 205); // Tło formularza - DAD7CD (jasny beż)
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;

        // Event handlers for mouse hover effects
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(163, 177, 138); //  A3B18A (zielony) najechanie
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(88, 129, 87); // 588157 (zielony)
            }
        }
    }
}
