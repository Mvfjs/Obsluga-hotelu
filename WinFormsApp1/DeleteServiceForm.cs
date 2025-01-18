using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class DeleteServiceForm : DatabaseForm // Dziedziczenie z klasy DatabaseForm
    {
        public DeleteServiceForm()
        {
            InitializeComponent();
            LoadServices(); // Hermetyzacja: Logika ładowania usług ukryta w osobnej metodzie
        }

        private void LoadServices()
        {
            string query = "SELECT ServiceID, ServiceName, Description, PriceService FROM services";
            try
            {
                using (var conn = GetConnection()) // Polimorfizm: Uzyskanie połączenia z klasy bazowej
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewServices.DataSource = dataTable; // Polimorfizm: Dynamiczne przypisanie danych do DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania usług: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać usługę do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewServices.SelectedRows[0];
            var serviceID = selectedRow.Cells["ServiceID"].Value.ToString();
            var serviceName = selectedRow.Cells["ServiceName"].Value.ToString();

            var confirmResult = MessageBox.Show(
                $"Czy na pewno chcesz usunąć usługę \"{serviceName}\"?",
                "Potwierdzenie usunięcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM services WHERE ServiceID = @ServiceID";

                try
                {
                    ExecuteQuery(query, cmd =>
                    {
                        cmd.Parameters.AddWithValue("@ServiceID", serviceID); // Hermetyzacja: Parametryzacja zapytania
                    });

                    MessageBox.Show("Usługa została pomyślnie usunięta.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadServices(); // Odświeżenie widoku po usunięciu usługi
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas usuwania usługi: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteServiceForm_Load(object sender, EventArgs e)
        {
        }
    }
}
