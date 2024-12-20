using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computerTech
{
    public partial class History : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;"; 
        
        public History ()
        {
            InitializeComponent();

            LoadLoginHistory();
        }

        private void LoadLoginHistory(string filter = "")
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT login, attemptTime, isSuccessful FROM LoginHistory";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += " WHERE Login LIKE @filter";
                }
                query += " ORDER BY attemptTime DESC"; // Сортировка по дате

                SqlCommand command = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(filter))
                {
                    command.Parameters.AddWithValue("@filter", "%" + filter + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine($"Login: {row["login"]}, AttemptTime: {row["attemptTime"]}, IsSuccessful: {row["isSuccessful"]}");
                }

                dataGridViewHistory.DataSource = dataTable;

                dataGridViewHistory.Columns["login"].HeaderText = "логин";
                dataGridViewHistory.Columns["attemptTime"].HeaderText = "Время входа";
                dataGridViewHistory.Columns["isSuccessful"].HeaderText = "Успешность входа";
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            string filter = textBoxLogin.Text;
            LoadLoginHistory(filter);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Autorization autorizationForm = new Autorization();
            autorizationForm.Show();
            this.Hide(); 
        }
    }
}
