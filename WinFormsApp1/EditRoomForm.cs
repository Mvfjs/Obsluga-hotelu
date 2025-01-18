using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EditRoomForm : RoomServiceForm
    {
        public EditRoomForm()
        {
            InitializeComponent();
            LoadRooms(); // Ładowanie pokoi przy inicjalizacji
        }

        private void LoadRooms()
        {
            string query = "SELECT RoomID, RoomNumber, RoomType, Price, Status FROM rooms";
            LoadData(query, dataGridViewRooms); // Użycie wspólnej metody z klasy bazowej

            ConfigureDataGridView(); // Dostosowanie wyglądu DataGridView
        }

        private void ConfigureDataGridView()
        {
            if (dataGridViewRooms.Columns["RoomID"] != null)
            {
                dataGridViewRooms.Columns["RoomID"].ReadOnly = true;
                dataGridViewRooms.Columns["RoomID"].HeaderText = "ID Pokoju";
            }

            if (dataGridViewRooms.Columns["RoomType"] != null)
            {
                ReplaceColumnWithComboBox("RoomType", new[] { "jednoosobowy", "dwuosobowy", "trzyosobowy" });
            }

            if (dataGridViewRooms.Columns["Status"] != null)
            {
                ReplaceColumnWithComboBox("Status", new[] { "Wolny", "Zajęty", "Prace techniczne" });
            }
        }

        private void ReplaceColumnWithComboBox(string columnName, string[] options)
        {
            if (dataGridViewRooms.Columns[columnName] != null)
            {
                int columnIndex = dataGridViewRooms.Columns[columnName].Index;

                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = columnName,
                    HeaderText = dataGridViewRooms.Columns[columnName].HeaderText,
                    DataPropertyName = columnName,
                    DataSource = options,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
                };

                dataGridViewRooms.Columns.RemoveAt(columnIndex);
                dataGridViewRooms.Columns.Insert(columnIndex, comboBoxColumn);
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            DataTable changes = ((DataTable)dataGridViewRooms.DataSource).GetChanges();
            if (changes != null)
            {
                foreach (DataRow row in changes.Rows)
                {
                    string query = @"
                        UPDATE rooms 
                        SET RoomNumber = @RoomNumber, 
                            RoomType = @RoomType, 
                            Price = @Price, 
                            Status = @Status 
                        WHERE RoomID = @RoomID";

                    ExecuteSQL(query, cmd =>
                    {
                        cmd.Parameters.AddWithValue("@RoomID", row["RoomID"]);
                        cmd.Parameters.AddWithValue("@RoomNumber", row["RoomNumber"]);
                        cmd.Parameters.AddWithValue("@RoomType", row["RoomType"]);
                        cmd.Parameters.AddWithValue("@Price", row["Price"]);
                        cmd.Parameters.AddWithValue("@Status", row["Status"]);
                    });
                }

                MessageBox.Show("Zmiany zostały zapisane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRooms(); // Odświeżenie widoku po zapisaniu zmian
            }
            else
            {
                MessageBox.Show("Brak zmian do zapisania.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
