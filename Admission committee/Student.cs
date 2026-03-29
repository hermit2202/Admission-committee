using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdmissionCommittee
{
    public class Student
    {
        private string fullName = string.Empty;
        private string gender = "М";
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

        [DisplayName("ФИО")]
        public string FullName
        {
            get => fullName;
            set => SetProperty(ref fullName, value);
        }

        [DisplayName("Пол")]
        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

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

        [DisplayName("Баллы ЕГЭ по математике")]
        public int MathScores
        {
            get => mathScores;
            set => SetProperty(ref mathScores, value);
        }

        [DisplayName("Баллы ЕГЭ по русскому")]
        public int RusScores
        {
            get => rusScores;
            set => SetProperty(ref rusScores, value);
        }

        [DisplayName("Баллы ЕГЭ по информатике")]
        public int ComputerScienceScores
        {
            get => computerScienceScores;
            set => SetProperty(ref computerScienceScores, value);
        }

        [DisplayName("Сумма баллов")]
        public int TotalScore => MathScores + RusScores + ComputerScienceScores;
    }
}
