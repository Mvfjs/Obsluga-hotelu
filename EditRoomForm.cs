using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class EditRoomForm : Form // Dziedziczenie klasy Form z biblioteki WinForms
    {
        // Hermetyzacja: Prywatne pole przechowujące łańcuch połączenia z bazą danych
        private string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";

        public EditRoomForm()
        {
            InitializeComponent();
            LoadRooms(); // Hermetyzacja: Logika ładowania pokoi ukryta w metodzie pomocniczej
        }

        private void LoadRooms()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Hermetyzacja: Pobieranie danych o pokojach z bazy danych
                    string query = "SELECT RoomID, RoomNumber, RoomType, Price, Status FROM rooms";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Polimorfizm: Przypisanie danych do kontrolki DataGridView
                    dataGridViewRooms.DataSource = dataTable;

                    // Polimorfizm: Dynamiczna zmiana kolumn RoomType i Status na ComboBox
                    ReplaceColumnWithComboBox("RoomType", new[] { "jednoosobowy", "dwuosobowy", "trzyosobowy" });
                    ReplaceColumnWithComboBox("Status", new[] { "Zajęty", "Wolny", "Prace techniczne" });
                }
                catch (Exception ex)
                {
                    // Obsługa błędów podczas ładowania danych
                    MessageBox.Show($"Błąd podczas ładowania pokoi: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ReplaceColumnWithComboBox(string columnName, string[] options)
        {
            if (dataGridViewRooms.Columns[columnName] != null)
            {
                int columnIndex = dataGridViewRooms.Columns[columnName].Index;

                // Polimorfizm: Zastąpienie zwykłej kolumny DataGridView kolumną ComboBox
                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = columnName,
                    HeaderText = dataGridViewRooms.Columns[columnName].HeaderText,
                    DataPropertyName = columnName, // Powiązanie z istniejącą właściwością danych
                    DataSource = options, // Opcje ComboBox
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                };

                dataGridViewRooms.Columns.RemoveAt(columnIndex); // Usunięcie starej kolumny
                dataGridViewRooms.Columns.Insert(columnIndex, comboBoxColumn); // Dodanie nowej kolumny
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
                    DataTable changes = ((DataTable)dataGridViewRooms.DataSource).GetChanges();

                    if (changes != null)
                    {
                        foreach (DataRow row in changes.Rows)
                        {
                            // Hermetyzacja: Zapytanie SQL aktualizujące dane pokoju
                            string query = @"
                                UPDATE rooms 
                                SET RoomNumber = @RoomNumber, 
                                    RoomType = @RoomType, 
                                    Price = @Price, 
                                    Status = @Status 
                                WHERE RoomID = @RoomID";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                // Hermetyzacja: Przekazanie danych jako parametrów do zapytania SQL
                                cmd.Parameters.AddWithValue("@RoomID", row["RoomID"]);
                                cmd.Parameters.AddWithValue("@RoomNumber", row["RoomNumber"]);
                                cmd.Parameters.AddWithValue("@RoomType", row["RoomType"]);
                                cmd.Parameters.AddWithValue("@Price", row["Price"]);
                                cmd.Parameters.AddWithValue("@Status", row["Status"]);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Polimorfizm: Wyświetlenie komunikatu o powodzeniu akcji
                        MessageBox.Show("Zmiany zostały zapisane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadRooms(); // Odświeżenie widoku po zapisaniu zmian
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

        private void EditRoomForm_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — przykład polimorfizmu
        }
    }
}
