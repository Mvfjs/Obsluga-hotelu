using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Guest : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.ListBox listBoxSelectedServices;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonConfirmServices;

        /// <summary>
        /// Zwolnij zasoby
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
        /// Inicjalizacja komponentów
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewServices = new DataGridView();
            listBoxSelectedServices = new ListBox();
            buttonAddService = new Button();
            buttonConfirmServices = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            SuspendLayout();

            // Kolor tła formularza
            this.BackColor = ColorTranslator.FromHtml("#DAD7CD");

            // 
            // dataGridViewServices
            // 
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.Location = new Point(10, 11);
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.Size = new Size(665, 234);
            dataGridViewServices.TabIndex = 0;
            dataGridViewServices.BackgroundColor = ColorTranslator.FromHtml("#A3B18A");
            dataGridViewServices.ForeColor = ColorTranslator.FromHtml("#344E41");
            dataGridViewServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServices.ScrollBars = ScrollBars.Both;

            // 
            // listBoxSelectedServices
            // 
            listBoxSelectedServices.Location = new Point(44, 262);
            listBoxSelectedServices.Name = "listBoxSelectedServices";
            listBoxSelectedServices.Size = new Size(263, 134);
            listBoxSelectedServices.TabIndex = 1;
            listBoxSelectedServices.BackColor = ColorTranslator.FromHtml("#A3B18A");
            listBoxSelectedServices.ForeColor = ColorTranslator.FromHtml("#344E41");
            listBoxSelectedServices.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // 
            // buttonAddService
            // 
            buttonAddService.Location = new Point(350, 262);
            buttonAddService.Name = "buttonAddService";
            buttonAddService.Size = new Size(263, 28);
            buttonAddService.TabIndex = 2;
            buttonAddService.Text = "Dodaj usługę";
            buttonAddService.UseVisualStyleBackColor = true;
            buttonAddService.BackColor = ColorTranslator.FromHtml("#588157");
            buttonAddService.ForeColor = Color.White;
            buttonAddService.FlatStyle = FlatStyle.Flat;
            buttonAddService.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddService.MouseEnter += ButtonAddService_MouseEnter;
            buttonAddService.MouseLeave += ButtonAddService_MouseLeave;
            buttonAddService.Click += new EventHandler(ButtonAddService_Click);

            // 
            // buttonConfirmServices
            // 
            buttonConfirmServices.Location = new Point(44, 468);
            buttonConfirmServices.Name = "buttonConfirmServices";
            buttonConfirmServices.Size = new Size(263, 28);
            buttonConfirmServices.TabIndex = 3;
            buttonConfirmServices.Text = "Potwierdź usługi";
            buttonConfirmServices.UseVisualStyleBackColor = true;
            buttonConfirmServices.BackColor = ColorTranslator.FromHtml("#588157");
            buttonConfirmServices.ForeColor = Color.White;
            buttonConfirmServices.FlatStyle = FlatStyle.Flat;
            buttonConfirmServices.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonConfirmServices.MouseEnter += ButtonConfirmServices_MouseEnter;
            buttonConfirmServices.MouseLeave += ButtonConfirmServices_MouseLeave;
            buttonConfirmServices.Click += new EventHandler(ButtonConfirmServices_Click);

            // 
            // Guest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 562);
            Controls.Add(dataGridViewServices);
            Controls.Add(listBoxSelectedServices);
            Controls.Add(buttonAddService);
            Controls.Add(buttonConfirmServices);
            Name = "Guest";
            Text = "Panel Gościa";
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Zmiana koloru przycisku po najechaniu
        private void ButtonAddService_MouseEnter(object sender, EventArgs e)
        {
            buttonAddService.BackColor = ColorTranslator.FromHtml("#A3B18A");
        }

        private void ButtonAddService_MouseLeave(object sender, EventArgs e)
        {
            buttonAddService.BackColor = ColorTranslator.FromHtml("#588157");
        }

        private void ButtonConfirmServices_MouseEnter(object sender, EventArgs e)
        {
            buttonConfirmServices.BackColor = ColorTranslator.FromHtml("#A3B18A");
        }

        private void ButtonConfirmServices_MouseLeave(object sender, EventArgs e)
        {
            buttonConfirmServices.BackColor = ColorTranslator.FromHtml("#588157");
        }

        // Obsługa zdarzeń
        private void ButtonAddService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                try
                {
                    // Pobranie danych wybranej usługi
                    string serviceName = dataGridViewServices.SelectedRows[0].Cells["ServiceName"].Value?.ToString();
                    string price = dataGridViewServices.SelectedRows[0].Cells["PriceService"].Value?.ToString();

                    if (!string.IsNullOrEmpty(serviceName) && !string.IsNullOrEmpty(price))
                    {
                        // Dodanie usługi do listBoxSelectedServices
                        listBoxSelectedServices.Items.Add($"{serviceName} - {price} zł");
                    }
                    else
                    {
                        MessageBox.Show("Nie można dodać usługi. Sprawdź dane usługi.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawania usługi: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać usługę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonConfirmServices_Click(object sender, EventArgs e)
        {
            if (listBoxSelectedServices.Items.Count == 0)
            {
                MessageBox.Show("Brak wybranych usług do potwierdzenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (var item in listBoxSelectedServices.Items)
                {
                    // Parsowanie wybranych usług
                    string[] parts = item.ToString().Split('-');
                    string serviceName = parts[0].Trim();
                    string price = parts[1].Trim();

                    // Symulacja zapisu do bazy danych lub potwierdzenia usługi
                    Console.WriteLine($"Potwierdzono usługę: {serviceName}, Cena: {price}");
                }

                MessageBox.Show("Usługi zostały pomyślnie potwierdzone.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBoxSelectedServices.Items.Clear(); // Czyszczenie listy po potwierdzeniu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas potwierdzania usług: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
