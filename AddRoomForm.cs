using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class AddRoomForm : Form // Dziedziczenie klasy Form z biblioteki WinForms
    {
        // Hermetyzacja: Właściwości publiczne tylko do odczytu zapewniają bezpieczny dostęp do danych użytkownika
        public string RoomNumber => textBoxRoomNumber.Text.Trim(); // Hermetyzacja: właściwość do odczytu
        public string RoomType => comboBoxRoomType.SelectedItem?.ToString(); // Hermetyzacja: właściwość do odczytu
        public decimal Price => numericUpDownPrice.Value; // Hermetyzacja: właściwość do odczytu
        public string Status => comboBoxStatus.SelectedItem?.ToString(); // Hermetyzacja: właściwość do odczytu

        public AddRoomForm()
        {
            InitializeComponent();
            LoadRoomTypesAndStatuses(); // Hermetyzacja: szczegóły inicjalizacji ukryte w metodzie pomocniczej
        }

        private void LoadRoomTypesAndStatuses()
        {
            // Hermetyzacja: Załadowanie dostępnych typów pokoi i statusów
            comboBoxRoomType.Items.AddRange(new string[] { "jednoosobowy", "dwuosobowy", "trzyosobowy" });
            comboBoxStatus.Items.AddRange(new string[] { "Wolny", "Zajęty", "Prace techniczne" });
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // Walidacja danych: Hermetyzacja zapewnia dostęp do danych użytkownika przez właściwości
            if (string.IsNullOrEmpty(RoomNumber) || string.IsNullOrEmpty(RoomType) || string.IsNullOrEmpty(Status))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(numericUpDownPrice.Value.ToString(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Proszę wprowadzić poprawną cenę!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hermetyzacja: Łańcuch połączenia z bazą danych jest ukryty w zmiennej lokalnej
            string connectionString = "Server=localhost;Port=3306;uid=root;pwd=;database=the garden hotel2;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Hermetyzacja: Szczegóły zapytania SQL są ukryte w bloku try
                    string query = @"
                INSERT INTO rooms (RoomNumber, RoomType, Price, Status)
                VALUES (@RoomNumber, @RoomType, @Price, @Status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Hermetyzacja: Przekazanie danych użytkownika jako parametrów do zapytania SQL
                        cmd.Parameters.AddWithValue("@RoomNumber", RoomNumber);
                        cmd.Parameters.AddWithValue("@RoomType", RoomType);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@Status", Status);

                        cmd.ExecuteNonQuery();

                        // Polimorfizm: Dynamiczne wywołanie metody ShowDialog() na MessageBox
                        MessageBox.Show("Pokój został pomyślnie dodany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK; // Polimorfizm: ustawienie wyniku dialogu
                        Close(); // Polimorfizm: metoda Close() dziedziczona z klasy Form
                    }
                }
                catch (Exception ex)
                {
                    // Obsługa błędów podczas pracy z bazą danych
                    MessageBox.Show($"Błąd podczas dodawania pokoju: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — przykład polimorfizmu
        }
    }
}
