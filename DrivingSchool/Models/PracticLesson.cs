namespace DrivingSchool.Models
{
    public class PracticLesson : Lesson
    {
        public string Venue { get; set; }
        public Instructor Instructor { get; set; }
        public Car Car { get; set; }

        public void RateDriving(int score)
        {
            // Выставление оценки за вождение
        }

        public void HoldPractic()
        {
            // Проведение практического занятия
        }
    }
}