using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class reservation : Form
    {
        private string selectedRoomID;
        private Dictionary<DateTime, string> roomAvailability; // Zajętość pokoi (klucz: data, wartość: status)
        private DateTime selectedCheckInDate;
        private DateTime selectedCheckOutDate;

        public reservation()
        {
            InitializeComponent();
        }

        private void reservation_Load(object sender, EventArgs e)
        {
            LoadAvailableRooms();

            // Konfiguracja DataGridView
            dataGridViewRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRooms.AllowUserToAddRows = false;

            // Zdarzenie kliknięcia w wiersz DataGridView
            dataGridViewRooms.CellClick += DataGridViewRooms_CellClick;

            // Konfiguracja kalendarza
            monthCalendarAvailability.MaxSelectionCount = 30; // Maksymalny zakres wyboru (np. 30 dni)
            monthCalendarAvailability.DateChanged += MonthCalendarAvailability_DateChanged;

            selectedCheckInDate = monthCalendarAvailability.SelectionStart;
            selectedCheckOutDate = monthCalendarAvailability.SelectionEnd;
        }

        private void LoadAvailableRooms()
        {
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT RoomID AS 'ID Pokoju', 
                               RoomType AS 'Typ Pokoju', 
                               Price AS 'Cena za noc', 
                               Status AS 'Status'
                        FROM rooms";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridViewRooms.DataSource = dataTable; // Wypełnij DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania pokoi: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRoomID = dataGridViewRooms.Rows[e.RowIndex].Cells["ID Pokoju"].Value.ToString();
                MessageBox.Show($"Wybrano pokój o ID: {selectedRoomID}", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRoomAvailability();
            }
        }

        private void LoadRoomAvailability()
        {
            roomAvailability = new Dictionary<DateTime, string>();
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT CheckINDate, CheckOUTDate 
                        FROM bookings 
                        WHERE RoomID = @RoomID";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomID", selectedRoomID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime checkInDate = reader.GetDateTime("CheckINDate");
                                DateTime checkOutDate = reader.GetDateTime("CheckOUTDate");

                                for (DateTime date = checkInDate; date < checkOutDate; date = date.AddDays(1))
                                {
                                    roomAvailability[date] = "Zajęty"; // Oznacz daty jako zajęte
                                }
                            }
                        }
                    }

                    UpdateCalendar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas ładowania dostępności: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateCalendar()
        {
            monthCalendarAvailability.RemoveAllBoldedDates();

            foreach (var date in roomAvailability)
            {
                if (date.Value == "Zajęty")
                {
                    // Pogrubione zajęte daty
                    monthCalendarAvailability.AddBoldedDate(date.Key);
                }
            }

            monthCalendarAvailability.UpdateBoldedDates();
        }

        private void MonthCalendarAvailability_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedCheckInDate = e.Start;
            selectedCheckOutDate = e.End;

            if (roomAvailability != null)
            {
                foreach (DateTime date in roomAvailability.Keys)
                {
                    if (roomAvailability[date] == "Zajęty" && (date >= selectedCheckInDate && date < selectedCheckOutDate))
                    {
                        MessageBox.Show("Wybrany zakres dat obejmuje zajęte terminy. Proszę wybrać inny zakres.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            labelTotalPrice.Text = $"Cena całkowita: {CalculatePrice()} zł";
        }

        private decimal CalculatePrice()
        {
            if (!string.IsNullOrEmpty(selectedRoomID) && selectedCheckInDate < selectedCheckOutDate)
            {
                int days = (selectedCheckOutDate - selectedCheckInDate).Days;

                string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        string query = "SELECT Price FROM rooms WHERE RoomID = @RoomID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                decimal pricePerNight = Convert.ToDecimal(result);
                                return days * pricePerNight;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd przy obliczaniu ceny: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return 0;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedRoomID))
            {
                MessageBox.Show("Proszę wybrać pokój!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = textBoxName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxPhone.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Proszę podać poprawny adres e-mail!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (phone.Length != 9 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Numer telefonu musi zawierać 9 cyfr!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedCheckInDate >= selectedCheckOutDate)
            {
                MessageBox.Show("Data wyjazdu musi być późniejsza niż data przyjazdu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Rozdzielenie imienia i nazwiska
            string[] nameParts = fullName.Split(' ');
            string firstName = nameParts[0];
            string lastName = nameParts.Length > 1 ? string.Join(" ", nameParts[1..]) : "";

            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Dodanie gościa do tabeli guests
                    string guestInsertQuery = @"
                INSERT INTO guests (FirstName, LastName, Email, PhoneNumber)
                VALUES (@FirstName, @LastName, @Email, @PhoneNumber)
                ON DUPLICATE KEY UPDATE GuestID = LAST_INSERT_ID(GuestID);";

                    int guestID;
                    using (MySqlCommand cmd = new MySqlCommand(guestInsertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phone);

                        cmd.ExecuteNonQuery();
                        guestID = Convert.ToInt32(cmd.LastInsertedId); // Pobierz GuestID
                    }

                    // Generowanie unikalnego kodu rezerwacji
                    string reservationCode = GenerateReservationCode(conn);

                    // Dodanie rezerwacji do tabeli bookings
                    string bookingInsertQuery = @"
                INSERT INTO bookings (GuestID, RoomID, CheckINDate, CheckOUTDate, TotalPrice, ReservationCode, BookingStatus)
                VALUES (@GuestID, @RoomID, @CheckINDate, @CheckOUTDate, @TotalPrice, @ReservationCode, 'Potwierdzono');";

                    using (MySqlCommand cmd = new MySqlCommand(bookingInsertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@GuestID", guestID);
                        cmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        cmd.Parameters.AddWithValue("@CheckINDate", selectedCheckInDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@CheckOUTDate", selectedCheckOutDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@TotalPrice", CalculatePrice());
                        cmd.Parameters.AddWithValue("@ReservationCode", reservationCode);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Rezerwacja została pomyślnie utworzona!\nKod rezerwacji: {reservationCode}",
                                    "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Odśwież dostępność
                    LoadRoomAvailability();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas zapisywania rezerwacji: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                private string GenerateReservationCode(MySqlConnection conn)
        {
            string query = "SELECT MAX(ReservationCode) FROM bookings WHERE ReservationCode LIKE 'BOOK%'";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string lastCode = result.ToString();
                    if (lastCode.StartsWith("BOOK"))
                    {
                        int lastNumber = int.Parse(lastCode.Substring(4));
                        return $"BOOK{lastNumber + 1:D3}";
                    }
                }
            }
            return "BOOK001"; // Domyślny kod dla pierwszej rezerwacji
        }

    }
}

 
