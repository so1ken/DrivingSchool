using System;

namespace DrivingSchool.Models
{
    public abstract class Lesson
    {
        public DateTime TimeBegin { get; set; }
        public DateTime TimeFinish { get; set; }
        public string Status { get; set; }

        public void Finish()
        {
            Status = "Завершено";
        }
    }
}