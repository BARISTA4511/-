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
    public partial class clientRequests : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;"; private int clientId; // ID клиента, который авторизовался
        public clientRequests(int clientID)
        {
            InitializeComponent();
            this.clientId = clientID;
            LoadRequests();
        }
        private void LoadRequests()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT r.requestID, r.startDate, 
                   c.techModel AS computerTechModel, 
                   r.problemDescryption, 
                   s.requestStatus AS requestStatus, 
                   r.completionDate 
            FROM Requests r
            JOIN ComputerTechModel c ON r.computerTechModelID = c.techModelID
            JOIN RequestStatus s ON r.requestStatusID = s.requestStatusID
            WHERE r.clientID = @clientID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@clientID", clientId);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Проверка на наличие данных
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет заявок для данного клиента.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dataGridViewRequests.DataSource = dataTable;

                        // Настройка заголовков столбцов
                        dataGridViewRequests.Columns["requestID"].HeaderText = "Id заявки";
                        dataGridViewRequests.Columns["startDate"].HeaderText = "Дата принятия заявки";
                        dataGridViewRequests.Columns["computerTechModel"].HeaderText = "Модель устройства";
                        dataGridViewRequests.Columns["problemDescryption"].HeaderText = "Описание проблемы";
                        dataGridViewRequests.Columns["requestStatus"].HeaderText = "Статус запроса";
                        dataGridViewRequests.Columns["completionDate"].HeaderText = "Дата завершения";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке заявок: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewRequests_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRequests.Columns["problemDescryption"].Index)
            {
                int requestId = Convert.ToInt32(dataGridViewRequests.Rows[e.RowIndex].Cells["requestID"].Value);
                string newDescription = dataGridViewRequests.Rows[e.RowIndex].Cells["problemDescryption"].Value.ToString();

                UpdateProblemDescription(requestId, newDescription);
            }
        }

        private void UpdateProblemDescription(int requestId, string newDescription)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Requests SET problemDescryption = @problemDescryption WHERE requestID = @requestID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@problemDescryption", newDescription);
                command.Parameters.AddWithValue("@requestID", requestId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Описание проблемы успешно обновлено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении описания проблемы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count > 0)
            {
                // Получаем ID выбранной заявки
                int requestId = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells["requestID"].Value);

                // Подтверждение удаления
                var result = MessageBox.Show("Вы уверены, что хотите удалить эту заявку?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteRequest(requestId);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRequest(int requestId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Requests WHERE requestID = @requestID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@requestID", requestId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Заявка успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRequests(); // Обновляем список заявок
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении заявки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            CustomerFirst customerForm = new CustomerFirst(clientId);
            customerForm.Show();
            this.Close();
        }
    }
}
