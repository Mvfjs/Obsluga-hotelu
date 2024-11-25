using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadAvailableRooms();

            // Konfiguracja DataGridView
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
        }

        private void LoadAvailableRooms()
        {
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT RoomID, CONCAT(RoomID, ' - ', RoomType, ' - ', PricePerNight, ' zł') AS RoomInfo \r\nFROM rooms \r\nWHERE RoomStatus = 'wolny'\r\n";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Sprawdzenie, czy wczytano jakiekolwiek dane
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Brak dostępnych pokoi!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Jeśli są dane, przypisujemy je do ComboBox
                            comboBox.DataSource = dataTable;
                            comboBox.DisplayMember = "RoomInfo";
                            comboBox.ValueMember = "RoomID";

                            // Opcjonalnie ustawienie pustego wyboru w ComboBox (jeśli potrzebne)
                            comboBox.SelectedIndex = -1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania pokoi: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            string fullName = textBoxName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxPhone.Text.Trim();
            string selectedRoomID = comboBox.SelectedValue?.ToString();
            DateTime checkInDate = dateTimePickerCheckIn.Value.Date;
            DateTime checkOutDate = dateTimePickerCheckOut.Value.Date;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(selectedRoomID))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkInDate >= checkOutDate)
            {
                MessageBox.Show("Data wyjazdu musi być późniejsza niż data przyjazdu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reservationCode = Guid.NewGuid().ToString("N").Substring(0, 8); // Generowanie kodu rezerwacji

            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string insertQuery = @"
                        INSERT INTO bookings (FullName, Email, PhoneNumber, RoomID, CheckInDate, CheckOutDate, ReservationCode)
                        VALUES (@FullName, @Email, @PhoneNumber, @RoomID, @CheckInDate, @CheckOutDate, @ReservationCode);
                        
                        UPDATE rooms SET RoomStatus = 'zajęty' WHERE RoomID = @RoomID;";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phone);
                        cmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        cmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                        cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                        cmd.Parameters.AddWithValue("@ReservationCode", reservationCode);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Rezerwacja została pomyślnie utworzona!\nKod rezerwacji: {reservationCode}\nNumer pokoju: {selectedRoomID}",
                                    "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas zapisywania rezerwacji: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DataGridView dataGridView;

        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            comboBox = new ComboBox();
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPhone = new TextBox();
            dateTimePickerCheckIn = new DateTimePicker();
            dateTimePickerCheckOut = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(240, 150);
            dataGridView.TabIndex = 0;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(12, 335);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(121, 23);
            comboBox.TabIndex = 1;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 200);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(12, 229);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 23);
            textBoxEmail.TabIndex = 3;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(12, 258);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(100, 23);
            textBoxPhone.TabIndex = 4;
            // 
            // dateTimePickerCheckIn
            // 
            dateTimePickerCheckIn.Location = new Point(2, 394);
            dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            dateTimePickerCheckIn.Size = new Size(200, 23);
            dateTimePickerCheckIn.TabIndex = 5;
            // 
            // dateTimePickerCheckOut
            // 
            dateTimePickerCheckOut.Location = new Point(285, 394);
            dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            dateTimePickerCheckOut.Size = new Size(200, 23);
            dateTimePickerCheckOut.TabIndex = 6;
            // 
            // ReservationForm
            // 
            ClientSize = new Size(1021, 666);
            Controls.Add(dateTimePickerCheckOut);
            Controls.Add(dateTimePickerCheckIn);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Controls.Add(comboBox);
            Controls.Add(dataGridView);
            Name = "ReservationForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox comboBox;
        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private TextBox textBoxPhone;
        private DateTimePicker dateTimePickerCheckIn;
        private DateTimePicker dateTimePickerCheckOut;

    }

    public partial class reservation : Form
    {
        public reservation()
        {
            InitializeComponent();
        }

        private void reservation_Load(object sender, EventArgs e)
        {
            LoadAvailableRooms();

            // Konfiguracja DataGridView
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
        }

        private void LoadAvailableRooms()
        {
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            RoomID AS 'Numer pokoju', 
                            RoomType AS 'Typ pokoju', 
                            Price AS 'Cena za noc'
                        FROM rooms
                        WHERE Status = 'Wolny'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas ładowania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedRoom = dataGridView.Rows[e.RowIndex].Cells["Numer pokoju"].Value.ToString();
                MessageBox.Show($"Wybrano pokój: {selectedRoom}", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}