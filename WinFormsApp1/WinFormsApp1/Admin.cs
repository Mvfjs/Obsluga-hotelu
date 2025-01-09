
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadReservations();
            LoadRooms();
            LoadGuests();
            LoadServices();
            LoadServiceOrders();
        }

        private void LoadReservations()
        {
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT BookingID, GuestID, RoomID, CheckINDate, CheckOUTDate, TotalPrice, ReservationCode, BookingStatus FROM bookings";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewReservations.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas ładowania rezerwacji: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRooms()
        {
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT RoomID, RoomNumber, RoomType, Price, Status FROM rooms";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewRooms.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas ładowania pokoi: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadGuests()
        {
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT GuestID, FirstName, LastName, Email, PhoneNumber FROM guests";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewGuests.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas ładowania gości: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadServices()
        {
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT ServiceID, ServiceName, Description, PriceService FROM services";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewServices.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas ładowania usług: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadServiceOrders()
        {
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT ServiceOrderID, BookingID, ServiceID, OrderDate, TotalPrice FROM serviceorders";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewServiceOrders.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas ładowania zamówień usług: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            using (AddRoomForm addRoomForm = new AddRoomForm())
            {
                if (addRoomForm.ShowDialog() == DialogResult.OK)
                {
                    string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            string query = @"INSERT INTO rooms (RoomNumber, RoomType, Price, Status) 
                                     VALUES (@RoomNumber, @RoomType, @Price, @Status)";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@RoomNumber", addRoomForm.RoomNumber);
                                cmd.Parameters.AddWithValue("@RoomType", addRoomForm.RoomType);
                                cmd.Parameters.AddWithValue("@Price", addRoomForm.Price);
                                cmd.Parameters.AddWithValue("@Status", addRoomForm.Status);

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Pokój został pomyślnie dodany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRooms(); // Odśwież listę pokoi w DataGridView
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Błąd podczas dodawania pokoju: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonEditRoom_Click(object sender, EventArgs e)
        {
            // Logika edycji pokoju
            MessageBox.Show("Edycja pokoju jeszcze nie zaimplementowana.");
        }

        private void buttonDeleteRoom_Click(object sender, EventArgs e)
        {
            // Logika usuwania pokoju
            MessageBox.Show("Usuwanie pokoju jeszcze nie zaimplementowane.");
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            // Logika dodawania usługi
            MessageBox.Show("Dodawanie usługi jeszcze nie zaimplementowane.");
        }

        private void buttonEditService_Click(object sender, EventArgs e)
        {
            // Logika edycji usługi
            MessageBox.Show("Edycja usługi jeszcze nie zaimplementowana.");
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            // Logika usuwania usługi
            MessageBox.Show("Usuwanie usługi jeszcze nie zaimplementowane.");
        }
    }
}