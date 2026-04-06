using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Модель данных абитуриента приёмной комиссии.
    /// </summary>
    /// <remarks>
    /// Класс реализует <see cref="INotifyPropertyChanged"/> для DataBinding в WinForms.
    /// Валидация свойств выполняется через атрибуты <see cref="System.ComponentModel.DataAnnotations"/>.
    /// </remarks>
    public class Student : INotifyPropertyChanged
    {
        [Browsable(false)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        private string fullName = string.Empty;
        private Gender gender = Gender.Male;
        private DateTime dateBirth;
        private string formOfEducation = "Очное";
        private int mathScores;
        private int rusScores;
        private int computerScienceScores;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        [Required(ErrorMessage = "ФИО обязательно для заполнения")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "ФИО должно содержать от 3 до 100 символов")]
        [DisplayName("ФИО")]
        public string FullName
        {
            get => fullName;
            set => SetProperty(ref fullName, value);
        }

        [DisplayName("Пол")]
        public Gender Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        [Required(ErrorMessage = "Дата рождения обязательна")]
        [DisplayName("Дата рождения")]
        public DateTime DateBirth
        {
            get => dateBirth;
            set => SetProperty(ref dateBirth, value);
        }

        [DisplayName("Форма обучения")]
        public string FormOfEducation
        {
            get => formOfEducation;
            set => SetProperty(ref formOfEducation, value);
        }

        [Range(0, 100, ErrorMessage = "Балл должен быть от 0 до 100")]
        [DisplayName("Баллы ЕГЭ по математике")]
        public int MathScores
        {
            get => mathScores;
            set
            {
                if (SetProperty(ref mathScores, value))
                {
                    OnPropertyChanged(nameof(TotalScore));
                }
            }
        }

        [Range(0, 100, ErrorMessage = "Балл должен быть от 0 до 100")]
        [DisplayName("Баллы ЕГЭ по русскому")]
        public int RusScores
        {
            get => rusScores;
            set
            {
                if (SetProperty(ref rusScores, value))
                {
                    OnPropertyChanged(nameof(TotalScore));
                }
            }
        }

        [Range(0, 100, ErrorMessage = "Балл должен быть от 0 до 100")]
        [DisplayName("Баллы ЕГЭ по информатике")]
        public int ComputerScienceScores
        {
            get => computerScienceScores;
            set
            {
                if (SetProperty(ref computerScienceScores, value))
                {
                    OnPropertyChanged(nameof(TotalScore));
                }
            }
        }

        [DisplayName("Сумма баллов")]
        public int TotalScore => MathScores + RusScores + ComputerScienceScores;
    }
}
