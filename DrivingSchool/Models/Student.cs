using System;
using System.Collections.Generic;

namespace DrivingSchool.Models
{
    public class Student
    {
        public string FIO { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }

        public AccessOfExam Access { get; set; }
        public List<PracticLesson> PracticLessons { get; set; } = new List<PracticLesson>();
        public List<TheoryLesson> TheoryLessons { get; set; } = new List<TheoryLesson>();

        public int GetPracticeHours()
        {
            return PracticLessons.Count * 2;
        }

        public int GetTheoryHours()
        {
            return TheoryLessons.Count * 2;
        }
    }
}