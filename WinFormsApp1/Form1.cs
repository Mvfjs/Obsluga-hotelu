namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e) // admin button
        {
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void button2_Click(object sender, EventArgs e) // guest button
        {
            GuestLogin guestlogin = new GuestLogin();
            guestlogin.Show();

        }

        private void button3_Click(object sender, EventArgs e) // reservation button
        {
            reservation reservation = new reservation();
            reservation.Show();
        }
    }
}
