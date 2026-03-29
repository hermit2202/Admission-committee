namespace AdmissionCommittee
{
    public partial class StudentForm : Form
    {
        private readonly Student? student;
        private readonly ErrorProvider errorProvider;

        public StudentForm()
        {
            InitializeComponent();

            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink,
                ContainerControl = this
            };

            InitializeForm();
        }

        public StudentForm(Student student) : this()
        {
            this.student = student;
            LoadStudentData();
        }

        public Student? ResultStudent { get; private set; }

        private void InitializeForm()
        {
            Text = "Добавление студента";

            btnSave.Click += save_Click;
            btnCancel.Click += cancel_Click;

            txtFullName.TextChanged += (s, e) => errorProvider.SetError(txtFullName, null);
            cmbGender.SelectedIndexChanged += (s, e) => errorProvider.SetError(cmbGender, null);
            dtpDateBirth.ValueChanged += (s, e) => errorProvider.SetError(dtpDateBirth, null);
            cmbFormOfEducation.SelectedIndexChanged += (s, e) => errorProvider.SetError(cmbFormOfEducation, null);
            nudMathScores.ValueChanged += (s, e) => errorProvider.SetError(nudMathScores, null);
            nudRusScores.ValueChanged += (s, e) => errorProvider.SetError(nudRusScores, null);
            nudComputerScienceScores.ValueChanged += (s, e) => errorProvider.SetError(nudComputerScienceScores, null);

            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new[] { "Мужской", "Женский" });

            cmbFormOfEducation.Items.Clear();
            cmbFormOfEducation.Items.AddRange(new[] { "Очное", "Очно-заочное", "Заочное" });
        }

        private void LoadStudentData()
        {
            if (student == null)
            {
                return;
            }

            Text = "Редактирование студента";

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
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider.SetError(txtFullName, "Введите ФИО студента");
                isValid = false;
            }
            else if (txtFullName.Text.Trim().Length < 3)
            {
                errorProvider.SetError(txtFullName, "ФИО должно содержать минимум 3 символа");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtFullName, null);
            }

            if (cmbGender.SelectedItem == null)
            {
                errorProvider.SetError(cmbGender, "Выберите пол студента");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(cmbGender, null);
            }

            if (dtpDateBirth.Value > DateTime.Now)
            {
                errorProvider.SetError(dtpDateBirth, "Дата рождения не может быть в будущем");
                isValid = false;
            }
            else
            {
                int age = DateTime.Now.Year - dtpDateBirth.Value.Year;
                if (dtpDateBirth.Value.Date > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                if (age < 10 || age > 100)
                {
                    errorProvider.SetError(dtpDateBirth, $"Возраст должен быть от 10 до 100 лет (сейчас: {age})");
                    isValid = false;
                }
                else
                {
                    errorProvider.SetError(dtpDateBirth, null);
                }
            }

            if (cmbFormOfEducation.SelectedItem == null)
            {
                errorProvider.SetError(cmbFormOfEducation, "Выберите форму обучения");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(cmbFormOfEducation, null);
            }

            if (nudMathScores.Value < 0 || nudMathScores.Value > 100)
            {
                errorProvider.SetError(nudMathScores, "Балл должен быть от 0 до 100");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(nudMathScores, null);
            }

            if (nudRusScores.Value < 0 || nudRusScores.Value > 100)
            {
                errorProvider.SetError(nudRusScores, "Балл должен быть от 0 до 100");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(nudRusScores, null);
            }

            if (nudComputerScienceScores.Value < 0 || nudComputerScienceScores.Value > 100)
            {
                errorProvider.SetError(nudComputerScienceScores, "Балл должен быть от 0 до 100");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(nudComputerScienceScores, null);
            }

            if (!isValid)
            {
                MessageBox.Show(
                    "Исправьте ошибки валидации!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (student == null)
            {
                ResultStudent = new Student
                {
                    FullName = txtFullName.Text.Trim(),
                    Gender = cmbGender.SelectedItem.ToString() == "Мужской" ? "М" : "Ж",
                    DateBirth = dtpDateBirth.Value,
                    FormOfEducation = cmbFormOfEducation.SelectedItem.ToString() ?? "Очное",
                    MathScores = (int)nudMathScores.Value,
                    RusScores = (int)nudRusScores.Value,
                    ComputerScienceScores = (int)nudComputerScienceScores.Value,
                };
            }
            else
            {
                student.FullName = txtFullName.Text.Trim();
                student.Gender = cmbGender.SelectedItem.ToString() == "Мужской" ? "М" : "Ж";
                student.DateBirth = dtpDateBirth.Value;
                student.FormOfEducation = cmbFormOfEducation.SelectedItem.ToString() ?? "Очное";
                student.MathScores = (int)nudMathScores.Value;
                student.RusScores = (int)nudRusScores.Value;
                student.ComputerScienceScores = (int)nudComputerScienceScores.Value;

                ResultStudent = student;
            }

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