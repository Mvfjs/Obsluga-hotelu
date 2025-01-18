using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public abstract class RoomServiceForm : DatabaseForm
    {
        // Metoda ładowania danych do DataGridView
        protected void LoadData(string query, DataGridView dataGridView)
        {
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas ładowania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Metoda wykonywania zapytań SQL z parametrami
        protected void ExecuteSQL(string query, Action<MySqlCommand> configureCommand)
        {
            try
            {
                ExecuteQuery(query, configureCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wykonywania zapytania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
