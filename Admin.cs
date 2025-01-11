using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class Admin : Form // Dziedziczenie klasy Form z biblioteki WinForms
    {
        // Hermetyzacja: prywatne pola przechowujące łańcuch połączenia i globalne połączenie
        private string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
        private MySqlConnection connection;

        // Deklaracja etykiet
        private Label labelBookings;
        private Label labelGuests;
        private Label labelRooms;
        private Label labelServices;
        private Label labelServiceOrders;

        public Admin()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString); // Tworzenie globalnego połączenia
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open(); // Hermetyzacja: Połączenie otwierane raz na początku
                LoadBookings();
                LoadGuests();
                LoadRooms();
                LoadServices();
                LoadServiceOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas łączenia z bazą danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllData()
        {
            // Polimorfizm: Odświeżanie wszystkich danych poprzez wywołanie metod ładowania poszczególnych tabel
            LoadBookings();
            LoadGuests();
            LoadRooms();
            LoadServices();
            LoadServiceOrders();
        }

        private void LoadBookings()
        {
            // Hermetyzacja: zapytanie SQL jest zamknięte w osobnej metodzie
            string query = @"
                SELECT BookingID AS 'ID Rezerwacji', 
                       GuestID AS 'ID Gościa', 
                       RoomID AS 'ID Pokoju', 
                       CheckINDate AS 'Data Zameldowania', 
                       CheckOUTDate AS 'Data Wymeldowania', 
                       TotalPrice AS 'Całkowita Cena', 
                       ReservationCode AS 'Kod Rezerwacji', 
                       BookingStatus AS 'Status Rezerwacji'
                FROM bookings
                LIMIT 100";

            LoadDataIntoDataGridView(query, dataGridViewBookings); // Polimorfizm: wielokrotne użycie tej samej metody
        }

        private void LoadGuests()
        {
            string query = @"
                SELECT GuestID AS 'ID Gościa', 
                       FirstName AS 'Imię', 
                       LastName AS 'Nazwisko', 
                       Email AS 'Adres Email', 
                       PhoneNumber AS 'Numer Telefonu'
                FROM guests
                LIMIT 100";

            LoadDataIntoDataGridView(query, dataGridViewGuests);
        }

        private void LoadRooms()
        {
            string query = @"
                SELECT RoomID AS 'ID Pokoju', 
                       RoomNumber AS 'Numer Pokoju', 
                       RoomType AS 'Typ Pokoju', 
                       Price AS 'Cena za noc', 
                       Status AS 'Status'
                FROM rooms
                LIMIT 100";

            LoadDataIntoDataGridView(query, dataGridViewRooms);
        }

        private void LoadServices()
        {
            string query = @"
                SELECT ServiceID AS 'ID Usługi', 
                       ServiceName AS 'Nazwa Usługi', 
                       Description AS 'Opis Usługi', 
                       PriceService AS 'Cena Usługi'
                FROM services
                LIMIT 100";

            LoadDataIntoDataGridView(query, dataGridViewServices);
        }

        private void LoadServiceOrders()
        {
            string query = @"
                SELECT ServiceOrderID AS 'ID Zamówienia', 
                       BookingID AS 'ID Rezerwacji', 
                       ServiceID AS 'ID Usługi', 
                       OrderDate AS 'Data Zamówienia', 
                       TotalPrice AS 'Cena Zamówienia'
                FROM serviceorders
                LIMIT 100";

            LoadDataIntoDataGridView(query, dataGridViewServiceOrders);
        }

        private void LoadDataIntoDataGridView(string query, DataGridView dataGridView)
        {
            // Hermetyzacja: szczegóły wykonania zapytania SQL ukryte w tej metodzie
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show($"Brak danych do wyświetlenia w tabeli: {dataGridView.Name}", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania danych: {ex.Message}\n{ex.StackTrace}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            // Polimorfizm: dynamiczne otwieranie formularza AddRoomForm
            using (AddRoomForm addRoomForm = new AddRoomForm())
            {
                addRoomForm.ShowDialog(); // Polimorfizm: metoda ShowDialog() dziedziczona z Form
            }
        }

        private void buttonEditRoom_Click(object sender, EventArgs e)
        {
            using (EditRoomForm editRoomForm = new EditRoomForm())
            {
                editRoomForm.ShowDialog();
            }
        }

        private void buttonDeleteRoom_Click(object sender, EventArgs e)
        {
            using (DeleteRoomForm deleteRoomForm = new DeleteRoomForm())
            {
                deleteRoomForm.ShowDialog();
            }
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            using (AddServiceForm addServiceForm = new AddServiceForm())
            {
                addServiceForm.ShowDialog();
            }
        }

        private void buttonEditService_Click(object sender, EventArgs e)
        {
            using (EditServiceForm editServiceForm = new EditServiceForm())
            {
                editServiceForm.ShowDialog();
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            using (DeleteServiceForm deleteServiceForm = new DeleteServiceForm())
            {
                deleteServiceForm.ShowDialog();
            }
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hermetyzacja: zamykanie połączenia tylko, jeśli jest otwarte
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAllData(); // Polimorfizm: odświeżenie wszystkich danych za pomocą wspólnej metody
                MessageBox.Show("Dane zostały odświeżone.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas odświeżania danych: {ex.Message}\n{ex.StackTrace}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
