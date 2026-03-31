using System.ComponentModel;

namespace AdmissionCommittee.Models
{

    /// <summary>
    /// Статистика по абитуриентам приёмной комиссии.
    /// </summary>
    /// <remarks>
    /// Класс содержит агрегированные данные для отображения в статусной строке
    /// главной формы <see cref="Desktop.AdmissionCommitteeForm"/>.
    /// Реализует метод <see cref="ToString"/> для форматирования в человекочитаемую строку.
    /// </remarks>
    public class StudentStatistic
    {

        /// <summary>
        /// Общее количество абитуриентов в реестре.
        /// </summary>
        /// <value>Неотрицательное целое число.</value>
        [DisplayName("Всего")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Количество абитуриентов, набравших сумму баллов выше порогового значения.
        /// </summary>
        /// <value>Неотрицательное целое число, не превышающее <see cref="TotalCount"/>.</value>
        /// <seealso cref="Threshold"/>
        [DisplayName("Прошли порог")]
        public int PassedCount { get; set; }

        /// <summary>
        /// Средний суммарный балл по всем абитуриентам.
        /// </summary>
        /// <value>
        /// Неотрицательное число с плавающей точкой.
        /// Рассчитывается как среднее арифметическое <see cref="Student.TotalScore"/>.
        /// </value>
        [DisplayName("Средний балл")]
        public double AverageScore { get; set; }

        /// <summary>
        /// Максимальный суммарный балл среди всех абитуриентов.
        /// </summary>
        /// <value>
        /// Целое число в диапазоне [<see cref="ValidationConstants.MinScore"/>; <see cref="ValidationConstants.MaxTotalScore"/>].
        /// </value>
        [DisplayName("Лучший результат")]
        public int MaxScore { get; set; }

        /// <summary>
        /// Минимальный суммарный балл среди всех абитуриентов.
        /// </summary>
        /// <value>
        /// Целое число в диапазоне [<see cref="ValidationConstants.MinScore"/>; <see cref="ValidationConstants.MaxTotalScore"/>].
        /// </value>
        [DisplayName("Худший результат")]
        public int MinScore { get; set; }

        /// <summary>
        /// Пороговый балл для отбора абитуриентов (используется при расчёте <see cref="PassedCount"/>).
        /// </summary>
        /// <value>
        /// Значение по умолчанию: <see cref="ValidationConstants.PassThreshold"/> (150 баллов).
        /// </value>
        public int Threshold { get; set; } = 150;

        /// <summary>
        /// Форматирует статистику в строку для отображения в пользовательском интерфейсе.
        /// </summary>
        /// <returns>
        /// Человекочитаемая строка формата:
        /// <code>
        /// "Всего: {TotalCount} | > {Threshold} баллов: {PassedCount} | Средний: {AverageScore:F1} | Худший: {MinScore} | Лучший: {MaxScore}"
        /// </code>
        /// Если <see cref="TotalCount"/> равен 0, возвращает <c>"Нет данных"</c>.
        /// </returns>
        /// <example>
        /// Результат: <c>"Всего: 42 | > 150 баллов: 18 | Средний: 187.3 | Худший: 95 | Лучший: 285"</c>
        /// </example>
        public override string ToString()
        {
            if (TotalCount == 0)
            {
                return "Нет данных";
            }
            return $"Всего: {TotalCount} |" +
                $" > {Threshold} баллов: {PassedCount} |" +
                $" Средний: {AverageScore:F1} |" +
                $" Худший: {MinScore} |" +
                $" Лучший: {MaxScore}";
        }

        /// <summary>
        /// Возвращает пустой объект статистики для случая, когда данные отсутствуют.
        /// </summary>
        /// <value>
        /// Экземпляр <see cref="StudentStatistic"/> со всеми числовыми полями, равными 0.
        /// </value>
        /// <remarks>
        /// Используется в <see cref="Services.AdmissionService.GetStatistics"/>,
        /// когда хранилище не содержит записей.
        /// </remarks>
        public static StudentStatistic Empty => new StudentStatistic
        {
            TotalCount = 0,
            PassedCount = 0,
            AverageScore = 0,
            MaxScore = 0,
            MinScore = 0
        };
    }
}
