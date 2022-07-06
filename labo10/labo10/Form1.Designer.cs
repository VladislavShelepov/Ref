
namespace labo10
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.enTextBox2 = new System.Windows.Forms.TextBox();
            this.buttonUploadDe = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.buttonSaveEn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deTextBox1 = new System.Windows.Forms.TextBox();
            this.deTextBox2 = new System.Windows.Forms.TextBox();
            this.buttonUpload2 = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.buttonSaveDe = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.generateKeyButton = new System.Windows.Forms.Button();
            this.setKeyButton = new System.Windows.Forms.Button();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.textBoxQ = new System.Windows.Forms.TextBox();
            this.textBoxE = new System.Windows.Forms.TextBox();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.enTextBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveKeys = new System.Windows.Forms.Button();
            this.setKeyButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Открытый текст:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Зашифрованный текст:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 669);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "d:";
            // 
            // enTextBox2
            // 
            this.enTextBox2.Location = new System.Drawing.Point(35, 358);
            this.enTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enTextBox2.MaxLength = 2139999999;
            this.enTextBox2.Multiline = true;
            this.enTextBox2.Name = "enTextBox2";
            this.enTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.enTextBox2.Size = new System.Drawing.Size(388, 239);
            this.enTextBox2.TabIndex = 3;
            // 
            // buttonUploadDe
            // 
            this.buttonUploadDe.Location = new System.Drawing.Point(445, 64);
            this.buttonUploadDe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUploadDe.Name = "buttonUploadDe";
            this.buttonUploadDe.Size = new System.Drawing.Size(171, 31);
            this.buttonUploadDe.TabIndex = 6;
            this.buttonUploadDe.Text = "Загрузить из файла";
            this.buttonUploadDe.UseVisualStyleBackColor = true;
            this.buttonUploadDe.Click += new System.EventHandler(this.buttonUploadDe_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(445, 111);
            this.encryptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(171, 31);
            this.encryptButton.TabIndex = 8;
            this.encryptButton.Text = "Зашифровать";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // buttonSaveEn
            // 
            this.buttonSaveEn.Location = new System.Drawing.Point(444, 358);
            this.buttonSaveEn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveEn.Name = "buttonSaveEn";
            this.buttonSaveEn.Size = new System.Drawing.Size(171, 27);
            this.buttonSaveEn.TabIndex = 9;
            this.buttonSaveEn.Text = "Сохранить в файл";
            this.buttonSaveEn.UseVisualStyleBackColor = true;
            this.buttonSaveEn.Click += new System.EventHandler(this.buttonSaveEn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Зашифрованный текст:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(680, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Расшифрованный текст:";
            // 
            // deTextBox1
            // 
            this.deTextBox1.Location = new System.Drawing.Point(681, 64);
            this.deTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deTextBox1.MaxLength = 2139999999;
            this.deTextBox1.Multiline = true;
            this.deTextBox1.Name = "deTextBox1";
            this.deTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.deTextBox1.Size = new System.Drawing.Size(388, 244);
            this.deTextBox1.TabIndex = 12;
            // 
            // deTextBox2
            // 
            this.deTextBox2.Location = new System.Drawing.Point(684, 358);
            this.deTextBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deTextBox2.MaxLength = 2139999999;
            this.deTextBox2.Multiline = true;
            this.deTextBox2.Name = "deTextBox2";
            this.deTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.deTextBox2.Size = new System.Drawing.Size(388, 239);
            this.deTextBox2.TabIndex = 13;
            // 
            // buttonUpload2
            // 
            this.buttonUpload2.Location = new System.Drawing.Point(1094, 64);
            this.buttonUpload2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpload2.Name = "buttonUpload2";
            this.buttonUpload2.Size = new System.Drawing.Size(171, 31);
            this.buttonUpload2.TabIndex = 14;
            this.buttonUpload2.Text = "Загрузить из файла";
            this.buttonUpload2.UseVisualStyleBackColor = true;
            this.buttonUpload2.Click += new System.EventHandler(this.buttonUpload2_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(1094, 111);
            this.decryptButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(171, 31);
            this.decryptButton.TabIndex = 15;
            this.decryptButton.Text = "Расшифровать";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // buttonSaveDe
            // 
            this.buttonSaveDe.Location = new System.Drawing.Point(1093, 358);
            this.buttonSaveDe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveDe.Name = "buttonSaveDe";
            this.buttonSaveDe.Size = new System.Drawing.Size(171, 27);
            this.buttonSaveDe.TabIndex = 16;
            this.buttonSaveDe.Text = "Сохранить в файл";
            this.buttonSaveDe.UseVisualStyleBackColor = true;
            this.buttonSaveDe.Click += new System.EventHandler(this.buttonSaveDe_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 625);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "p:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 625);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "q:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(842, 625);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "e:";
            // 
            // generateKeyButton
            // 
            this.generateKeyButton.Location = new System.Drawing.Point(863, 659);
            this.generateKeyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateKeyButton.Name = "generateKeyButton";
            this.generateKeyButton.Size = new System.Drawing.Size(171, 27);
            this.generateKeyButton.TabIndex = 23;
            this.generateKeyButton.Text = "Сгенерировать";
            this.generateKeyButton.UseVisualStyleBackColor = true;
            this.generateKeyButton.Click += new System.EventHandler(this.generateKeyButton_Click);
            // 
            // setKeyButton
            // 
            this.setKeyButton.Location = new System.Drawing.Point(1059, 659);
            this.setKeyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.setKeyButton.Name = "setKeyButton";
            this.setKeyButton.Size = new System.Drawing.Size(171, 27);
            this.setKeyButton.TabIndex = 24;
            this.setKeyButton.Text = "Задать вручную";
            this.setKeyButton.UseVisualStyleBackColor = true;
            this.setKeyButton.Click += new System.EventHandler(this.setKeyButton_Click);
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(56, 625);
            this.textBoxP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.Size = new System.Drawing.Size(367, 22);
            this.textBoxP.TabIndex = 25;
            this.textBoxP.TextChanged += new System.EventHandler(this.textBoxP_TextChanged);
            // 
            // textBoxQ
            // 
            this.textBoxQ.Location = new System.Drawing.Point(462, 625);
            this.textBoxQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxQ.Name = "textBoxQ";
            this.textBoxQ.Size = new System.Drawing.Size(367, 22);
            this.textBoxQ.TabIndex = 26;
            this.textBoxQ.TextChanged += new System.EventHandler(this.textBoxQ_TextChanged);
            // 
            // textBoxE
            // 
            this.textBoxE.Location = new System.Drawing.Point(863, 625);
            this.textBoxE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.Size = new System.Drawing.Size(367, 22);
            this.textBoxE.TabIndex = 27;
            this.textBoxE.TextChanged += new System.EventHandler(this.textBoxE_TextChanged);
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(462, 666);
            this.textBoxN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(367, 22);
            this.textBoxN.TabIndex = 28;
            this.textBoxN.TextChanged += new System.EventHandler(this.textBoxN_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 666);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "n:";
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(56, 666);
            this.textBoxD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(367, 22);
            this.textBoxD.TabIndex = 30;
            // 
            // enTextBox1
            // 
            this.enTextBox1.Location = new System.Drawing.Point(37, 64);
            this.enTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enTextBox1.MaxLength = 2139999999;
            this.enTextBox1.Multiline = true;
            this.enTextBox1.Name = "enTextBox1";
            this.enTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.enTextBox1.Size = new System.Drawing.Size(388, 244);
            this.enTextBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 700);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(308, 27);
            this.button1.TabIndex = 37;
            this.button1.Text = "Загрузить d и n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveKeys
            // 
            this.saveKeys.Location = new System.Drawing.Point(84, 700);
            this.saveKeys.Name = "saveKeys";
            this.saveKeys.Size = new System.Drawing.Size(308, 27);
            this.saveKeys.TabIndex = 36;
            this.saveKeys.Text = "Сохранить d и n";
            this.saveKeys.UseVisualStyleBackColor = true;
            this.saveKeys.Click += new System.EventHandler(this.saveKeys_Click);
            // 
            // setKeyButton2
            // 
            this.setKeyButton2.Location = new System.Drawing.Point(901, 700);
            this.setKeyButton2.Name = "setKeyButton2";
            this.setKeyButton2.Size = new System.Drawing.Size(308, 27);
            this.setKeyButton2.TabIndex = 35;
            this.setKeyButton2.Text = "Задать вручную для расшифрования";
            this.setKeyButton2.UseVisualStyleBackColor = true;
            this.setKeyButton2.Click += new System.EventHandler(this.setKeyButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 787);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveKeys);
            this.Controls.Add(this.setKeyButton2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.textBoxE);
            this.Controls.Add(this.textBoxQ);
            this.Controls.Add(this.textBoxP);
            this.Controls.Add(this.setKeyButton);
            this.Controls.Add(this.generateKeyButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSaveDe);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.buttonUpload2);
            this.Controls.Add(this.deTextBox2);
            this.Controls.Add(this.deTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSaveEn);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.buttonUploadDe);
            this.Controls.Add(this.enTextBox2);
            this.Controls.Add(this.enTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Шифр RSA";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox enTextBox2;
        private System.Windows.Forms.Button buttonUploadDe;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button buttonSaveEn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox deTextBox1;
        private System.Windows.Forms.TextBox deTextBox2;
        private System.Windows.Forms.Button buttonUpload2;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button buttonSaveDe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button generateKeyButton;
        private System.Windows.Forms.Button setKeyButton;
        private System.Windows.Forms.TextBox textBoxP;
        private System.Windows.Forms.TextBox textBoxQ;
        private System.Windows.Forms.TextBox textBoxE;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.TextBox enTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveKeys;
        private System.Windows.Forms.Button setKeyButton2;
    }
}

