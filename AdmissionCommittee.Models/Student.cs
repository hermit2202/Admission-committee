using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdmissionCommittee.Models
{

    /// <summary>
    /// Модель данных абитуриента приёмной комиссии.
    /// Содержит персональную информацию, данные об образовании
    /// и результаты ЕГЭ по трём предметам.
    /// </summary>
    /// <remarks>
    /// Класс реализует <see cref="INotifyPropertyChanged"/> для поддержки
    /// двухсторонней привязки данных (DataBinding) в WinForms.
    /// При изменении баллов по предметам автоматически пересчитывается
    /// свойство <see cref="TotalScore"/>.
    /// </remarks>
    public class Student : INotifyPropertyChanged
    {

        /// <summary>
        /// Уникальный идентификатор абитуриента.
        /// </summary>
        /// <value>
        /// Строковое представление GUID, сгенерированное при создании объекта.
        /// Не отображается в привязанных элементах управления
        /// (атрибут <see cref="BrowsableAttribute"/> = <c>false</c>).
        /// </value>
        [Browsable(false)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        private string fullName = string.Empty;
        private Gender gender = Gender.Male;
        private DateTime dateBirth;
        private string formOfEducation = "Очное";
        private int mathScores;
        private int rusScores;
        private int computerScienceScores;

        /// <summary>
        /// Событие, уведомляющее об изменении свойств объекта.
        /// </summary>
        /// <remarks>
        /// Используется механизмом DataBinding для автоматического
        /// обновления элементов управления при изменении данных.
        /// </remarks>
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

        /// <summary>
        /// Полное имя абитуриента (фамилия, имя, отчество).
        /// </summary>
        /// <remarks>
        /// Атрибут <see cref="DisplayNameAttribute"/> задаёт текст заголовка
        /// для элементов управления, поддерживающих отображение метаданных
        /// (например, <see cref="DataGridView"/> в режиме AutoGenerateColumns).
        /// </remarks>
        [DisplayName("ФИО")]
        public string FullName
        {
            get => fullName;
            set => SetProperty(ref fullName, value);
        }

        /// <summary>
        /// Пол абитуриента.
        /// </summary>
        /// <value>
        /// Одно из допустимых значений: <c>"Мужской"</c> или <c>"Женский"</c>.
        /// </value>
        [DisplayName("Пол")]
        public Gender Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        /// <summary>
        /// Дата рождения абитуриента.
        /// </summary>
        /// <value>
        /// Значение типа <see cref="DateTime"/>, используемое для расчёта возраста.
        /// </value>
        [DisplayName("Дата рождения")]
        public DateTime DateBirth
        {
            get => dateBirth;
            set => SetProperty(ref dateBirth, value);
        }

        /// <summary>
        /// Форма обучения абитуриента.
        /// </summary>
        /// <value>
        /// Одно из допустимых значений: <c>"Очное"</c>, <c>"Очно-заочное"</c>, <c>"Заочное"</c>.
        /// </value>
        [DisplayName("Форма обучения")]
        public string FormOfEducation
        {
            get => formOfEducation;
            set => SetProperty(ref formOfEducation, value);
        }

        /// <summary>
        /// Балл ЕГЭ по математике.
        /// </summary>
        /// <remarks>
        /// При изменении значения автоматически уведомляется свойство
        /// <see cref="TotalScore"/> для обновления отображаемой суммы баллов.
        /// </remarks>
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

        /// <summary>
        /// Балл ЕГЭ по русскому языку.
        /// </summary>
        /// <seealso cref="MathScores"/>
        /// <seealso cref="ComputerScienceScores"/>
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

        /// <summary>
        /// Балл ЕГЭ по информатике.
        /// </summary>
        /// <seealso cref="MathScores"/>
        /// <seealso cref="RusScores"/>
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

        /// <summary>
        /// Суммарный балл ЕГЭ по трём предметам.
        /// </summary>
        /// <remarks>
        /// Это свойство только для чтения (get-only) и не хранит состояние.
        /// Автоматически обновляется при изменении любого из баллов
        /// благодаря механизму <see cref="INotifyPropertyChanged"/>.
        /// </remarks>
        /// <seealso cref="MathScores"/>
        /// <seealso cref="RusScores"/>
        /// <seealso cref="ComputerScienceScores"/>
        [DisplayName("Сумма баллов")]
        public int TotalScore => MathScores + RusScores + ComputerScienceScores;
    }
}
