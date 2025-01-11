namespace WinFormsApp1
{
    partial class EditRoomForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewRooms;
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
            dataGridViewRooms = new DataGridView();
            buttonSaveChanges = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRooms
            // 
            dataGridViewRooms.AllowUserToAddRows = false;
            dataGridViewRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRooms.BackgroundColor = Color.FromArgb(163, 177, 138);
            dataGridViewRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRooms.GridColor = Color.FromArgb(58, 90, 64);
            dataGridViewRooms.Location = new Point(12, 12);
            dataGridViewRooms.Name = "dataGridViewRooms";
            dataGridViewRooms.Size = new Size(760, 400);
            dataGridViewRooms.TabIndex = 0;
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
            // EditRoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(784, 461);
            Controls.Add(buttonSaveChanges);
            Controls.Add(dataGridViewRooms);
            Name = "EditRoomForm";
            Text = "Edytuj pokoje";
            Load += EditRoomForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
