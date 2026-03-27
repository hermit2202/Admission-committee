namespace AdmissionCommittee
{
    public partial class StudentEditForm : Form
    {
        private readonly Student student;

        public StudentEditForm(Student student)
        {
            InitializeComponent();
            this.student = student;

            btnSave.Click += save_Click;
            btnCancel.Click += cancel_Click;

            PopulateComboBoxes();
            LoadStudentData();
        }

        private void PopulateComboBoxes()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new[] { "Мужской", "Женский" });

            cmbFormOfEducation.Items.Clear();
            cmbFormOfEducation.Items.AddRange(new[] { "Очное", "Очно-заочное", "Заочное" });
        }

        private void LoadStudentData()
        {
            txtFullName.Text = student.FullName;
            cmbGender.SelectedItem = student.Gender == "М" ? "Мужской" : "Женский";
            dtpDateBirth.Value = student.DateBirth;
            cmbFormOfEducation.SelectedItem = student.FormOfEducation;
            nudMathScores.Value = student.MathScores;
            nudRusScores.Value = student.RusScores;
            nudComputerScienceScores.Value = student.ComputerScienceScores;
        }

        private void save_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО студента!", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            string fullName = txtFullName.Text.Trim();
            if (fullName.Length < 3)
            {
                MessageBox.Show("ФИО должно содержать минимум 3 символа!", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Выберите пол студента!", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
                return;
            }

            if (dtpDateBirth.Value > DateTime.Now)
            {
                MessageBox.Show("Дата рождения не может быть в будущем!", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDateBirth.Focus();
                return;
            }

            int age = DateTime.Now.Year - dtpDateBirth.Value.Year;
            if (dtpDateBirth.Value.Date > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            if (age < 10 || age > 100)
            {
                MessageBox.Show($"Возраст студента должен быть от 10 до 100 лет!\nСейчас: {age} лет", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDateBirth.Focus();
                return;
            }

            if (cmbFormOfEducation.SelectedItem == null)
            {
                MessageBox.Show("Выберите форму обучения!", "Ошибка валидации", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmbFormOfEducation.Focus();
                return;
            }

            if (nudMathScores.Value < 0 || nudMathScores.Value > 100)
            {
                MessageBox.Show("Балл по математике должен быть от 0 до 100!", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMathScores.Focus();
                return;
            }

            if (nudRusScores.Value < 0 || nudRusScores.Value > 100)
            {
                MessageBox.Show("Балл по русскому языку должен быть от 0 до 100!", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudRusScores.Focus();
                return;
            }

            if (nudComputerScienceScores.Value < 0 || nudComputerScienceScores.Value > 100)
            {
                MessageBox.Show("Балл по информатике должен быть от 0 до 100!", "Ошибка валидации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudComputerScienceScores.Focus();
                return;
            }

            student.FullName = fullName;
            student.Gender = cmbGender.SelectedItem.ToString() == "Мужской" ? "М" : "Ж";
            student.DateBirth = dtpDateBirth.Value;
            student.FormOfEducation = cmbFormOfEducation.SelectedItem.ToString();
            student.MathScores = (int)nudMathScores.Value;
            student.RusScores = (int)nudRusScores.Value;
            student.ComputerScienceScores = (int)nudComputerScienceScores.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
