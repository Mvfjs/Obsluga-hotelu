using System;
using System.Linq;
using System.Windows.Forms;
using MySqlConnector;

namespace WinFormsApp1
{
    public abstract class ValidationForm : DatabaseForm
    {
        // Walidacja e-maila
        protected bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ShowValidationError("Adres e-mail nie może być pusty.");
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                ShowValidationError("Podano nieprawidłowy adres e-mail.");
                return false;
            }

            return true;
        }

        // Walidacja numeru telefonu
        protected bool ValidatePhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                ShowValidationError("Numer telefonu nie może być pusty.");
                return false;
            }

            if (phone.Length != 9 || !phone.All(char.IsDigit))
            {
                ShowValidationError("Numer telefonu musi zawierać 9 cyfr.");
                return false;
            }

            return true;
        }

        // Walidacja i rozdzielenie pełnego imienia i nazwiska
        protected (bool isValid, string firstName, string lastName) ValidateAndSplitFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ShowValidationError("Imię i nazwisko nie mogą być puste.");
                return (false, null, null);
            }

            // Rozdzielenie imienia i nazwiska
            string[] nameParts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length < 2)
            {
                ShowValidationError("Proszę podać zarówno imię, jak i nazwisko.");
                return (false, null, null);
            }

            string firstName = nameParts[0];
            string lastName = string.Join(" ", nameParts.Skip(1)); // Pozostałe części jako nazwisko
            return (true, firstName, lastName);
        }

        // Wyświetlenie błędu walidacji
        private void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
