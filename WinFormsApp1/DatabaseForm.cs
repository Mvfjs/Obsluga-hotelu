using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public abstract class DatabaseForm : Form
    {
        // Hermetyzacja: ConnectionString jako właściwość tylko do odczytu
        protected string ConnectionString { get; } = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";

        // Hermetyzacja: Tworzenie połączenia z obsługą wyjątków
        protected MySqlConnection GetConnection()
        {
            try
            {
                return new MySqlConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas tworzenia połączenia z bazą danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Rzucenie wyjątku dalej, aby informować o problemie
            }
        }

        // Polimorfizm: Wykonanie zapytania bez zwracania wartości
        protected void ExecuteQuery(string query, Action<MySqlCommand> parameterizeCommand)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        parameterizeCommand(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wykonania zapytania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Polimorfizm: Wykonanie zapytania i zwrócenie jednej wartości
        protected T ExecuteScalar<T>(string query, Action<MySqlCommand> parameterizeCommand)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        parameterizeCommand(cmd);
                        return (T)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wykonania zapytania scalar: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Polimorfizm: Wykonanie zapytania i zwrócenie DataTable
        protected DataTable ExecuteQueryToDataTable(string query, Action<MySqlCommand> parameterizeCommand)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        parameterizeCommand(cmd);
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas pobierania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
