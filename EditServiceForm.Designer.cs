namespace WinFormsApp1
{
    partial class EditServiceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.Button buttonSaveChanges;

        /// <summary>
        /// Dispose resources
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

        private void InitializeComponent()
        {
            dataGridViewServices = new DataGridView();
            buttonSaveChanges = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewServices
            // 
            dataGridViewServices.AllowUserToAddRows = false;
            dataGridViewServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServices.BackgroundColor = Color.FromArgb(163, 177, 138);
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.GridColor = Color.FromArgb(58, 90, 64);
            dataGridViewServices.Location = new Point(12, 12);
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.Size = new Size(760, 400);
            dataGridViewServices.TabIndex = 0;
            // 
            // buttonSaveChanges
            // 
            buttonSaveChanges.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveChanges.BackColor = Color.FromArgb(88, 129, 87);
            buttonSaveChanges.FlatStyle = FlatStyle.Flat;
            buttonSaveChanges.ForeColor = Color.White;
            buttonSaveChanges.Location = new Point(672, 420);
            buttonSaveChanges.Name = "buttonSaveChanges";
            buttonSaveChanges.Size = new Size(100, 30);
            buttonSaveChanges.TabIndex = 1;
            buttonSaveChanges.Text = "Zapisz zmiany";
            buttonSaveChanges.UseVisualStyleBackColor = false;
            buttonSaveChanges.Click += buttonSaveChanges_Click;
            // 
            // EditServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(784, 461);
            Controls.Add(buttonSaveChanges);
            Controls.Add(dataGridViewServices);
            Name = "EditServiceForm";
            Text = "Edytuj usługi";
            Load += EditServiceForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
