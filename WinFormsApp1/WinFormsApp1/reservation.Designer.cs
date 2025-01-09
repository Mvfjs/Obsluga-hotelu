namespace WinFormsApp1
{
    partial class reservation
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewRooms;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.MonthCalendar monthCalendarAvailability;

        /// <summary>
        /// Dispose resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialize components
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewRooms = new DataGridView();
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPhone = new TextBox();
            buttonConfirm = new Button();
            labelTotalPrice = new Label();
            monthCalendarAvailability = new MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).BeginInit();
            SuspendLayout();

            // Form background color
            this.BackColor = ColorTranslator.FromHtml("#DAD7CD");

            // 
            // dataGridViewRooms
            // 
            dataGridViewRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRooms.Location = new Point(10, 11);
            dataGridViewRooms.Name = "dataGridViewRooms";
            dataGridViewRooms.Size = new Size(665, 234);
            dataGridViewRooms.TabIndex = 0;
            dataGridViewRooms.BackgroundColor = ColorTranslator.FromHtml("#A3B18A");
            dataGridViewRooms.ForeColor = ColorTranslator.FromHtml("#344E41");
            dataGridViewRooms.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(44, 262);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Imię i nazwisko";
            textBoxName.Size = new Size(263, 23);
            textBoxName.TabIndex = 1;
            textBoxName.BackColor = ColorTranslator.FromHtml("#A3B18A");
            textBoxName.ForeColor = ColorTranslator.FromHtml("#344E41");
            textBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(44, 300);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.PlaceholderText = "Email";
            textBoxEmail.Size = new Size(263, 23);
            textBoxEmail.TabIndex = 2;
            textBoxEmail.BackColor = ColorTranslator.FromHtml("#A3B18A");
            textBoxEmail.ForeColor = ColorTranslator.FromHtml("#344E41");
            textBoxEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(44, 338);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.PlaceholderText = "Numer telefonu";
            textBoxPhone.Size = new Size(263, 23);
            textBoxPhone.TabIndex = 3;
            textBoxPhone.BackColor = ColorTranslator.FromHtml("#A3B18A");
            textBoxPhone.ForeColor = ColorTranslator.FromHtml("#344E41");
            textBoxPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(44, 468);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(263, 28);
            buttonConfirm.TabIndex = 7;
            buttonConfirm.Text = "Potwierdź rezerwację";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.BackColor = ColorTranslator.FromHtml("#588157");
            buttonConfirm.ForeColor = Color.White;
            buttonConfirm.FlatStyle = FlatStyle.Flat;
            buttonConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonConfirm.MouseEnter += ButtonConfirm_MouseEnter;
            buttonConfirm.MouseLeave += ButtonConfirm_MouseLeave;
            buttonConfirm.Click += buttonConfirm_Click;

            // 
            // labelTotalPrice
            // 
            labelTotalPrice.Location = new Point(350, 262);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(262, 21);
            labelTotalPrice.TabIndex = 8;
            labelTotalPrice.Text = "Cena całkowita: 0 zł";
            labelTotalPrice.ForeColor = ColorTranslator.FromHtml("#3A5A40");
            labelTotalPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // 
            // monthCalendarAvailability
            // 
            monthCalendarAvailability.Location = new Point(350, 300);
            monthCalendarAvailability.MaxSelectionCount = 30;
            monthCalendarAvailability.Name = "monthCalendarAvailability";
            monthCalendarAvailability.TabIndex = 9;
            monthCalendarAvailability.TitleBackColor = ColorTranslator.FromHtml("#344E41");
            monthCalendarAvailability.TitleForeColor = Color.White;
            monthCalendarAvailability.TrailingForeColor = ColorTranslator.FromHtml("#3A5A40");
            monthCalendarAvailability.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            monthCalendarAvailability.DateChanged += MonthCalendarAvailability_DateChanged;

            // 
            // reservation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 562);
            Controls.Add(dataGridViewRooms);
            Controls.Add(textBoxName);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxPhone);
            Controls.Add(buttonConfirm);
            Controls.Add(labelTotalPrice);
            Controls.Add(monthCalendarAvailability);
            Name = "reservation";
            Text = "Reservation";
            Load += reservation_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Change button color on hover
        private void ButtonConfirm_MouseEnter(object sender, EventArgs e)
        {
            buttonConfirm.BackColor = ColorTranslator.FromHtml("#A3B18A");
        }

        // Reset button color on mouse leave
        private void ButtonConfirm_MouseLeave(object sender, EventArgs e)
        {
            buttonConfirm.BackColor = ColorTranslator.FromHtml("#588157");
        }
    }
}
