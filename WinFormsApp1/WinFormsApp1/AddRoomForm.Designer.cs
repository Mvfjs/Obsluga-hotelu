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

            SuspendLayout();

            // Room Number
            textBoxRoomNumber.Location = new Point(20, 20);
            textBoxRoomNumber.Name = "textBoxRoomNumber";
            textBoxRoomNumber.PlaceholderText = "Numer pokoju";
            textBoxRoomNumber.Size = new Size(200, 23);

            // Room Type
            comboBoxRoomType.Location = new Point(20, 60);
            comboBoxRoomType.Name = "comboBoxRoomType";
            comboBoxRoomType.Size = new Size(200, 23);
            comboBoxRoomType.Items.AddRange(new object[] { "Jednoosobowy", "Dwuosobowy", "Rodzinny" });

            // Price
            numericUpDownPrice.Location = new Point(20, 100);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(200, 23);
            numericUpDownPrice.Minimum = 0;
            numericUpDownPrice.Maximum = 10000;
            numericUpDownPrice.DecimalPlaces = 2;

            // Status
            comboBoxStatus.Location = new Point(20, 140);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(200, 23);
            comboBoxStatus.Items.AddRange(new object[] { "Wolny", "Zajęty", "Prace techniczne" });

            // Add Button
            buttonAdd.Location = new Point(20, 180);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(200, 30);
            buttonAdd.Text = "Dodaj pokój";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;

            // AddRoomForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 250);
            Controls.Add(textBoxRoomNumber);
            Controls.Add(comboBoxRoomType);
            Controls.Add(numericUpDownPrice);
            Controls.Add(comboBoxStatus);
            Controls.Add(buttonAdd);
            Name = "AddRoomForm";
            Text = "Dodaj pokój";
            ResumeLayout(false);
        }
    }
}
