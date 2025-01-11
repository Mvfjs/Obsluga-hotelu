using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class EditServiceForm : Form // Dziedziczenie klasy Form z biblioteki WinForms
    {
        // Hermetyzacja: Prywatne pole przechowujące łańcuch połączenia z bazą danych
        private string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";

        public EditServiceForm()
        {
            InitializeComponent();
            LoadServices(); // Hermetyzacja: Logika ładowania usług ukryta w metodzie pomocniczej
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

                    // Polimorfizm: Dynamiczna konfiguracja kolumn, np. ustawienie "ReadOnly" dla ServiceID
                    if (dataGridViewServices.Columns["ServiceID"] != null)
                    {
                        dataGridViewServices.Columns["ServiceID"].ReadOnly = true;
                        dataGridViewServices.Columns["ServiceID"].HeaderText = "ID Usługi";
                    }
                }
                catch (Exception ex)
                {
                    // Obsługa błędów podczas ładowania danych
                    MessageBox.Show($"Błąd podczas ładowania usług: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Hermetyzacja: Pobranie zmian z DataGridView
                    DataTable changes = ((DataTable)dataGridViewServices.DataSource).GetChanges();

                    if (changes != null)
                    {
                        foreach (DataRow row in changes.Rows)
                        {
                            // Hermetyzacja: Zapytanie SQL aktualizujące dane usługi
                            string query = @"
                                UPDATE services
                                SET ServiceName = @ServiceName,
                                    Description = @Description,
                                    PriceService = @PriceService
                                WHERE ServiceID = @ServiceID";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                // Hermetyzacja: Przekazanie danych jako parametrów do zapytania SQL
                                cmd.Parameters.AddWithValue("@ServiceID", row["ServiceID"]);
                                cmd.Parameters.AddWithValue("@ServiceName", row["ServiceName"]);
                                cmd.Parameters.AddWithValue("@Description", row["Description"]);
                                cmd.Parameters.AddWithValue("@PriceService", row["PriceService"]);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Polimorfizm: Wyświetlenie komunikatu o powodzeniu akcji
                        MessageBox.Show("Zmiany zostały zapisane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadServices(); // Odświeżenie widoku po zapisaniu zmian
                    }
                    else
                    {
                        // Polimorfizm: Wyświetlenie komunikatu, jeśli brak zmian
                        MessageBox.Show("Brak zmian do zapisania.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Obsługa błędów podczas zapisywania zmian
                    MessageBox.Show($"Błąd podczas zapisywania zmian: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditServiceForm_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — przykład polimorfizmu
        }
    }
}
