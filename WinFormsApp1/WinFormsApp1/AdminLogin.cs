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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string correctLogin = "123";
            string correctPassword = "123";

            string login = textBox1.Text;
            string password = textBox2.Text;

            if (login == correctLogin && password == correctPassword)
            {
                MessageBox.Show("Logowanie zakończone sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin Admin = new Admin();
                this.Hide();
                Admin.Show();
            }
            else
            {
                MessageBox.Show("Niepoprawny login lub hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
