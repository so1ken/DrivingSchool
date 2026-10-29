using System.Collections.Generic;

namespace DrivingSchool.Models
{
    public class Examiner
    {
        public string FIO { get; set; }
        public List<PracticExam> Exams { get; set; } = new List<PracticExam>();

        public void HoldExam()
        {
            // Прием экзамена
        }
    }
}