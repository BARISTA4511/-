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
    public partial class ManagerMain : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;";

        public ManagerMain()
        {
            InitializeComponent();
            LoadRequests();
            LoadMasters();
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
                           r.completionDate, 
                           u1.fio AS masterFio, 
                           u2.fio AS clientFio
                    FROM Requests r
                    LEFT JOIN ComputerTechModel c ON r.computerTechModelID = c.techModelID
                    LEFT JOIN RequestStatus s ON r.requestStatusID = s.requestStatusID
                    LEFT JOIN Users u1 ON r.masterID = u1.userID
                    LEFT JOIN Users u2 ON r.clientID = u2.userID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dataGridViewRequests.DataSource = dataTable;

                    // Настройка заголовков столбцов
                    dataGridViewRequests.Columns["requestID"].HeaderText = "Id заявки";
                    dataGridViewRequests.Columns["startDate"].HeaderText = "Дата принятия заявки";
                    dataGridViewRequests.Columns["computerTechModel"].HeaderText = "Модель устройства";
                    dataGridViewRequests.Columns["problemDescryption"].HeaderText = "Описание проблемы";
                    dataGridViewRequests.Columns["requestStatus"].HeaderText = "Статус запроса";
                    dataGridViewRequests.Columns["completionDate"].HeaderText = "Дата завершения";
                    dataGridViewRequests.Columns["masterFio"].HeaderText = "ФИО техника";
                    dataGridViewRequests.Columns["clientFio"].HeaderText = "ФИО клиента";

                    // Получаем общее количество записей
                    int totalRecords = GetTotalRecordCount();
                    // Вывод количества записей
                    UpdateRecordCount(dataTable.Rows.Count, totalRecords);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке записей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetTotalRecordCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Requests";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при получении общего количества записей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }
        private void UpdateRecordCount(int displayedCount, int totalCount)
        {
            textBoxCount.Text = $"{displayedCount} из {totalCount}";
        }

        
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Autorization autorizationForm = new Autorization();
            autorizationForm.Show();
            this.Hide();
        }

        private void UpdateMasterInDatabase(object requestId, object masterId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Requests SET masterID = @masterId WHERE requestID = @requestId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@masterId", masterId);
                command.Parameters.AddWithValue("@requestId", requestId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Мастер успешно обновлен в базе данных.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении мастера в базе данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadMasters()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT u.userID, u.fio 
            FROM Users u
            JOIN UserType ut ON u.userTypeID = ut.userTypeID
            WHERE ut.userType = 'Техник'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable mastersTable = new DataTable();
                try
                {
                    connection.Open();
                    adapter.Fill(mastersTable);
                    comboBoxMaster.DataSource = mastersTable;
                    comboBoxMaster.DisplayMember = "fio";
                    comboBoxMaster.ValueMember = "userID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке мастеров: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonMaster_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.CurrentRow != null)
            {
                var selectedMasterId = comboBoxMaster.SelectedValue;
                var selectedMasterName = comboBoxMaster.Text; 

                dataGridViewRequests.CurrentRow.Cells["masterFio"].Value = selectedMasterName;

                UpdateMasterInDatabase(dataGridViewRequests.CurrentRow.Cells["requestID"].Value, selectedMasterId);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для обновления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDate_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.CurrentRow != null)
            {
                // Получаем ID заявки из текущей строки DataGridView
                var requestId = dataGridViewRequests.CurrentRow.Cells["requestID"].Value;

                // Получаем выбранную дату из DateTimePicker
                DateTime selectedDate = dateTimePickerDate.Value;

                // Обновляем дату завершения в базе данных
                UpdateCompletionDateInDatabase(requestId, selectedDate);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для обновления даты завершения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateCompletionDateInDatabase(object requestId, DateTime completionDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Requests SET completionDate = @completionDate WHERE requestID = @requestId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@completionDate", completionDate);
                command.Parameters.AddWithValue("@requestId", requestId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Дата завершения успешно обновлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRequests(); // Обновляем список заявок после изменения
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении даты завершения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
