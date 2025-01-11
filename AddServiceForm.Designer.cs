namespace WinFormsApp1
{
    partial class AddServiceForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxServiceName;
        private TextBox textBoxDescription;
        private NumericUpDown numericUpDownPrice;
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
            textBoxServiceName = new TextBox();
            textBoxDescription = new TextBox();
            numericUpDownPrice = new NumericUpDown();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // textBoxServiceName
            // 
            textBoxServiceName.BackColor = Color.FromArgb(163, 177, 138);
            textBoxServiceName.BorderStyle = BorderStyle.FixedSingle;
            textBoxServiceName.ForeColor = Color.FromArgb(52, 78, 65);
            textBoxServiceName.Location = new Point(20, 20);
            textBoxServiceName.Name = "textBoxServiceName";
            textBoxServiceName.PlaceholderText = "Nazwa usługi";
            textBoxServiceName.Size = new Size(200, 23);
            textBoxServiceName.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.FromArgb(163, 177, 138);
            textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescription.ForeColor = Color.FromArgb(52, 78, 65);
            textBoxDescription.Location = new Point(20, 60);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "Opis usługi";
            textBoxDescription.Size = new Size(200, 23);
            textBoxDescription.TabIndex = 1;
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
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.FromArgb(88, 129, 87);
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.ForeColor = Color.White;
            buttonAdd.Location = new Point(20, 140);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(200, 30);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Dodaj usługę";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // AddServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(250, 200);
            Controls.Add(textBoxServiceName);
            Controls.Add(textBoxDescription);
            Controls.Add(numericUpDownPrice);
            Controls.Add(buttonAdd);
            Name = "AddServiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dodaj usługę";
            Load += AddServiceForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
