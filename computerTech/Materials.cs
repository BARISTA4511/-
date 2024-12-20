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
    public partial class Materials : Form
    {
        public string connectionString = "Server=ADCLG1;Database=УП_Мунгалов;Trusted_Connection=True;TrustServerCertificate=true;";
        private int masterId;

        public Materials(int masterID)
        {
            InitializeComponent();
            this.masterId = masterID;

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MasterFirst masterForm = new MasterFirst(masterId);
            masterForm.Show();
            this.Hide();
        }

        private void buttonMaterial_Click(object sender, EventArgs e)
        {
            string materialName = textBoxMaterial.Text;
            string materialCountText = textBoxCount.Text;

            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(materialName) || string.IsNullOrWhiteSpace(materialCountText))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность количества
            if (!int.TryParse(materialCountText, out int materialCount))
            {
                MessageBox.Show("Количество должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Materials (MaterialName, MaterialCount) VALUES (@materialName, @materialCount)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@materialName", materialName);
                command.Parameters.AddWithValue("@materialCount", materialCount);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Материал успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Очистка полей после добавления
                    textBoxMaterial.Clear();
                    textBoxCount.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении материала: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
