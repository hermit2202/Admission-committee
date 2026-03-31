namespace AdmissionCommittee.Models
{
    /// <summary>
    /// Константы валидации и бизнес-правила приложения «Приёмная комиссия».
    /// </summary>
    /// <remarks>
    /// Эти константы используются на всех слоях приложения:
    /// <list type="bullet">
    /// <item>UI — для валидации ввода и отображения подсказок</item>
    /// <item>BL — для проверки бизнес-правил в <see cref="Services.AdmissionService"/></item>
    /// <item>DAL — при необходимости фильтрации данных</item>
    /// </list>
    /// </remarks>
    public static class ValidationConstants
    {
        /// <summary>
        /// Минимальная длина ФИО абитуриента.
        /// </summary>
        public const int MinFullNameLength = 3;

        /// <summary>
        /// Минимальный допустимый возраст абитуриента (лет).
        /// </summary>
        public const int MinAge = 10;

        /// <summary>
        /// Максимальный допустимый возраст абитуриента (лет).
        /// </summary>
        public const int MaxAge = 100;

        /// <summary>
        /// Возраст по умолчанию для нового абитуриента (лет).
        /// Используется при инициализации формы.
        /// </summary>
        public const int DefaultStudentAge = 18;

        /// <summary>
        /// Минимальный балл по предмету ЕГЭ.
        /// </summary>
        public const int MinScore = 0;

        /// <summary>
        /// Максимальный балл по предмету ЕГЭ.
        /// </summary>
        public const int MaxScore = 100;

        /// <summary>
        /// Максимальная сумма баллов по трём предметам.
        /// </summary>
        public const int MaxTotalScore = MaxScore * 3;

        /// <summary>
        /// Пороговый балл для отбора абитуриентов (используется в статистике).
        /// </summary>
        public const int PassThreshold = 150;
    }
}