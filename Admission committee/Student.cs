using System.ComponentModel;

namespace AdmissionCommittee;

public class Student
{
    [DisplayName("ФИО")]
    public string FullName { get; set; } = string.Empty;
    [DisplayName("Пол")]
    public string Gender { get; set; } = "М";
    [DisplayName("Дата рождения")]
    public DateTime DateBirth { get; set; }
    [DisplayName("Форма обучения")]
    public string FormOfEducation { get; set; } = string.Empty;
    [DisplayName("Баллы ЕГЭ по математике")]
    public int MathScores { get; set; }
    [DisplayName("Баллы ЕГЭ по русскому")]
    public int RusScores { get; set; }
    [DisplayName("Баллы ЕГЭ по информатике")]
    public int ComputerScienceScores { get; set; }
    [DisplayName("Сумма баллов")]
    public int TotalScore => MathScores + RusScores + ComputerScienceScores;
}
