using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class Guest : Form
    {
        private string connectionString = "Server=localhost;Port=3306;Uid=root;Pwd=;Database=the garden hotel2;";

        private string reservationCode;
        private string roomID;

        // Konstruktor przyjmuje kod rezerwacji i ID pokoju
        public Guest(string reservationCode, string roomID)
        {
            InitializeComponent();
            this.reservationCode = reservationCode;
            this.roomID = roomID;
            LoadServices(); // Załadowanie dostępnych usług
        }

        // Metoda ładowania dostępnych usług
        private void LoadServices()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT ServiceID, ServiceName, Description, PriceService FROM services";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable servicesTable = new DataTable();
                        adapter.Fill(servicesTable);

                        dataGridViewServices.DataSource = servicesTable; // Ustawienie źródła danych dla DataGridView
                    }
                }
                catch (Exception ex)
                {
                    // Obsługa błędu podczas ładowania danych
                    MessageBox.Show("Wystąpił błąd podczas ładowania usług: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Obsługa przycisku dodawania usługi
        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                try
                {
                    // Pobranie danych wybranej usługi
                    int serviceId = Convert.ToInt32(dataGridViewServices.SelectedRows[0].Cells["ServiceID"].Value);
                    string serviceName = dataGridViewServices.SelectedRows[0].Cells["ServiceName"].Value.ToString();
                    decimal price = Convert.ToDecimal(dataGridViewServices.SelectedRows[0].Cells["PriceService"].Value);
                    string orderTime = DateTime.Now.ToString("HH:mm:ss"); // Pobranie aktualnej godziny

                    // Dodanie szczegółów usługi do ListBox
                    listBoxSelectedServices.Items.Add($"{serviceName} - {price} zł - {orderTime}");
                }
                catch (Exception ex)
                {
                    // Obsługa błędu podczas dodawania usługi
                    MessageBox.Show("Wystąpił błąd podczas dodawania usługi: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Wyświetlenie komunikatu, jeśli żadna usługa nie została wybrana
                MessageBox.Show("Proszę wybrać usługę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Obsługa przycisku potwierdzenia usług
        private void buttonConfirmServices_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Pobranie BookingID na podstawie kodu rezerwacji i ID pokoju
                    string getBookingIdQuery = "SELECT BookingID FROM bookings WHERE ReservationCode = @ReservationCode AND RoomID = @RoomID";
                    int bookingId = 0;

                    using (MySqlCommand cmd = new MySqlCommand(getBookingIdQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReservationCode", reservationCode);
                        cmd.Parameters.AddWithValue("@RoomID", roomID);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            bookingId = Convert.ToInt32(result);
                        }
                        else
                        {
                            // Wyświetlenie komunikatu, jeśli BookingID nie został znaleziony
                            MessageBox.Show("Nie znaleziono pasującego BookingID dla podanych danych!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Zatrzymanie wykonania w przypadku braku BookingID
                        }
                    }

                    // Iteracja przez wybrane usługi i zapisanie ich w bazie danych
                    foreach (var item in listBoxSelectedServices.Items)
                    {
                        string[] parts = item.ToString().Split('-');
                        string serviceName = parts[0].Trim();
                        string orderTime = parts[2].Trim();

                        // Pobranie ServiceID na podstawie nazwy usługi
                        string getServiceIdQuery = "SELECT ServiceID FROM services WHERE ServiceName = @ServiceName";
                        int serviceId = 0;

                        using (MySqlCommand cmd = new MySqlCommand(getServiceIdQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ServiceName", serviceName);
                            serviceId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Wstawienie zamówionej usługi do tabeli serviceorders
                        string insertQuery = @"INSERT INTO serviceorders (ServiceID, BookingID, OrderDate, OrderTime)
                                               VALUES (@ServiceID, @BookingID, CURDATE(), @OrderTime)";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                            cmd.Parameters.AddWithValue("@BookingID", bookingId); // Użycie znalezionego BookingID
                            cmd.Parameters.AddWithValue("@OrderTime", orderTime);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Wyświetlenie komunikatu o powodzeniu
                    MessageBox.Show("Usługi zostały zamówione!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Obsługa błędu podczas zapisywania usług
                    MessageBox.Show("Wystąpił błąd podczas zapisywania usług: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
