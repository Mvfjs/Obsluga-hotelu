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
        private System.Windows.Forms.DataGridView dataGridViewReservations;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewBookings = new DataGridView();
            dataGridViewGuests = new DataGridView();
            dataGridViewRooms = new DataGridView();
            dataGridViewServices = new DataGridView();
            dataGridViewServiceOrders = new DataGridView();
            buttonAddRoom = new Button();
            buttonEditRoom = new Button();
            buttonDeleteRoom = new Button();
            buttonAddService = new Button();
            buttonEditService = new Button();
            buttonDeleteService = new Button();
            dataGridViewReservations = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGuests).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReservations).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBookings
            // 
            dataGridViewBookings.BackgroundColor = Color.FromArgb(218, 215, 205);
            dataGridViewBookings.Location = new Point(10, 10);
            dataGridViewBookings.Name = "dataGridViewBookings";
            dataGridViewBookings.Size = new Size(520, 140);
            dataGridViewBookings.TabIndex = 0;
            // 
            // dataGridViewGuests
            // 
            dataGridViewGuests.BackgroundColor = Color.FromArgb(218, 215, 205);
            dataGridViewGuests.Location = new Point(10, 160);
            dataGridViewGuests.Name = "dataGridViewGuests";
            dataGridViewGuests.Size = new Size(520, 140);
            dataGridViewGuests.TabIndex = 1;
            // 
            // dataGridViewRooms
            // 
            dataGridViewRooms.BackgroundColor = Color.FromArgb(218, 215, 205);
            dataGridViewRooms.Location = new Point(10, 310);
            dataGridViewRooms.Name = "dataGridViewRooms";
            dataGridViewRooms.Size = new Size(520, 140);
            dataGridViewRooms.TabIndex = 2;
            // 
            // dataGridViewServices
            // 
            dataGridViewServices.BackgroundColor = Color.FromArgb(218, 215, 205);
            dataGridViewServices.Location = new Point(540, 10);
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.Size = new Size(520, 140);
            dataGridViewServices.TabIndex = 3;
            // 
            // dataGridViewServiceOrders
            // 
            dataGridViewServiceOrders.BackgroundColor = Color.FromArgb(218, 215, 205);
            dataGridViewServiceOrders.Location = new Point(540, 160);
            dataGridViewServiceOrders.Name = "dataGridViewServiceOrders";
            dataGridViewServiceOrders.Size = new Size(520, 140);
            dataGridViewServiceOrders.TabIndex = 4;
            // 
            // buttonAddRoom
            // 
            buttonAddRoom.BackColor = Color.FromArgb(163, 177, 138);
            buttonAddRoom.Location = new Point(540, 310);
            buttonAddRoom.Name = "buttonAddRoom";
            buttonAddRoom.Size = new Size(105, 28);
            buttonAddRoom.TabIndex = 5;
            buttonAddRoom.Text = "Dodaj Pokój";
            buttonAddRoom.UseVisualStyleBackColor = true;
            buttonAddRoom.Click += buttonAddRoom_Click;
            // 
            // buttonEditRoom
            // 
            buttonEditRoom.BackColor = Color.FromArgb(163, 177, 138);
            buttonEditRoom.Location = new Point(650, 310);
            buttonEditRoom.Name = "buttonEditRoom";
            buttonEditRoom.Size = new Size(105, 28);
            buttonEditRoom.TabIndex = 6;
            buttonEditRoom.Text = "Edytuj Pokój";
            buttonEditRoom.UseVisualStyleBackColor = true;
            buttonEditRoom.Click += buttonEditRoom_Click;
            // 
            // buttonDeleteRoom
            // 
            buttonDeleteRoom.BackColor = Color.FromArgb(163, 177, 138);
            buttonDeleteRoom.Location = new Point(760, 310);
            buttonDeleteRoom.Name = "buttonDeleteRoom";
            buttonDeleteRoom.Size = new Size(105, 28);
            buttonDeleteRoom.TabIndex = 7;
            buttonDeleteRoom.Text = "Usuń Pokój";
            buttonDeleteRoom.UseVisualStyleBackColor = true;
            buttonDeleteRoom.Click += buttonDeleteRoom_Click;
            // 
            // buttonAddService
            // 
            buttonAddService.BackColor = Color.FromArgb(163, 177, 138);
            buttonAddService.Location = new Point(540, 350);
            buttonAddService.Name = "buttonAddService";
            buttonAddService.Size = new Size(105, 28);
            buttonAddService.TabIndex = 8;
            buttonAddService.Text = "Dodaj Usługę";
            buttonAddService.UseVisualStyleBackColor = true;
            buttonAddService.Click += buttonAddService_Click;
            // 
            // buttonEditService
            // 
            buttonEditService.BackColor = Color.FromArgb(163, 177, 138);
            buttonEditService.Location = new Point(650, 350);
            buttonEditService.Name = "buttonEditService";
            buttonEditService.Size = new Size(105, 28);
            buttonEditService.TabIndex = 9;
            buttonEditService.Text = "Edytuj Usługę";
            buttonEditService.UseVisualStyleBackColor = true;
            buttonEditService.Click += buttonEditService_Click;
            // 
            // buttonDeleteService
            // 
            buttonDeleteService.BackColor = Color.FromArgb(163, 177, 138);
            buttonDeleteService.Location = new Point(760, 350);
            buttonDeleteService.Name = "buttonDeleteService";
            buttonDeleteService.Size = new Size(105, 28);
            buttonDeleteService.TabIndex = 10;
            buttonDeleteService.Text = "Usuń Usługę";
            buttonDeleteService.UseVisualStyleBackColor = true;
            buttonDeleteService.Click += buttonDeleteService_Click;
            // 
            // dataGridViewReservations
            // 
            dataGridViewReservations.BackgroundColor = Color.FromArgb(218, 215, 205);
            dataGridViewReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReservations.Location = new Point(10, 465);
            dataGridViewReservations.Name = "dataGridViewReservations";
            dataGridViewReservations.Size = new Size(520, 140);
            dataGridViewReservations.TabIndex = 11;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 215, 205);
            ClientSize = new Size(1255, 649);
            Controls.Add(dataGridViewReservations);
            Controls.Add(buttonAddRoom);
            Controls.Add(buttonEditRoom);
            Controls.Add(buttonDeleteRoom);
            Controls.Add(buttonAddService);
            Controls.Add(buttonEditService);
            Controls.Add(buttonDeleteService);
            Controls.Add(dataGridViewBookings);
            Controls.Add(dataGridViewGuests);
            Controls.Add(dataGridViewRooms);
            Controls.Add(dataGridViewServices);
            Controls.Add(dataGridViewServiceOrders);
            Name = "Admin";
            Text = "Admin Panel";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGuests).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServiceOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReservations).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
