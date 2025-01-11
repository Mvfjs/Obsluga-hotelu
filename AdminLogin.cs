using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AdminLogin : Form // Dziedziczenie klasy Form z biblioteki WinForms
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hermetyzacja: Dane logowania są przechowywane w zmiennych lokalnych
            string correctLogin = "123"; // Przykładowe dane logowania (w rzeczywistości hasła nie powinny być zapisane w kodzie)
            string correctPassword = "123";

            // Hermetyzacja: Pobieranie danych wprowadzonych przez użytkownika z pól tekstowych
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Walidacja danych wejściowych
            if (login == correctLogin && password == correctPassword)
            {
                // Polimorfizm: Dynamiczne otwieranie nowego formularza
                MessageBox.Show("Logowanie zakończone sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin Admin = new Admin(); // Tworzenie instancji klasy Admin
                this.Hide(); // Polimorfizm: Ukrycie bieżącego formularza
                Admin.Show(); // Polimorfizm: Otwieranie nowego formularza
            }
            else
            {
                // Obsługa błędnych danych logowania
                MessageBox.Show("Niepoprawny login lub hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            // Metoda dziedziczona z klasy Form, możliwość nadpisania — przykład polimorfizmu
        }
    }
}
