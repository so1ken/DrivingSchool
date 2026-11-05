using System;
using System.Collections.Generic;

namespace DrivingSchool.Models
{
    public class Examiner
    {
        public string FIO { get; set; }

        public List<PracticExam> Exams { get; set; } = new List<PracticExam>();

        public string HoldExam(PracticExam exam, params int[] penaltyPoints)
        {
            if (exam == null)
                throw new ArgumentNullException(nameof(exam));

            // Связываем экзамен с экзаменатором
            exam.Examiner = this;

            // Добавляем экзамен в список экзаменатора
            if (!Exams.Contains(exam))
                Exams.Add(exam);

            // Передаем проведение экзамена объекту PracticExam
            return exam.ConductExam(penaltyPoints);
        }
    }
}