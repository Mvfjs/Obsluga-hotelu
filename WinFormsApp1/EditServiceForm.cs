using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class EditServiceForm : DatabaseForm // Dziedziczenie z klasy DatabaseForm
    {
        public EditServiceForm()
        {
            InitializeComponent();
            LoadServices(); // Hermetyzacja: Logika ładowania usług ukryta w metodzie pomocniczej
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

                    dataGridViewServices.DataSource = dataTable; // Polimorfizm: Przypisanie danych do kontrolki DataGridView

                    ConfigureDataGridView(); // Hermetyzacja: Dostosowanie kolumn DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania usług: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewServices.Columns["ServiceID"] != null)
            {
                dataGridViewServices.Columns["ServiceID"].ReadOnly = true;
                dataGridViewServices.Columns["ServiceID"].HeaderText = "ID Usługi";
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            DataTable changes = ((DataTable)dataGridViewServices.DataSource).GetChanges();
            if (changes != null)
            {
                foreach (DataRow row in changes.Rows)
                {
                    string query = @"
                        UPDATE services
                        SET ServiceName = @ServiceName,
                            Description = @Description,
                            PriceService = @PriceService
                        WHERE ServiceID = @ServiceID";

                    try
                    {
                        ExecuteQuery(query, cmd =>
                        {
                            cmd.Parameters.AddWithValue("@ServiceID", row["ServiceID"]);
                            cmd.Parameters.AddWithValue("@ServiceName", row["ServiceName"]);
                            cmd.Parameters.AddWithValue("@Description", row["Description"]);
                            cmd.Parameters.AddWithValue("@PriceService", row["PriceService"]);
                        });

                        MessageBox.Show("Zmiany zostały zapisane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadServices(); // Odświeżenie widoku po zapisaniu zmian
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd podczas zapisywania zmian: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Brak zmian do zapisania.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditServiceForm_Load(object sender, EventArgs e)
        {
        }
    }
}
