using System.ComponentModel;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.Desktop
{
    public partial class StudentForm : Form
    {
        private Student? student;
        private readonly ErrorProvider errorProvider;
        private BindingSource? bindingSource;

        public StudentForm()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink,
                ContainerControl = this
            };
            InitializeForm();
            CreateNewStudent();
        }

        public StudentForm(Student student) : this()
        {
            this.student = student;
            LoadStudentData();
        }

        public Student? ResultStudent => student;

        private void InitializeForm()
        {
            Text = "Добавление студента";

            btnSave.Click += save_Click;
            btnCancel.Click += cancel_Click;

            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new[] { "Мужской", "Женский" });

            cmbFormOfEducation.Items.Clear();
            cmbFormOfEducation.Items.AddRange(new[] { "Очное", "Очно-заочное", "Заочное" });

            txtFullName.Validating += txtFullName_Validating;
            dtpDateBirth.Validating += dtpDateBirth_Validating;
            nudMathScores.Validating += nudScores_Validating;
            nudRusScores.Validating += nudScores_Validating;
            nudComputerScienceScores.Validating += nudScores_Validating;
        }

        private void CreateNewStudent()
        {
            student = new Student
            {
                DateBirth = DateTime.Now.AddYears(-18)
            };
            SetupDataBindings();
        }

        private void LoadStudentData()
        {
            if (student == null)
            {
                return;
            }

            Text = "Редактирование студента";
            SetupDataBindings();
        }

        private void SetupDataBindings()
        {
            if (student == null)
            {
                return;
            }

            bindingSource = new BindingSource { DataSource = student };

            txtFullName.DataBindings.Clear();
            txtFullName.DataBindings.Add("Text", bindingSource, "FullName", false,
                DataSourceUpdateMode.OnPropertyChanged);

            cmbGender.DataBindings.Clear();
            cmbGender.DataBindings.Add("SelectedItem", bindingSource, "Gender", false,
                DataSourceUpdateMode.OnPropertyChanged);

            dtpDateBirth.DataBindings.Clear();
            dtpDateBirth.DataBindings.Add("Value", bindingSource, "DateBirth", false,
                DataSourceUpdateMode.OnPropertyChanged);

            cmbFormOfEducation.DataBindings.Clear();
            cmbFormOfEducation.DataBindings.Add("SelectedItem", bindingSource, "FormOfEducation", false,
                DataSourceUpdateMode.OnPropertyChanged);

            nudMathScores.DataBindings.Clear();
            nudMathScores.DataBindings.Add("Value", bindingSource, "MathScores", false,
                DataSourceUpdateMode.OnPropertyChanged);

            nudRusScores.DataBindings.Clear();
            nudRusScores.DataBindings.Add("Value", bindingSource, "RusScores", false,
                DataSourceUpdateMode.OnPropertyChanged);

            nudComputerScienceScores.DataBindings.Clear();
            nudComputerScienceScores.DataBindings.Add("Value", bindingSource, "ComputerScienceScores", false,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void txtFullName_Validating(object? sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider.SetError(txtFullName, "Введите ФИО студента");
                e.Cancel = true;
            }
            else if (txtFullName.Text.Trim().Length < 3)
            {
                errorProvider.SetError(txtFullName, "ФИО должно содержать минимум 3 символа");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFullName, null);
            }
        }

        private void dtpDateBirth_Validating(object? sender, CancelEventArgs e)
        {
            if (dtpDateBirth.Value > DateTime.Now)
            {
                errorProvider.SetError(dtpDateBirth, "Дата рождения не может быть в будущем");
                e.Cancel = true;
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
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(dtpDateBirth, null);
                }
            }
        }

        private void nudScores_Validating(object? sender, CancelEventArgs e)
        {
            if (sender is NumericUpDown nud)
            {
                if (nud.Value < 0 || nud.Value > 100)
                {
                    errorProvider.SetError(nud, "Балл должен быть от 0 до 100");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(nud, null);
                }
            }
        }

        private void save_Click(object? sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
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
                MessageBox.Show("Ошибка создания студента!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
