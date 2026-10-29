using System;
using DrivingSchool.Models;

namespace DrivingSchool.Controllers
{
    public class LessonController
    {
        public bool BookPracticLesson(Schedule schedule, Student student, Instructor instructor, Car car, DateTime start, DateTime finish)
        {
            // Проверяем пересечение времени через Расписание
            if (schedule.CheckIntersecption(start))
            {
                return false;
            }

            // Создаем практическое занятие
            var newLesson = new PracticLesson
            {
                TimeBegin = start,
                TimeFinish = finish,
                Status = "Запланировано",
                Venue = "Город",
                Instructor = instructor,
                Car = car
            };

            // Добавляем занятие студенту и в расписание
            student.PracticLessons.Add(newLesson);
            schedule.Lessons.Add(newLesson);

            return true;
        }
    }
}