using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class DeleteServiceForm : Form // Dziedziczenie klasy Form z biblioteki WinForms
    {
        // Hermetyzacja: Prywatne pole przechowujące łańcuch połączenia z bazą danych
        private string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";

        public DeleteServiceForm()
        {
            InitializeComponent();
            LoadServices(); // Hermetyzacja: Logika ładowania usług ukryta w osobnej metodzie
        }

        private void LoadServices()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Hermetyzacja: Pobieranie danych o usługach z bazy danych
                    string query = "SELECT ServiceID, ServiceName, Description, PriceService FROM services";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Polimorfizm: Przypisanie danych do kontrolki DataGridView
                    dataGridViewServices.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Obsługa błędów podczas ładowania danych
                    MessageBox.Show($"Błąd podczas ładowania usług: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Walidacja: Upewnienie się, że użytkownik wybrał wiersz do usunięcia
            if (dataGridViewServices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać usługę do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hermetyzacja: Pobranie danych o wybranej usłudze
            var selectedRow = dataGridViewServices.SelectedRows[0];
            var serviceID = selectedRow.Cells["ServiceID"].Value.ToString();
            var serviceName = selectedRow.Cells["ServiceName"].Value.ToString();

            // Polimorfizm: Dynamiczne wywołanie MessageBox do potwierdzenia akcji
            var confirmResult = MessageBox.Show(
                $"Czy na pewno chcesz usunąć usługę \"{serviceName}\"?",
                "Potwierdzenie usunięcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        // Hermetyzacja: Zapytanie SQL do usuwania usługi
                        string query = "DELETE FROM services WHERE ServiceID = @ServiceID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Hermetyzacja: Przekazanie parametru ServiceID do zapytania
                            cmd.Parameters.AddWithValue("@ServiceID", serviceID);
                            cmd.ExecuteNonQuery();
                        }

                        // Polimorfizm: Wyświetlenie komunikatu o powodzeniu akcji
                        MessageBox.Show("Usługa została pomyślnie usunięta.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadServices(); // Odświeżenie widoku po usunięciu usługi
                    }
                    catch (Exception ex)
                    {
                        // Obsługa błędów podczas usuwania usługi
                        MessageBox.Show($"Błąd podczas usuwania usługi: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteServiceForm_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — przykład polimorfizmu
        }
    }
}
