namespace DrivingSchool.Models
{
    public class AccessOfExam
    {
        public bool HaveAccess { get; set; }

        public bool CheckCriteria(int theoryHours, int practicHours)
        {
            HaveAccess = theoryHours >= 30 && practicHours >= 56;
            return HaveAccess;
        }
    }
}