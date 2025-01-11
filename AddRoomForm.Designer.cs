namespace WinFormsApp1
{
    partial class AddRoomForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxRoomNumber;
        private ComboBox comboBoxRoomType;
        private NumericUpDown numericUpDownPrice;
        private ComboBox comboBoxStatus;
        private Button buttonAdd;

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
            textBoxRoomNumber = new TextBox();
            comboBoxRoomType = new ComboBox();
            numericUpDownPrice = new NumericUpDown();
            comboBoxStatus = new ComboBox();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // textBoxRoomNumber
            // 
            textBoxRoomNumber.BackColor = Color.FromArgb(163, 177, 138);
            textBoxRoomNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxRoomNumber.ForeColor = Color.FromArgb(52, 78, 65);
            textBoxRoomNumber.Location = new Point(20, 20);
            textBoxRoomNumber.Name = "textBoxRoomNumber";
            textBoxRoomNumber.PlaceholderText = "Numer pokoju";
            textBoxRoomNumber.Size = new Size(200, 23);
            textBoxRoomNumber.TabIndex = 0;
            // 
            // comboBoxRoomType
            // 
            comboBoxRoomType.BackColor = Color.FromArgb(163, 177, 138);
            comboBoxRoomType.FlatStyle = FlatStyle.Flat;
            comboBoxRoomType.ForeColor = Color.FromArgb(52, 78, 65);
            comboBoxRoomType.Location = new Point(20, 60);
            comboBoxRoomType.Name = "comboBoxRoomType";
            comboBoxRoomType.Size = new Size(200, 23);
            comboBoxRoomType.TabIndex = 1;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.BackColor = Color.FromArgb(163, 177, 138);
            numericUpDownPrice.BorderStyle = BorderStyle.FixedSingle;
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.ForeColor = Color.FromArgb(52, 78, 65);
            numericUpDownPrice.Location = new Point(20, 100);
            numericUpDownPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(200, 23);
            numericUpDownPrice.TabIndex = 2;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.BackColor = Color.FromArgb(163, 177, 138);
            comboBoxStatus.FlatStyle = FlatStyle.Flat;
            comboBoxStatus.ForeColor = Color.FromArgb(52, 78, 65);
            comboBoxStatus.Location = new Point(20, 140);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(200, 23);
            comboBoxStatus.TabIndex = 3;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.FromArgb(88, 129, 87);
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Location = new Point(20, 180);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(200, 30);
            buttonAdd.TabIndex = 4;
            buttonAdd.Text = "Dodaj pokój";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // AddRoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(250, 250);
            Controls.Add(textBoxRoomNumber);
            Controls.Add(comboBoxRoomType);
            Controls.Add(numericUpDownPrice);
            Controls.Add(comboBoxStatus);
            Controls.Add(buttonAdd);
            Name = "AddRoomForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dodaj pokój";
            Load += AddRoomForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
