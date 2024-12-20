namespace computerTech
{
    partial class Autorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPasswd = new System.Windows.Forms.TextBox();
            this.buttonRegist = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCapcha = new System.Windows.Forms.TextBox();
            this.labelcapcha = new System.Windows.Forms.Label();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxCapcha = new System.Windows.Forms.PictureBox();
            this.buttonCapcha = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapcha)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(147, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.textBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin.ForeColor = System.Drawing.Color.White;
            this.textBoxLogin.Location = new System.Drawing.Point(80, 122);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(302, 20);
            this.textBoxLogin.TabIndex = 1;
            // 
            // textBoxPasswd
            // 
            this.textBoxPasswd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.textBoxPasswd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPasswd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPasswd.ForeColor = System.Drawing.Color.White;
            this.textBoxPasswd.Location = new System.Drawing.Point(80, 187);
            this.textBoxPasswd.Name = "textBoxPasswd";
            this.textBoxPasswd.Size = new System.Drawing.Size(302, 20);
            this.textBoxPasswd.TabIndex = 2;
            // 
            // buttonRegist
            // 
            this.buttonRegist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(91)))));
            this.buttonRegist.FlatAppearance.BorderSize = 0;
            this.buttonRegist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegist.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegist.ForeColor = System.Drawing.Color.White;
            this.buttonRegist.Location = new System.Drawing.Point(80, 495);
            this.buttonRegist.Name = "buttonRegist";
            this.buttonRegist.Size = new System.Drawing.Size(302, 34);
            this.buttonRegist.TabIndex = 3;
            this.buttonRegist.Text = "войти";
            this.buttonRegist.UseVisualStyleBackColor = false;
            this.buttonRegist.Click += new System.EventHandler(this.buttonRegist_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(73, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(73, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "пароль";
            // 
            // textBoxCapcha
            // 
            this.textBoxCapcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(197)))), ((int)(((byte)(190)))));
            this.textBoxCapcha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCapcha.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCapcha.ForeColor = System.Drawing.Color.White;
            this.textBoxCapcha.Location = new System.Drawing.Point(80, 430);
            this.textBoxCapcha.Name = "textBoxCapcha";
            this.textBoxCapcha.Size = new System.Drawing.Size(80, 15);
            this.textBoxCapcha.TabIndex = 7;
            this.textBoxCapcha.Visible = false;
            // 
            // labelcapcha
            // 
            this.labelcapcha.AutoSize = true;
            this.labelcapcha.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelcapcha.ForeColor = System.Drawing.Color.White;
            this.labelcapcha.Location = new System.Drawing.Point(76, 406);
            this.labelcapcha.Name = "labelcapcha";
            this.labelcapcha.Size = new System.Drawing.Size(111, 20);
            this.labelcapcha.TabIndex = 8;
            this.labelcapcha.Text = "Введите капчу:";
            this.labelcapcha.Visible = false;
            // 
            // buttonHistory
            // 
            this.buttonHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(91)))));
            this.buttonHistory.FlatAppearance.BorderSize = 0;
            this.buttonHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHistory.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHistory.ForeColor = System.Drawing.Color.White;
            this.buttonHistory.Location = new System.Drawing.Point(78, 535);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(302, 34);
            this.buttonHistory.TabIndex = 11;
            this.buttonHistory.Text = "история входов";
            this.buttonHistory.UseVisualStyleBackColor = false;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBoxCapcha
            // 
            this.pictureBoxCapcha.Location = new System.Drawing.Point(197, 396);
            this.pictureBoxCapcha.Name = "pictureBoxCapcha";
            this.pictureBoxCapcha.Size = new System.Drawing.Size(183, 86);
            this.pictureBoxCapcha.TabIndex = 10;
            this.pictureBoxCapcha.TabStop = false;
            this.pictureBoxCapcha.Visible = false;
            // 
            // buttonCapcha
            // 
            this.buttonCapcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(91)))));
            this.buttonCapcha.BackgroundImage = global::computerTech.Properties.Resources.icons8_перезагрузка_24;
            this.buttonCapcha.FlatAppearance.BorderSize = 0;
            this.buttonCapcha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCapcha.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCapcha.Location = new System.Drawing.Point(80, 456);
            this.buttonCapcha.Name = "buttonCapcha";
            this.buttonCapcha.Size = new System.Drawing.Size(26, 26);
            this.buttonCapcha.TabIndex = 9;
            this.buttonCapcha.UseVisualStyleBackColor = false;
            this.buttonCapcha.Visible = false;
            this.buttonCapcha.Click += new System.EventHandler(this.buttonCapcha_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(91)))));
            this.buttonShow.BackgroundImage = global::computerTech.Properties.Resources.icons8_показать_50;
            this.buttonShow.FlatAppearance.BorderSize = 0;
            this.buttonShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow.Location = new System.Drawing.Point(388, 175);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(49, 51);
            this.buttonShow.TabIndex = 4;
            this.buttonShow.UseVisualStyleBackColor = false;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // Autorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(461, 599);
            this.Controls.Add(this.buttonHistory);
            this.Controls.Add(this.pictureBoxCapcha);
            this.Controls.Add(this.buttonCapcha);
            this.Controls.Add(this.labelcapcha);
            this.Controls.Add(this.textBoxCapcha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonRegist);
            this.Controls.Add(this.textBoxPasswd);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.label1);
            this.Name = "Autorization";
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxLogin;
        public System.Windows.Forms.TextBox textBoxPasswd;
        private System.Windows.Forms.Button buttonRegist;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxCapcha;
        private System.Windows.Forms.Label labelcapcha;
        private System.Windows.Forms.Button buttonCapcha;
        private System.Windows.Forms.PictureBox pictureBoxCapcha;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.Timer blockTimer;
    }
}

