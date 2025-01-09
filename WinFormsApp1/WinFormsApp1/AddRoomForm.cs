using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AddRoomForm : Form
    {
        public string RoomNumber => textBoxRoomNumber.Text.Trim();
        public string RoomType => comboBoxRoomType.SelectedItem?.ToString();
        public decimal Price => numericUpDownPrice.Value;
        public string Status => comboBoxStatus.SelectedItem?.ToString();

        public AddRoomForm()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RoomNumber) || string.IsNullOrEmpty(RoomType) || string.IsNullOrEmpty(Status))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
