namespace computerTech
{
    partial class ManagerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            this.comboBoxMaster = new System.Windows.Forms.ComboBox();
            this.buttonMaster = new System.Windows.Forms.Button();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.buttonDate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.dataGridViewRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Location = new System.Drawing.Point(12, 51);
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.Size = new System.Drawing.Size(437, 181);
            this.dataGridViewRequests.TabIndex = 28;
            // 
            // comboBoxMaster
            // 
            this.comboBoxMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(211)))), ((int)(((byte)(210)))));
            this.comboBoxMaster.ForeColor = System.Drawing.Color.Black;
            this.comboBoxMaster.FormattingEnabled = true;
            this.comboBoxMaster.Location = new System.Drawing.Point(15, 316);
            this.comboBoxMaster.Name = "comboBoxMaster";
            this.comboBoxMaster.Size = new System.Drawing.Size(188, 21);
            this.comboBoxMaster.TabIndex = 31;
            // 
            // buttonMaster
            // 
            this.buttonMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(91)))));
            this.buttonMaster.FlatAppearance.BorderSize = 0;
            this.buttonMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaster.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMaster.ForeColor = System.Drawing.Color.White;
            this.buttonMaster.Location = new System.Drawing.Point(15, 353);
            this.buttonMaster.Name = "buttonMaster";
            this.buttonMaster.Size = new System.Drawing.Size(188, 38);
            this.buttonMaster.TabIndex = 32;
            this.buttonMaster.Text = "изменить";
            this.buttonMaster.UseVisualStyleBackColor = false;
            this.buttonMaster.Click += new System.EventHandler(this.buttonMaster_Click);
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.CalendarForeColor = System.Drawing.Color.White;
            this.dateTimePickerDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.dateTimePickerDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.dateTimePickerDate.Location = new System.Drawing.Point(252, 317);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(188, 20);
            this.dateTimePickerDate.TabIndex = 33;
            // 
            // buttonDate
            // 
            this.buttonDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(91)))));
            this.buttonDate.FlatAppearance.BorderSize = 0;
            this.buttonDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDate.ForeColor = System.Drawing.Color.White;
            this.buttonDate.Location = new System.Drawing.Point(252, 353);
            this.buttonDate.Name = "buttonDate";
            this.buttonDate.Size = new System.Drawing.Size(188, 38);
            this.buttonDate.TabIndex = 34;
            this.buttonDate.Text = "изменить";
            this.buttonDate.UseVisualStyleBackColor = false;
            this.buttonDate.Click += new System.EventHandler(this.buttonDate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 30);
            this.label2.TabIndex = 35;
            this.label2.Text = "изменить техника";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(263, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 30);
            this.label1.TabIndex = 36;
            this.label1.Text = "изменить дату";
            // 
            // textBoxCount
            // 
            this.textBoxCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.textBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCount.Font = new System.Drawing.Font("Sitka Subheading", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCount.Location = new System.Drawing.Point(349, 24);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(100, 21);
            this.textBoxCount.TabIndex = 37;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(91)))));
            this.buttonBack.BackgroundImage = global::computerTech.Properties.Resources.icons8_назад_24;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(23, 22);
            this.buttonBack.TabIndex = 27;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // ManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(461, 599);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDate);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.buttonMaster);
            this.Controls.Add(this.comboBoxMaster);
            this.Controls.Add(this.dataGridViewRequests);
            this.Controls.Add(this.buttonBack);
            this.Name = "ManagerMain";
            this.Text = "Главное меню. Менеджер";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.ComboBox comboBoxMaster;
        private System.Windows.Forms.Button buttonMaster;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Button buttonDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCount;
    }
}