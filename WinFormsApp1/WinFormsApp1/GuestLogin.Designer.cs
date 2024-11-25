namespace WinFormsApp1
{
    partial class GuestLogin
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(350, 181);
            button1.Name = "button1";
            button1.Size = new Size(134, 23);
            button1.TabIndex = 0;
            button1.Text = "Zatwierdź logowanie";
            button1.UseVisualStyleBackColor = true;
            button1.BackColor = Color.FromArgb(88, 129, 87); // Zielony tło przycisku
            button1.ForeColor = Color.FromArgb(218, 215, 205); // Jasny beż tekst
            button1.MouseEnter += Button_MouseEnter;
            button1.MouseLeave += Button_MouseLeave;
            button1.Click += button1_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(265, 93);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.BackColor = Color.FromArgb(218, 215, 205); // Jasny beż tło pola tekstowego
            // 
            // textBox2
            // 
            textBox2.Location = new Point(461, 93);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 2;
            textBox2.BackColor = Color.FromArgb(218, 215, 205); // Jasny beż tło pola tekstowego
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(265, 75);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 3;
            label1.Text = "Kod rezerwacji";
            label1.ForeColor = Color.FromArgb(88, 129, 87); // Zielony tekst
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(482, 75);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 4;
            label2.Text = "Nr. Pokoju";
            label2.ForeColor = Color.FromArgb(88, 129, 87); // Zielony tekst
            // 
            // GuestLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "GuestLogin";
            Text = "GuestLogin";
            BackColor = Color.FromArgb(218, 215, 205); // Tło formularza (jasny beż)
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;

        // Event handlers for mouse hover effects
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(163, 177, 138); // Zmiana tła przy najechaniu (jasny zielony)
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(88, 129, 87); // Przywrócenie oryginalnego koloru (zielony)
            }
        }
    }
}
