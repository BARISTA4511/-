using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computerTech
{
    public partial class OperatorMain : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;"; private int clientId;
        private int userId;
        public OperatorMain(int clientID, int userID)
        {
            InitializeComponent();
            this.clientId = clientID;
            this.userId = userID;
            LoadRequests();
            LoadMasters();
            CalculateAverageCompletionTime();
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
                    dataGridViewAllRequests.DataSource = dataTable;

                    // Настройка заголовков столбцов
                    dataGridViewAllRequests.Columns["requestID"].HeaderText = "Id заявки";
                    dataGridViewAllRequests.Columns["startDate"].HeaderText = "Дата принятия заявки";
                    dataGridViewAllRequests.Columns["computerTechModel"].HeaderText = "Модель устройства";
                    dataGridViewAllRequests.Columns["problemDescryption"].HeaderText = "Описание проблемы";
                    dataGridViewAllRequests.Columns["requestStatus"].HeaderText = "Статус запроса";
                    dataGridViewAllRequests.Columns["completionDate"].HeaderText = "Дата завершения";
                    dataGridViewAllRequests.Columns["masterFio"].HeaderText = "ФИО техника";
                    dataGridViewAllRequests.Columns["clientFio"].HeaderText = "ФИО клиента";

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

        private void CalculateAverageCompletionTime()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT DATEDIFF(DAY, startDate, completionDate) AS Duration 
            FROM Requests 
            WHERE completionDate IS NOT NULL";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                int totalDuration = 0;
                int count = 0;

                while (reader.Read())
                {
                    totalDuration += reader.GetInt32(0); // Суммируем продолжительность
                    count++;
                }

                if (count > 0)
                {
                    double averageDuration = (double)totalDuration / count; // Рассчитываем среднее время
                    textBoxTime.Text = $"Среднее время выполнения: {averageDuration:F2} дней"; // Выводим в текстовое поле
                }
                else
                {
                    textBoxTime.Text = "Нет завершенных заявок для расчета.";
                }
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            string filterValue = textBoxSort.Text.Trim();

            if (string.IsNullOrEmpty(filterValue))
            {
                MessageBox.Show("Пожалуйста, введите значение для фильтрации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                    JOIN ComputerTechModel c ON r.computerTechModelID = c.techModelID
                    JOIN RequestStatus s ON r.requestStatusID = s.requestStatusID
                    JOIN Users u1 ON r.masterID = u1.userID
                    JOIN Users u2 ON r.clientID = u2.userID
                    WHERE 
                        r.requestID LIKE @filter OR 
                        r.startDate LIKE @filter OR 
                        c.techModel LIKE @filter OR 
                        r.problemDescryption LIKE @filter OR 
                        s.requestStatus LIKE @filter OR 
                        r.completionDate LIKE @filter OR 
                        u1.fio LIKE @filter OR 
                        u2.fio LIKE @filter";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@filter", "%" + filterValue + "%"); // Используем LIKE для фильтрации

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dataGridViewAllRequests.DataSource = dataTable; // Обновляем DataGridView с отфильтрованными данными

                    // Получаем общее количество записей
                    int totalRecords = GetTotalRecordCount();
                    // Обновляем количество выведенных записей
                    UpdateRecordCount(dataTable.Rows.Count, totalRecords);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при фильтрации записей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewAllRequests_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var newValue = dataGridViewAllRequests.CurrentCell.Value;
            var columnName = dataGridViewAllRequests.Columns[e.ColumnIndex].Name;
            var requestId = dataGridViewAllRequests.Rows[e.RowIndex].Cells["requestID"].Value; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"UPDATE Requests SET {columnName} = @newValue WHERE requestID = @requestID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@newValue", newValue);
                command.Parameters.AddWithValue("@requestID", requestId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно обновлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при обновлении записи: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewAllRequests_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewAllRequests.EndEdit();
                e.SuppressKeyPress = true; 
            }
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

        private void buttonAddMaster_Click(object sender, EventArgs e)
        {
            if (dataGridViewAllRequests.CurrentRow != null)
            {
                // Получаем выбранного мастера из ComboBox
                var selectedMasterId = comboBoxMaster.SelectedValue;
                var selectedMasterName = comboBoxMaster.Text; // Имя мастера

                // Обновляем поле masterFio в текущей строке DataGridView
                dataGridViewAllRequests.CurrentRow.Cells["masterFio"].Value = selectedMasterName;

                // Если нужно также обновить в базе данных, можно сделать это здесь
                UpdateMasterInDatabase(dataGridViewAllRequests.CurrentRow.Cells["requestID"].Value, selectedMasterId);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для обновления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            OperatorFirst operatorForm = new OperatorFirst(userId);

            operatorForm.Show();

            this.Close();
        }
    }
}
