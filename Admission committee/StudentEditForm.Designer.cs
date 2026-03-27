namespace AdmissionCommittee
{
    partial class StudentEditForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtFullName = new TextBox();
            nudMathScores = new NumericUpDown();
            nudRusScores = new NumericUpDown();
            nudComputerScienceScores = new NumericUpDown();
            cmbGender = new ComboBox();
            dtpDateBirth = new DateTimePicker();
            cmbFormOfEducation = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudMathScores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRusScores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudComputerScienceScores).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 25);
            label1.TabIndex = 0;
            label1.Text = "ФИО";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 114);
            label2.Name = "label2";
            label2.Size = new Size(45, 25);
            label2.TabIndex = 1;
            label2.Text = "Пол";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 220);
            label3.Name = "label3";
            label3.Size = new Size(137, 25);
            label3.TabIndex = 2;
            label3.Text = "Дата рождения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 340);
            label4.Name = "label4";
            label4.Size = new Size(152, 25);
            label4.TabIndex = 3;
            label4.Text = "Форма обучения";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 474);
            label5.Name = "label5";
            label5.Size = new Size(221, 25);
            label5.TabIndex = 4;
            label5.Text = "Баллы ЕГЭ по математике";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(278, 474);
            label6.Name = "label6";
            label6.Size = new Size(204, 25);
            label6.TabIndex = 5;
            label6.Text = "Баллы ЕГЭ по русскому";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(524, 474);
            label7.Name = "label7";
            label7.Size = new Size(237, 25);
            label7.TabIndex = 6;
            label7.Text = "Баллы ЕГЭ по информатике";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(14, 58);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(353, 31);
            txtFullName.TabIndex = 7;
            // 
            // nudMathScores
            // 
            nudMathScores.Location = new Point(28, 522);
            nudMathScores.Name = "nudMathScores";
            nudMathScores.Size = new Size(180, 31);
            nudMathScores.TabIndex = 8;
            // 
            // nudRusScores
            // 
            nudRusScores.Location = new Point(278, 522);
            nudRusScores.Name = "nudRusScores";
            nudRusScores.Size = new Size(180, 31);
            nudRusScores.TabIndex = 9;
            // 
            // nudComputerScienceScores
            // 
            nudComputerScienceScores.Location = new Point(550, 522);
            nudComputerScienceScores.Name = "nudComputerScienceScores";
            nudComputerScienceScores.Size = new Size(180, 31);
            nudComputerScienceScores.TabIndex = 10;
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Мужчина", "Женщина" });
            cmbGender.Location = new Point(12, 159);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(182, 33);
            cmbGender.TabIndex = 11;
            // 
            // dtpDateBirth
            // 
            dtpDateBirth.Location = new Point(12, 279);
            dtpDateBirth.Name = "dtpDateBirth";
            dtpDateBirth.Size = new Size(300, 31);
            dtpDateBirth.TabIndex = 12;
            // 
            // cmbFormOfEducation
            // 
            cmbFormOfEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormOfEducation.FormattingEnabled = true;
            cmbFormOfEducation.Items.AddRange(new object[] { "Очное", "Очно-заочное", "Заочное" });
            cmbFormOfEducation.Location = new Point(12, 394);
            cmbFormOfEducation.Name = "cmbFormOfEducation";
            cmbFormOfEducation.Size = new Size(182, 33);
            cmbFormOfEducation.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(14, 583);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(362, 34);
            btnSave.TabIndex = 14;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(425, 583);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(363, 34);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // StudentEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 639);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbFormOfEducation);
            Controls.Add(dtpDateBirth);
            Controls.Add(cmbGender);
            Controls.Add(nudComputerScienceScores);
            Controls.Add(nudRusScores);
            Controls.Add(nudMathScores);
            Controls.Add(txtFullName);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "StudentEditForm";
            Text = "Редактирование студента";
            ((System.ComponentModel.ISupportInitialize)nudMathScores).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRusScores).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudComputerScienceScores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtFullName;
        private NumericUpDown nudMathScores;
        private NumericUpDown nudRusScores;
        private NumericUpDown nudComputerScienceScores;
        private ComboBox cmbGender;
        private DateTimePicker dtpDateBirth;
        private ComboBox cmbFormOfEducation;
        private Button btnSave;
        private Button btnCancel;
    }
}
