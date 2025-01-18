using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AdminLogin : Form // Dziedziczenie klasy Form
    {
        private string hashedPassword; // Przechowywanie hasła w postaci haszowanej

        public AdminLogin()
        {
            InitializeComponent();
            // Generowanie haszowanego hasła (przykład inicjalizacji poprawnego loginu i hasła)
            hashedPassword = HashPassword("123"); // "123" to przykładowe hasło
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hermetyzacja: Dane logowania są przechowywane w zmiennych lokalnych
            string correctLogin = "123"; // Przykładowe dane logowania

            // Hermetyzacja: Pobieranie danych wprowadzonych przez użytkownika z pól tekstowych
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Sprawdzanie poprawności loginu i hasła
            if (login == correctLogin && VerifyPassword(password, hashedPassword))
            {
                // Polimorfizm: Dynamiczne otwieranie nowego formularza
                MessageBox.Show("Logowanie zakończone sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin admin = new Admin(); // Tworzenie instancji klasy Admin
                this.Hide(); // Polimorfizm: Ukrycie bieżącego formularza
                admin.Show(); // Polimorfizm: Otwieranie nowego formularza
            }
            else
            {
                // Obsługa błędnych danych logowania
                MessageBox.Show("Niepoprawny login lub hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — polimorfizm
            // Maskowanie hasła w polu tekstowym
            textBox2.UseSystemPasswordChar = true; // Ustawienie maskowania hasła
        }

        // Funkcja do haszowania hasła
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Konwersja na zapis szesnastkowy
                }
                return builder.ToString();
            }
        }

        // Funkcja do weryfikacji hasła
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedEnteredPassword == storedHashedPassword;
        }
    }
}
