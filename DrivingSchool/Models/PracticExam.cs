using System;
using System.Linq;

namespace DrivingSchool.Models
{
    public class PracticExam
    {
        public DateTime DateTime { get; set; }
        public string Result { get; set; }
        public int PenaltyPoints { get; set; }

        public Student Student { get; set; }
        public Examiner Examiner { get; set; }

        public string ConductExam(params int[] penaltyPoints)
        {
            // Проверяем наличие студента и объекта допуска
            if (Student == null || Student.Access == null)
            {
                Result = "Нет данных о допуске";
                return Result;
            }

            // Получаем количество учебных часов
            int theory = Student.GetTheoryHours();
            int practic = Student.GetPracticeHours();

            // Проверяем возможность сдачи экзамена
            if (!Student.Access.CheckCriteria(theory, practic))
            {
                Result = "Студент не допущен к экзамену";
                return Result;
            }

            // Собственный вызов метода подсчета штрафных баллов
            CalculatePenaltyPoints(penaltyPoints);

            Result = $"Экзамен завершён. Штрафные баллы: {PenaltyPoints}";

            return Result;
        }

        private void CalculatePenaltyPoints(int[] penaltyPoints)
        {
            if (penaltyPoints == null)
                throw new ArgumentNullException(nameof(penaltyPoints));

            if (penaltyPoints.Any(points => points < 0))
                throw new ArgumentOutOfRangeException(
                    nameof(penaltyPoints),
                    "Штрафные баллы не могут быть отрицательными."
                );

            PenaltyPoints = penaltyPoints.Sum();
        }
    }
}