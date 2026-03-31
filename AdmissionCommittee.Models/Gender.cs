using System.ComponentModel;

namespace AdmissionCommittee.Models
{

    /// <summary>
    /// Пол абитуриента.
    /// </summary>
    /// <remarks>
    /// Класс предоставляет типобезопасное представление пола абитуриента.
    /// Использует паттерн "Enum-like class" для возможности расширения
    /// и централизованного управления допустимыми значениями.
    /// </remarks>
    public class Gender
    {

        /// <summary>
        /// Мужской пол.
        /// </summary>
        /// <value>
        /// Предопределённый экземпляр <see cref="Gender"/> с отображаемым именем "Мужской".
        /// </value>
        public static readonly Gender Male = new Gender("Мужской");

        /// <summary>
        /// Женский пол.
        /// </summary>
        /// <value>
        /// Предопределённый экземпляр <see cref="Gender"/> с отображаемым именем "Женский".
        /// </value>
        public static readonly Gender Female = new Gender("Женский");

        /// <summary>
        /// Отображаемое имя пола для пользовательского интерфейса.
        /// </summary>
        /// <value>
        /// Строка, используемая для отображения в элементах управления
        /// (например, <see cref="System.Windows.Forms.ComboBox"/>).
        /// </value>
        [DisplayName("Пол")]
        public string DisplayName { get; }

        private Gender(string displayName)
        {
            DisplayName = displayName;
        }

        /// <summary>
        /// Возвращает перечисление всех допустимых значений пола.
        /// </summary>
        /// <returns>
        /// Коллекция <see cref="IEnumerable{Gender}"/>, содержащая <see cref="Male"/> и <see cref="Female"/>.
        /// </returns>
        /// <remarks>
        /// Удобно для заполнения элементов выбора в интерфейсе:
        /// <code>
        /// cmbGender.Items.AddRange(Gender.GetAll().ToArray());
        /// </code>
        /// </remarks>
        public static IEnumerable<Gender> GetAll()
        {
            yield return Male;
            yield return Female;
        }

        /// <summary>
        /// Возвращает строковое представление пола.
        /// </summary>
        /// <returns>Отображаемое имя пола (<see cref="DisplayName"/>).</returns>
        /// <remarks>
        /// Переопределяет метод <see cref="object.ToString()"/> для удобства отображения
        /// в элементах управления и при отладке.
        /// </remarks>
        public override string ToString() => DisplayName;
    }
}
