using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AdmissionCommittee.Models;

namespace AdmissionCommittee.Desktop
{
    /// <summary>
    /// Форма для добавления и редактирования данных абитуриента.
    /// Предоставляет интерфейс ввода с валидацией и DataBinding к модели <see cref="Student"/>.
    /// </summary>
    public partial class StudentForm : Form
    {
        private Student? student;
        private readonly ErrorProvider errorProvider;
        private BindingSource? bindingSource;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="StudentForm"/> для создания студента.
        /// </summary>
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

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="StudentForm"/> для редактирования существующего студента.
        /// </summary>
        /// <param name="student">
        /// Объект <see cref="Student"/> с данными для редактирования.
        /// </param>
        public StudentForm(Student student) : this()
        {
            this.student = student;
            LoadStudentData();
        }

        /// <summary>
        /// Возвращает результат работы формы — объект студента с заполненными данными,
        /// или <c>null</c>, если форма была закрыта с отменой.
        /// </summary>
        /// <value>
        /// Объект <see cref="Student"/> или <c>null</c>.
        /// </value>
        public Student? ResultStudent => student;

        private void InitializeForm()
        {
            Text = "Добавление студента";

            btnSave.Click += save_Click;
            btnCancel.Click += cancel_Click;

            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(Gender.GetAll().ToArray());

            cmbFormOfEducation.Items.Clear();
            cmbFormOfEducation.Items.AddRange(new[] { "Очное", "Очно-заочное", "Заочное" });

            txtFullName.Validating += Control_Validating;
            dtpDateBirth.Validating += Control_Validating;
            nudMathScores.Validating += Control_Validating;
            nudRusScores.Validating += Control_Validating;
            nudComputerScienceScores.Validating += Control_Validating;
        }

        private void CreateNewStudent()
        {
            student = new Student
            {
                DateBirth = DateTime.Now.AddYears(-ValidationConstants.DefaultStudentAge)
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

        private void Control_Validating(object? sender, CancelEventArgs e)
        {
            if (sender is not Control control || student == null)
            {
                return;
            }

            var propertyName = control.DataBindings[0]?.BindingMemberInfo.BindingField;
            if (string.IsNullOrEmpty(propertyName))
            {
                return;
            }

            var value = control switch
            {
                TextBox tb => tb.Text,
                DateTimePicker dtp => dtp.Value,
                NumericUpDown nud => (int)nud.Value,
                ComboBox cb => cb.SelectedItem,
                _ => null
            };

            var context = new ValidationContext(student) { MemberName = propertyName };
            var results = new List<ValidationResult>();

            if (propertyName == nameof(Student.DateBirth))
            {
                if (!ValidateAge((DateTime?)value, out var ageError))
                {
                    errorProvider.SetError(control, ageError);
                    e.Cancel = true;
                    return;
                }
            }

            if (!Validator.TryValidateProperty(value, context, results))
            {
                errorProvider.SetError(control, results[0].ErrorMessage);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(control, null);
            }
        }

        private bool ValidateAge(DateTime? dateBirth, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (dateBirth == null)
            {
                return false;
            }

            if (dateBirth.Value > DateTime.Now)
            {
                errorMessage = "Дата рождения не может быть в будущем";
                return false;
            }

            var age = DateTime.Now.Year - dateBirth.Value.Year;
            if (dateBirth.Value.Date > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            if (age < ValidationConstants.MinAge || age > ValidationConstants.MaxAge)
            {
                errorMessage = $"Возраст должен быть от {ValidationConstants.MinAge} до {ValidationConstants.MaxAge} лет (сейчас: {age})";
                return false;
            }

            return true;
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
