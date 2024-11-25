namespace WinFormsApp1
{
    partial class reservation
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.ComboBox comboBoxRooms;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.Button buttonConfirm;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.comboBoxRooms = new System.Windows.Forms.ComboBox();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.buttonConfirm = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();

            // dataGridView
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridViewRooms";
            this.dataGridView.Size = new System.Drawing.Size(760, 250); // Zmniejszenie rozmiaru DataGridView
            this.dataGridView.TabIndex = 0;
            // textBoxName
            this.textBoxName.Location = new System.Drawing.Point(50, 280); // Przeniesienie pola poniżej DataGridView
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.PlaceholderText = "Imię i nazwisko";
            this.textBoxName.Size = new System.Drawing.Size(300, 22);
            this.textBoxName.BackColor = Color.FromArgb(218, 215, 205); // DAD7CD (jasny beż)

            // textBoxEmail
            this.textBoxEmail.Location = new System.Drawing.Point(50, 320); // Przeniesienie pola poniżej
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.PlaceholderText = "Email";
            this.textBoxEmail.Size = new System.Drawing.Size(300, 22);
            this.textBoxEmail.BackColor = Color.FromArgb(218, 215, 205); // DAD7CD (jasny beż)

            // textBoxPhone
            this.textBoxPhone.Location = new System.Drawing.Point(50, 360); // Przeniesienie pola poniżej
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.PlaceholderText = "Numer telefonu";
            this.textBoxPhone.Size = new System.Drawing.Size(300, 22);
            this.textBoxPhone.BackColor = Color.FromArgb(218, 215, 205); // DAD7CD (jasny beż)

            // comboBoxRooms
            this.comboBoxRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRooms.Location = new System.Drawing.Point(50, 400); // Przeniesienie pola poniżej
            this.comboBoxRooms.Name = "comboBoxRooms";
            this.comboBoxRooms.Size = new System.Drawing.Size(300, 22);
            this.comboBoxRooms.BackColor = Color.FromArgb(218, 215, 205); // DAD7CD (jasny beż)

            // dateTimePickerCheckIn
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(50, 440); // Przeniesienie pola poniżej
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(300, 22);

            // dateTimePickerCheckOut
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(50, 480); // Przeniesienie pola poniżej
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(300, 22);

            // buttonConfirm
            this.buttonConfirm.Location = new System.Drawing.Point(50, 520);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(300, 30);
            this.buttonConfirm.Text = "Potwierdź rezerwację";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.BackColor = Color.FromArgb(88, 129, 87); // 588157 (zielony)
            this.buttonConfirm.ForeColor = Color.FromArgb(218, 215, 205); // DAD7CD (jasny beż)
            this.buttonConfirm.MouseEnter += Button_MouseEnter;
            this.buttonConfirm.MouseLeave += Button_MouseLeave;
            this.buttonConfirm.Click += buttonConfirm_Click;

            // reservation
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 570); // Zwiększenie wysokości okna, aby pomieścić wszystkie kontrolki
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.comboBoxRooms);
            this.Controls.Add(this.dateTimePickerCheckIn);
            this.Controls.Add(this.dateTimePickerCheckOut);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.dataGridView);
            this.Name = "reservation";
            this.Text = "Reservation";
            this.BackColor = Color.FromArgb(218, 215, 205); // Tło formularza - DAD7CD (jasny beż)
            this.Load += new System.EventHandler(this.reservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // Placeholder for button click event
            throw new NotImplementedException();
        }
    }
}
