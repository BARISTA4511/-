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
    public partial class TechnicianMain : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;";
        private int masterId;
        public TechnicianMain(int masterID)
        {
            InitializeComponent();
            this.masterId = masterID;
            LoadRequests();
            LoadStatusOptions();

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
            WHERE r.masterID = @masterID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@masterID", masterId);

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Проверка на наличие данных
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет заявок для данного техника.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dataGridViewRequests.DataSource = dataTable;

                        dataGridViewRequests.Columns["requestID"].HeaderText = "Id заявки";
                        dataGridViewRequests.Columns["startDate"].HeaderText = "Дата принятия заявки";
                        dataGridViewRequests.Columns["computerTechModel"].HeaderText = "Модель устройства";
                        dataGridViewRequests.Columns["problemDescryption"].HeaderText = "Описание проблемы";
                        dataGridViewRequests.Columns["requestStatus"].HeaderText = "Статус запроса";
                        dataGridViewRequests.Columns["completionDate"].HeaderText = "Дата завершения";

                        DataGridViewTextBoxColumn commentColumn = new DataGridViewTextBoxColumn();
                        commentColumn.Name = "TechnicianComment";
                        commentColumn.HeaderText = "Комментарий техника";
                        dataGridViewRequests.Columns.Add(commentColumn);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке заявок: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadStatusOptions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT requestStatusID, requestStatus FROM RequestStatus";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxStatus.Items.Add(new { Text = reader["requestStatus"].ToString(), Value = reader["requestStatusID"] });
                    }
                    comboBoxStatus.DisplayMember = "Text";
                    comboBoxStatus.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке статусов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells["requestID"].Value);
                int selectedStatusId = (int)((dynamic)comboBoxStatus.SelectedItem).Value;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Requests SET requestStatusID = @statusID WHERE requestID = @requestID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@statusID", selectedStatusId);
                    command.Parameters.AddWithValue("@requestID", requestId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Статус запроса обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRequests(); // Обновить список заявок
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении статуса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для изменения статуса.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells["requestID"].Value);

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Файлы отчетов (*.pdf;*.docx)|*.pdf;*.docx|Все файлы (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        string fileName = System.IO.Path.GetFileName(filePath);
                        byte[] fileData = System.IO.File.ReadAllBytes(filePath);

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "INSERT INTO Reports (RequestID, FileName, FileData) VALUES (@requestID, @fileName, @fileData)";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@requestID", requestId);
                            command.Parameters.AddWithValue("@fileName", fileName);
                            command.Parameters.AddWithValue("@fileData", fileData);

                            try
                            {
                                connection.Open();
                                command.ExecuteNonQuery();
                                MessageBox.Show("Файл успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при добавлении файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для прикрепления отчета.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void buttonBack_Click(object sender, EventArgs e)
        {
            MasterFirst masterForm = new MasterFirst(masterId);
            masterForm.Show();
            this.Hide();
        }


        private void buttonComment_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells["requestID"].Value);
                string comment = textBoxComment.Text.Trim(); // Получаем текст комментария из текстового поля

                // Проверка на пустой комментарий
                if (!string.IsNullOrWhiteSpace(comment))
                {
                    SaveComment(requestId, comment);
                    // Обновляем значение в ячейке после сохранения
                    dataGridViewRequests.CurrentRow.Cells["TechnicianComment"].Value = comment;
                    textBoxComment.Clear(); // Очищаем текстовое поле после добавления комментария
                }
                else
                {
                    MessageBox.Show("Комментарий не может быть пустым.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для добавления комментария.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveComment(int requestId, string comment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Проверка, существует ли уже комментарий для этой заявки
                    string checkQuery = "SELECT COUNT(*) FROM TechnicianComments WHERE requestID = @requestID";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@requestID", requestId);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Если комментарий уже существует, обновляем его
                        string updateQuery = "UPDATE TechnicianComments SET techComment = @techComment WHERE requestID = @requestID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@techComment", comment);
                        updateCommand.Parameters.AddWithValue("@requestID", requestId);
                        updateCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        string insertQuery = "INSERT INTO TechnicianComments (requestID, techComment) VALUES (@requestID, @techComment)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@requestID", requestId);
                        insertCommand.Parameters.AddWithValue("@techComment", comment);
                        insertCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении комментария: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
