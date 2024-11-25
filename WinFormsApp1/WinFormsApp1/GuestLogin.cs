using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class GuestLogin : Form
    {
        public GuestLogin()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Pobranie danych z pól tekstowych
            string reservationCode = textBox1.Text.Trim();
            string roomID = textBox2.Text.Trim();

            // Sprawdzenie, czy pola nie są puste
            if (string.IsNullOrEmpty(reservationCode) || string.IsNullOrEmpty(roomID))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Połączenie z bazą danych
            string myConnectionString = "Server=127.0.0.1;Port=3306;Uid=root;Pwd=;Database=the garden hotel;";
            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                try
                {
                    conn.Open();

                    // Zapytanie SQL do sprawdzenia danych logowania bierzemy rcode i roomid do logowania
                    string query = "SELECT * FROM bookings WHERE ReservationCode = @reservationCode AND RoomID = @roomID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@reservationCode", reservationCode);
                        cmd.Parameters.AddWithValue("@roomID", roomID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Dane poprawne, otwarcie panelu gościa
                                MessageBox.Show("Logowanie zakończone sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Guest guest = new Guest();
                                this.Hide();
                                guest.Show();
                            }
                            else
                            {
                                // Nie znaleziono pasujących danych
                                MessageBox.Show("Niepoprawne ID rezerwacji lub ID pokoju!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Obsługa błędu połączenia
                    MessageBox.Show($"Wystąpił błąd podczas logowania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
