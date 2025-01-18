namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonAdmin;
        private System.Windows.Forms.Button buttonGuest;
        private System.Windows.Forms.Button buttonReservation;
        private System.Windows.Forms.Label labelTitle;

        /// <summary>
        /// Czyszczenie zasobów
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Metoda do inicjalizacji komponentów
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonAdmin = new System.Windows.Forms.Button();
            buttonGuest = new System.Windows.Forms.Button();
            buttonReservation = new System.Windows.Forms.Button();
            labelTitle = new System.Windows.Forms.Label();

            // 
            // Form1
            // 
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#DAD7CD");
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(buttonAdmin);
            this.Controls.Add(buttonGuest);
            this.Controls.Add(buttonReservation);
            this.Controls.Add(labelTitle);
            this.Name = "Form1";
            this.Text = "The Garden Hotel";
            this.Load += new System.EventHandler(this.Form1_Load);

            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#344E41");
            labelTitle.Location = new System.Drawing.Point((ClientSize.Width - 250) / 2, 50);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(250, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "The Garden Hotel";
            labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // buttonAdmin
            // 
            buttonAdmin.BackColor = System.Drawing.ColorTranslator.FromHtml("#588157");
            buttonAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonAdmin.ForeColor = System.Drawing.Color.White;
            buttonAdmin.Location = new System.Drawing.Point((ClientSize.Width - 200) / 2, 150);
            buttonAdmin.Name = "buttonAdmin";
            buttonAdmin.Size = new System.Drawing.Size(200, 40);
            buttonAdmin.TabIndex = 1;
            buttonAdmin.Text = "Panel Administratora";
            buttonAdmin.UseVisualStyleBackColor = true;
            buttonAdmin.Click += new System.EventHandler(this.button1_Click);

            // 
            // buttonGuest
            // 
            buttonGuest.BackColor = System.Drawing.ColorTranslator.FromHtml("#588157");
            buttonGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonGuest.ForeColor = System.Drawing.Color.White;
            buttonGuest.Location = new System.Drawing.Point((ClientSize.Width - 200) / 2, 210);
            buttonGuest.Name = "buttonGuest";
            buttonGuest.Size = new System.Drawing.Size(200, 40);
            buttonGuest.TabIndex = 2;
            buttonGuest.Text = "Panel Gościa";
            buttonGuest.UseVisualStyleBackColor = true;
            buttonGuest.Click += new System.EventHandler(this.button2_Click);

            // 
            // buttonReservation
            // 
            buttonReservation.BackColor = System.Drawing.ColorTranslator.FromHtml("#588157");
            buttonReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonReservation.ForeColor = System.Drawing.Color.White;
            buttonReservation.Location = new System.Drawing.Point((ClientSize.Width - 200) / 2, 270);
            buttonReservation.Name = "buttonReservation";
            buttonReservation.Size = new System.Drawing.Size(200, 40);
            buttonReservation.TabIndex = 3;
            buttonReservation.Text = "Rezerwacja Pokoju";
            buttonReservation.UseVisualStyleBackColor = true;
            buttonReservation.Click += new System.EventHandler(this.button3_Click);

            // 
            // Obsługa zdarzenia Resize dla dynamicznego rozmieszczania komponentów
            // 
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Dynamiczne centrowanie komponentów
            labelTitle.Location = new System.Drawing.Point((ClientSize.Width - labelTitle.Width) / 2, 50);
            buttonAdmin.Location = new System.Drawing.Point((ClientSize.Width - buttonAdmin.Width) / 2, 150);
            buttonGuest.Location = new System.Drawing.Point((ClientSize.Width - buttonGuest.Width) / 2, 210);
            buttonReservation.Location = new System.Drawing.Point((ClientSize.Width - buttonReservation.Width) / 2, 270);
        }
    }
}
