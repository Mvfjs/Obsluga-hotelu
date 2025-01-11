using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public partial class AddServiceForm : Form // Dziedziczenie klasy Form z biblioteki WinForms
    {
        // Hermetyzacja: Właściwości publiczne tylko do odczytu zapewniają bezpieczny dostęp do danych użytkownika
        public string ServiceName => textBoxServiceName.Text.Trim(); // Hermetyzacja: właściwość do odczytu
        public string Description => textBoxDescription.Text.Trim(); // Hermetyzacja: właściwość do odczytu
        public decimal Price => numericUpDownPrice.Value; // Hermetyzacja: właściwość do odczytu

        public AddServiceForm()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // Walidacja danych wejściowych: Hermetyzacja zapewnia dostęp do danych użytkownika przez właściwości
            if (string.IsNullOrEmpty(ServiceName) || string.IsNullOrEmpty(Description))
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

                    // Hermetyzacja: Szczegóły zapytania SQL są ukryte w metodzie
                    string query = @"
                    INSERT INTO services (ServiceName, Description, PriceService)
                    VALUES (@ServiceName, @Description, @PriceService)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Hermetyzacja: Przekazanie danych użytkownika jako parametrów do zapytania SQL
                        cmd.Parameters.AddWithValue("@ServiceName", ServiceName);
                        cmd.Parameters.AddWithValue("@Description", Description);
                        cmd.Parameters.AddWithValue("@PriceService", Price);

                        cmd.ExecuteNonQuery();

                        // Polimorfizm: Dynamiczne wywołanie metody ShowDialog() na MessageBox
                        MessageBox.Show("Usługa została pomyślnie dodana!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK; // Polimorfizm: ustawienie wyniku dialogu
                        Close(); // Polimorfizm: metoda Close() dziedziczona z klasy Form
                    }
                }
                catch (Exception ex)
                {
                    // Obsługa błędów podczas pracy z bazą danych
                    MessageBox.Show($"Błąd podczas dodawania usługi: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddServiceForm_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — przykład polimorfizmu
        }
    }
}
