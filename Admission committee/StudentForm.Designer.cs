namespace AdmissionCommittee
{
    partial class StudentForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtFullName = new TextBox();
            label2 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            cmbGender = new ComboBox();
            cmbFormOfEducation = new ComboBox();
            label3 = new Label();
            dtpDateBirth = new DateTimePicker();
            label4 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            nudMathScores = new NumericUpDown();
            nudRusScores = new NumericUpDown();
            nudComputerScienceScores = new NumericUpDown();
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
            // txtFullName
            // 
            txtFullName.Location = new Point(12, 46);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(401, 31);
            txtFullName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 99);
            label2.Name = "label2";
            label2.Size = new Size(45, 25);
            label2.TabIndex = 2;
            label2.Text = "Пол";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 547);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(342, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(412, 547);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(342, 34);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbGender
            // 
            cmbGender.AutoCompleteCustomSource.AddRange(new string[] { "М", "Ж" });
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Мужчина", "Женщина" });
            cmbGender.Location = new Point(12, 140);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(182, 33);
            cmbGender.TabIndex = 5;
            // 
            // cmbFormOfEducation
            // 
            cmbFormOfEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormOfEducation.FormattingEnabled = true;
            cmbFormOfEducation.Items.AddRange(new object[] { "Очное", "Очно-заочное", "Заочное" });
            cmbFormOfEducation.Location = new Point(12, 327);
            cmbFormOfEducation.Name = "cmbFormOfEducation";
            cmbFormOfEducation.Size = new Size(182, 33);
            cmbFormOfEducation.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 193);
            label3.Name = "label3";
            label3.Size = new Size(137, 25);
            label3.TabIndex = 7;
            label3.Text = "Дата рождения";
            // 
            // dtpDateBirth
            // 
            dtpDateBirth.Location = new Point(12, 235);
            dtpDateBirth.Name = "dtpDateBirth";
            dtpDateBirth.Size = new Size(300, 31);
            dtpDateBirth.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 286);
            label4.Name = "label4";
            label4.Size = new Size(152, 25);
            label4.TabIndex = 9;
            label4.Text = "Форма обучения";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 406);
            label5.Name = "label5";
            label5.Size = new Size(221, 25);
            label5.TabIndex = 14;
            label5.Text = "Баллы ЕГЭ по математике";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(263, 406);
            label6.Name = "label6";
            label6.Size = new Size(204, 25);
            label6.TabIndex = 15;
            label6.Text = "Баллы ЕГЭ по русскому";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(486, 406);
            label7.Name = "label7";
            label7.Size = new Size(237, 25);
            label7.TabIndex = 16;
            label7.Text = "Баллы ЕГЭ по информатике";
            // 
            // nudMathScores
            // 
            nudMathScores.Location = new Point(31, 457);
            nudMathScores.Name = "nudMathScores";
            nudMathScores.Size = new Size(180, 31);
            nudMathScores.TabIndex = 17;
            // 
            // nudRusScores
            // 
            nudRusScores.Location = new Point(272, 457);
            nudRusScores.Name = "nudRusScores";
            nudRusScores.Size = new Size(180, 31);
            nudRusScores.TabIndex = 18;
            // 
            // nudComputerScienceScores
            // 
            nudComputerScienceScores.Location = new Point(510, 457);
            nudComputerScienceScores.Name = "nudComputerScienceScores";
            nudComputerScienceScores.Size = new Size(180, 31);
            nudComputerScienceScores.TabIndex = 19;
            // 
            // StudentAddForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 591);
            Controls.Add(nudComputerScienceScores);
            Controls.Add(nudRusScores);
            Controls.Add(nudMathScores);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpDateBirth);
            Controls.Add(label3);
            Controls.Add(cmbFormOfEducation);
            Controls.Add(cmbGender);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(txtFullName);
            Controls.Add(label1);
            Name = "StudentAddForm";
            Text = "Добавление студента";
            ((System.ComponentModel.ISupportInitialize)nudMathScores).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRusScores).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudComputerScienceScores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFullName;
        private Label label2;
        private Button btnSave;
        private Button btnCancel;
        private ComboBox cmbGender;
        private ComboBox cmbFormOfEducation;
        private Label label3;
        private DateTimePicker dtpDateBirth;
        private Label label4;
        private ContextMenuStrip contextMenuStrip1;
        private Label label5;
        private Label label6;
        private Label label7;
        private NumericUpDown nudMathScores;
        private NumericUpDown nudRusScores;
        private NumericUpDown nudComputerScienceScores;
    }
}
