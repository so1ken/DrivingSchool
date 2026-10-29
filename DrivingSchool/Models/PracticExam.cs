using System;

namespace DrivingSchool.Models
{
    public class PracticExam
    {
        public DateTime DateTime { get; set; }
        public string Result { get; set; }
        public int PenaltyPoints { get; set; }
        public Student Student { get; set; }
        public Examiner Examiner { get; set; }
    }
}