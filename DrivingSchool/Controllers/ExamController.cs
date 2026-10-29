using DrivingSchool.Models;

namespace DrivingSchool.Controllers
{
    public class ExamController
    {
        public string StartExam(Student student)
        {
            // Получаем часы из модели студента
            int theory = student.GetTheoryHours();
            int practic = student.GetPracticeHours();

            // Проверяем критерии допуска
            if (student.Access != null && student.Access.CheckCriteria(theory, practic))
            {
                return "Доступ разрешен."; 
            }

            return "Отказ. Нет допуска к экзамену.";
        }
    }
}