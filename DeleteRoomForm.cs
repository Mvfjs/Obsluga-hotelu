using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class DeleteRoomForm : Form // Dziedziczenie klasy Form z biblioteki WinForms
    {
        // Hermetyzacja: Prywatne pole przechowujące łańcuch połączenia z bazą danych
        private string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";

        public DeleteRoomForm()
        {
            InitializeComponent();
            LoadRooms(); // Hermetyzacja: Logika ładowania pokoi ukryta w osobnej metodzie
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
                }
                catch (Exception ex)
                {
                    // Obsługa błędów podczas ładowania danych
                    MessageBox.Show($"Błąd podczas ładowania pokoi: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Walidacja: Upewnienie się, że użytkownik wybrał wiersz do usunięcia
            if (dataGridViewRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać pokój do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hermetyzacja: Pobranie danych o wybranym pokoju
            var selectedRow = dataGridViewRooms.SelectedRows[0];
            var roomID = selectedRow.Cells["RoomID"].Value.ToString();
            var roomNumber = selectedRow.Cells["RoomNumber"].Value.ToString();

            // Polimorfizm: Dynamiczne wywołanie MessageBox do potwierdzenia akcji
            var confirmResult = MessageBox.Show(
                $"Czy na pewno chcesz usunąć pokój o numerze {roomNumber}?",
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
                        // Hermetyzacja: Zapytanie SQL do usuwania pokoju
                        string query = "DELETE FROM rooms WHERE RoomID = @RoomID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Hermetyzacja: Przekazanie parametru RoomID do zapytania
                            cmd.Parameters.AddWithValue("@RoomID", roomID);
                            cmd.ExecuteNonQuery();
                        }

                        // Polimorfizm: Wyświetlenie komunikatu o powodzeniu akcji
                        MessageBox.Show("Pokój został pomyślnie usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadRooms(); // Odświeżenie widoku po usunięciu pokoju
                    }
                    catch (Exception ex)
                    {
                        // Obsługa błędów podczas usuwania pokoju
                        MessageBox.Show($"Błąd podczas usuwania pokoju: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteRoomForm_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — przykład polimorfizmu
        }
    }
}
