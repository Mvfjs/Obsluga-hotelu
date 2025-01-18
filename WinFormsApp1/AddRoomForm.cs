using System;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class AddRoomForm : DatabaseForm // Dziedziczenie klasy DatabaseForm
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

        /// Hermetyzacja: Metoda pomocnicza do załadowania dostępnych typów pokoi i statusów.
        /// Zapewnia enkapsulację logiki inicjalizacji pól wyboru.
        private void LoadRoomTypesAndStatuses()
        {
            comboBoxRoomType.Items.AddRange(new string[] { "jednoosobowy", "dwuosobowy", "trzyosobowy" });
            comboBoxStatus.Items.AddRange(new string[] { "Wolny", "Zajęty", "Prace techniczne" });
        }

        /// Obsługa przycisku dodawania pokoju.
        /// Zastosowano hermetyzację do walidacji danych oraz pracy z bazą danych.
        /// Polimorfizm: Dynamiczne wywołanie metod dziedziczonych z klasy Form.
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // Hermetyzacja: Pobranie danych użytkownika z właściwości
            if (string.IsNullOrEmpty(RoomNumber) || string.IsNullOrEmpty(RoomType) || string.IsNullOrEmpty(Status))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Price <= 0)
            {
                MessageBox.Show("Proszę wprowadzić poprawną cenę!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Polimorfizm: Wywołanie metody ExecuteQuery z klasy bazowej DatabaseForm
                ExecuteQuery(@"
                    INSERT INTO rooms (RoomNumber, RoomType, Price, Status)
                    VALUES (@RoomNumber, @RoomType, @Price, @Status)", cmd =>
                {
                    cmd.Parameters.AddWithValue("@RoomNumber", RoomNumber);
                    cmd.Parameters.AddWithValue("@RoomType", RoomType);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Status", Status);
                });

                // Polimorfizm: Dynamiczne wywołanie metody ShowDialog() na MessageBox
                MessageBox.Show("Pokój został pomyślnie dodany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK; // Polimorfizm: ustawienie wyniku dialogu
                Close(); // Polimorfizm: metoda Close() dziedziczona z klasy Form
            }
            catch (Exception ex)
            {
                // Obsługa błędów podczas pracy z bazą danych
                MessageBox.Show($"Błąd podczas dodawania pokoju: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Polimorfizm: Nadpisanie metody dziedziczonej z klasy Form.
        /// Możliwość dodatkowej konfiguracji po załadowaniu formularza.
        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — przykład polimorfizmu
        }
    }
}
