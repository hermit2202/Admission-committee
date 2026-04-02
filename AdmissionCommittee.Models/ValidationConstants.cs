namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Константы, которые нельзя выразить через Data Annotations.
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Возраст по умолчанию для нового абитуриента (лет).
        /// </summary>
        public const int DefaultStudentAge = 18;

        /// <summary>
        /// Пороговый балл для отбора абитуриентов (используется в статистике).
        /// </summary>
        public const int PassThreshold = 150;

        /// <summary>
        /// Максимальная сумма баллов по трём предметам (вычисляемая).
        /// </summary>
        public const int MaxTotalScore = 300;

        /// <summary>
        /// Минимальный возраст для валидации (используется в AdmissionService).
        /// </summary>
        public const int MinAge = 10;

        /// <summary>
        /// Максимальный возраст для валидации (используется в AdmissionService).
        /// </summary>
        public const int MaxAge = 100;
    }
}
