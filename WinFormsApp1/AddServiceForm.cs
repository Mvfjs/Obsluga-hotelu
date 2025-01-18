using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AddServiceForm : DatabaseForm // Dziedziczenie z DatabaseForm
    {
        public string ServiceName => textBoxServiceName.Text.Trim(); // Hermetyzacja
        public string Description => textBoxDescription.Text.Trim(); // Hermetyzacja
        public decimal Price => numericUpDownPrice.Value; // Hermetyzacja

        public AddServiceForm()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ServiceName) || string.IsNullOrEmpty(Description))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Price <= 0)
            {
                MessageBox.Show("Proszę wprowadzić poprawną cenę!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                INSERT INTO services (ServiceName, Description, PriceService)
                VALUES (@ServiceName, @Description, @PriceService)";

            try
            {
                ExecuteQuery(query, cmd =>
                {
                    cmd.Parameters.AddWithValue("@ServiceName", ServiceName);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@PriceService", Price);
                });

                MessageBox.Show("Usługa została pomyślnie dodana!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania usługi: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddServiceForm_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form
        }
    }
}
