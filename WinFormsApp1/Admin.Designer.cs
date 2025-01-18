namespace WinFormsApp1
{
    partial class Admin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewBookings;
        private System.Windows.Forms.DataGridView dataGridViewGuests;
        private System.Windows.Forms.DataGridView dataGridViewRooms;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.DataGridView dataGridViewServiceOrders;
        private System.Windows.Forms.Button buttonAddRoom;
        private System.Windows.Forms.Button buttonEditRoom;
        private System.Windows.Forms.Button buttonDeleteRoom;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonEditService;
        private System.Windows.Forms.Button buttonDeleteService;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button buttonRefresh;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewBookings = new DataGridView();
            dataGridViewGuests = new DataGridView();
            dataGridViewRooms = new DataGridView();
            dataGridViewServices = new DataGridView();
            dataGridViewServiceOrders = new DataGridView();
            buttonAddRoom = CreateButton("Dodaj Pokój", buttonAddRoom_Click);
            buttonEditRoom = CreateButton("Edytuj Pokój", buttonEditRoom_Click);
            buttonDeleteRoom = CreateButton("Usuń Pokój", buttonDeleteRoom_Click);
            buttonAddService = CreateButton("Dodaj Usługę", buttonAddService_Click);
            buttonEditService = CreateButton("Edytuj Usługę", buttonEditService_Click);
            buttonDeleteService = CreateButton("Usuń Usługę", buttonDeleteService_Click);
            buttonRefresh = CreateButton("Odśwież dane", ButtonRefresh_Click);
            tableLayoutPanel = new TableLayoutPanel();
            buttonPanel = new FlowLayoutPanel();
            labelBookings = new Label { Text = "Rezerwacje", TextAlign = ContentAlignment.MiddleLeft };
            labelGuests = new Label { Text = "Goście", TextAlign = ContentAlignment.MiddleLeft };
            labelRooms = new Label { Text = "Pokoje", TextAlign = ContentAlignment.MiddleLeft };
            labelServices = new Label { Text = "Usługi", TextAlign = ContentAlignment.MiddleLeft };
            labelServiceOrders = new Label { Text = "Zamówienia Usług", TextAlign = ContentAlignment.MiddleLeft };

            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGuests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceOrders).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();

            // Configure TableLayoutPanel
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount = 10;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Label for Bookings
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // DataGridView Bookings
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Label for Guests
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // DataGridView Guests
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Label for Rooms
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // DataGridView Rooms
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Label for Services
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // DataGridView Services
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Label for Service Orders
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F)); // DataGridView Service Orders
            tableLayoutPanel.Controls.Add(labelBookings, 0, 0);
            tableLayoutPanel.Controls.Add(dataGridViewBookings, 0, 1);
            tableLayoutPanel.Controls.Add(labelGuests, 0, 2);
            tableLayoutPanel.Controls.Add(dataGridViewGuests, 0, 3);
            tableLayoutPanel.Controls.Add(labelRooms, 0, 4);
            tableLayoutPanel.Controls.Add(dataGridViewRooms, 0, 5);
            tableLayoutPanel.Controls.Add(labelServices, 0, 6);
            tableLayoutPanel.Controls.Add(dataGridViewServices, 0, 7);
            tableLayoutPanel.Controls.Add(labelServiceOrders, 0, 8);
            tableLayoutPanel.Controls.Add(dataGridViewServiceOrders, 0, 9);
            tableLayoutPanel.Controls.Add(buttonPanel, 1, 0);
            tableLayoutPanel.SetRowSpan(buttonPanel, 10);

            // Configure DataGridViews
            ConfigureDataGridView(dataGridViewBookings);
            ConfigureDataGridView(dataGridViewGuests);
            ConfigureDataGridView(dataGridViewRooms);
            ConfigureDataGridView(dataGridViewServices);
            ConfigureDataGridView(dataGridViewServiceOrders);

            // Configure ButtonPanel
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.FlowDirection = FlowDirection.TopDown;
            buttonPanel.Controls.Add(buttonAddRoom);
            buttonPanel.Controls.Add(buttonEditRoom);
            buttonPanel.Controls.Add(buttonDeleteRoom);
            buttonPanel.Controls.Add(buttonAddService);
            buttonPanel.Controls.Add(buttonEditService);
            buttonPanel.Controls.Add(buttonDeleteService);
            buttonPanel.Controls.Add(buttonRefresh);

            // Admin Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(1250, 850);
            Controls.Add(tableLayoutPanel);
            MinimumSize = new Size(1000, 700);
            Name = "Admin";
            Text = "Admin Panel";
            Load += Admin_Load;

            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGuests).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceOrders).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
        

        private static void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#A3B18A");
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
        }

        private static Button CreateButton(string text, EventHandler onClick)
        {
            var button = new Button
            {
                Text = text,
                Size = new Size(150, 40),
                UseVisualStyleBackColor = false,
                BackColor = ColorTranslator.FromHtml("#588157"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(10)
            };

            if (onClick != null)
            {
                button.Click += onClick;
            }

            return button;
        }
    }
}
