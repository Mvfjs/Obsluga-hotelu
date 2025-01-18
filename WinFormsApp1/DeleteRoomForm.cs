using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class DeleteRoomForm : DatabaseForm // Dziedziczenie klasy DatabaseForm
    {
        public DeleteRoomForm()
        {
            InitializeComponent();
            LoadRooms(); // Hermetyzacja: Logika ładowania pokoi ukryta w osobnej metodzie
        }

        private void LoadRooms()
        {
            string query = "SELECT RoomID, RoomNumber, RoomType, Price, Status FROM rooms";
            try
            {
                using (var conn = GetConnection()) // Polimorfizm: Uzyskanie połączenia z klasy bazowej
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewRooms.DataSource = dataTable; // Polimorfizm: Dynamiczne przypisanie danych do DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania pokoi: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać pokój do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridViewRooms.SelectedRows[0];
            var roomID = selectedRow.Cells["RoomID"].Value.ToString();
            var roomNumber = selectedRow.Cells["RoomNumber"].Value.ToString();

            var confirmResult = MessageBox.Show(
                $"Czy na pewno chcesz usunąć pokój o numerze {roomNumber}?",
                "Potwierdzenie usunięcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM rooms WHERE RoomID = @RoomID";

                try
                {
                    ExecuteQuery(query, cmd =>
                    {
                        cmd.Parameters.AddWithValue("@RoomID", roomID); // Hermetyzacja: Parametryzacja zapytania
                    });

                    MessageBox.Show("Pokój został pomyślnie usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadRooms(); // Odświeżenie widoku po usunięciu pokoju
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas usuwania pokoju: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteRoomForm_Load(object sender, EventArgs e)
        {
        }
    }
}
