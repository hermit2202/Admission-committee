namespace AdmissionCommittee.Desktop
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
            label1.Location = new Point(8, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "ФИО";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(8, 28);
            txtFullName.Margin = new Padding(2, 2, 2, 2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(282, 23);
            txtFullName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 59);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 2;
            label2.Text = "Пол";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(8, 328);
            btnSave.Margin = new Padding(2, 2, 2, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(239, 20);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(288, 328);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(239, 20);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbGender
            // 
            cmbGender.AutoCompleteCustomSource.AddRange(new string[] { "М", "Ж" });
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Мужской", "Женский" });
            cmbGender.Location = new Point(8, 84);
            cmbGender.Margin = new Padding(2, 2, 2, 2);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(129, 23);
            cmbGender.TabIndex = 5;
            // 
            // cmbFormOfEducation
            // 
            cmbFormOfEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormOfEducation.FormattingEnabled = true;
            cmbFormOfEducation.Items.AddRange(new object[] { "Очное", "Очно-заочное", "Заочное" });
            cmbFormOfEducation.Location = new Point(8, 196);
            cmbFormOfEducation.Margin = new Padding(2, 2, 2, 2);
            cmbFormOfEducation.Name = "cmbFormOfEducation";
            cmbFormOfEducation.Size = new Size(129, 23);
            cmbFormOfEducation.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 116);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 7;
            label3.Text = "Дата рождения";
            // 
            // dtpDateBirth
            // 
            dtpDateBirth.Location = new Point(8, 141);
            dtpDateBirth.Margin = new Padding(2, 2, 2, 2);
            dtpDateBirth.Name = "dtpDateBirth";
            dtpDateBirth.Size = new Size(211, 23);
            dtpDateBirth.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 172);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
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
            label5.Location = new Point(8, 244);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(150, 15);
            label5.TabIndex = 14;
            label5.Text = "Баллы ЕГЭ по математике";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(184, 244);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(138, 15);
            label6.TabIndex = 15;
            label6.Text = "Баллы ЕГЭ по русскому";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(340, 244);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(161, 15);
            label7.TabIndex = 16;
            label7.Text = "Баллы ЕГЭ по информатике";
            // 
            // nudMathScores
            // 
            nudMathScores.Location = new Point(22, 274);
            nudMathScores.Margin = new Padding(2, 2, 2, 2);
            nudMathScores.Name = "nudMathScores";
            nudMathScores.Size = new Size(126, 23);
            nudMathScores.TabIndex = 17;
            // 
            // nudRusScores
            // 
            nudRusScores.Location = new Point(190, 274);
            nudRusScores.Margin = new Padding(2, 2, 2, 2);
            nudRusScores.Name = "nudRusScores";
            nudRusScores.Size = new Size(126, 23);
            nudRusScores.TabIndex = 18;
            // 
            // nudComputerScienceScores
            // 
            nudComputerScienceScores.Location = new Point(357, 274);
            nudComputerScienceScores.Margin = new Padding(2, 2, 2, 2);
            nudComputerScienceScores.Name = "nudComputerScienceScores";
            nudComputerScienceScores.Size = new Size(126, 23);
            nudComputerScienceScores.TabIndex = 19;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 355);
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
            Margin = new Padding(2, 2, 2, 2);
            Name = "StudentForm";
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
