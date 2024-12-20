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
    public partial class CustomerMain : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;"; private int clientId; // ID клиента, который авторизовался

        public CustomerMain(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId; // Сохраняем ID клиента
            LoadComboBoxes();
        }
        private void LoadComboBoxes()
        {
            // Заполнение comboBoxType из таблицы ComputerTechType
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT techTypeID, techType FROM ComputerTechType";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxType.Items.Add(new ComboBoxItem
                        {
                            ID = reader.GetInt32(0), // techTypeID
                            Name = reader.GetString(1) // techType
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке типов техники: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public class ComboBoxItem
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name; // Это то, что будет отображаться в комбобоксе
            }
        }
        private void comboBoxType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Очистка comboBoxModel
            comboBoxModel.Items.Clear();

            // Получаем выбранный тип
            var selectedType = (ComboBoxItem)comboBoxType.SelectedItem;
            if (selectedType != null)
            {
                // Заполнение comboBoxModel из таблицы ComputerTechModel в зависимости от выбранного techTypeID
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT techModelID, techModel FROM ComputerTechModel WHERE techTypeID = @techTypeID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@techTypeID", selectedType.ID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBoxModel.Items.Add(new ComboBoxItem
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке моделей техники: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedItem == null || comboBoxModel.SelectedItem == null || string.IsNullOrWhiteSpace(richTextBoxProblem.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedModel = (ComboBoxItem)comboBoxModel.SelectedItem;
            if (selectedModel == null)
            {
                MessageBox.Show("Выбранная модель не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Запись данных в таблицу Requests
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Requests (startDate, computerTechModelID, problemDescryption, requestStatusID, completionDate, masterID, clientID) " +
                               "VALUES (@startDate, @computerTechModelID, @problemDescryption, @requestStatusID, @completionDate, @masterID, @clientID)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@startDate", DateTime.Now);
                command.Parameters.AddWithValue("@computerTechModelID", selectedModel.ID);
                command.Parameters.AddWithValue("@problemDescryption", richTextBoxProblem.Text);
                command.Parameters.AddWithValue("@requestStatusID", 3); // Статус запроса
                command.Parameters.AddWithValue("@completionDate", DBNull.Value); // NULL для completionDate
                command.Parameters.AddWithValue("@masterID", DBNull.Value); // NULL для masterID
                command.Parameters.AddWithValue("@clientID", clientId); // ID клиента

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запрос успешно отправлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при отправке запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
