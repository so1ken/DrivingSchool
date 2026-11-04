using System;
using System.Collections.Generic;
using DrivingSchool.Models;
using DrivingSchool.Controllers;

namespace DrivingSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            // Допуск к экзамену - accessСмирнова
            var accessSmirnova = new AccessOfExam
            {
                HaveAccess = true
            };

            // Студент АлексейСмирнов
            var student = new Student
            {
                FIO = "Смирнов Алексей Иванович",
                Phone = "+79521685212",
                BirthDay = new DateTime(2004, 5, 11), // На диаграмме "11.05.2004"
                Access = accessSmirnova,
                PracticLessons = new List<PracticLesson>(),
                TheoryLessons = new List<TheoryLesson>()
            };

            // Инструктор ЛеонидСизюков
            var instructor = new Instructor
            {
                FIO = "Сизюков Леонид Васильевич",
                Experience = 13,
                CategoryDL = "B"
            };

            // Автомобиль Lada Granta
            var car = new Car
            {
                StateNumber = "А317МВ70",
                Model = "Lada Granta sedan",
                TypeGearbox = "Mechanical"
            };

            // Расписание
            var schedule = new Schedule();

            // Практические занятия practic29 и practic30
            var practic29 = new PracticLesson
            {
                TimeBegin = new DateTime(2026, 6, 10, 19, 30, 0), // "10.06.2026 19:30"
                TimeFinish = new DateTime(2026, 6, 10, 21, 0, 0), // "10.06.2026 21:00"
                Status = "Завершено",
                Venue = "Город",
                Instructor = instructor
          
            };

            var practic30 = new PracticLesson
            {
                TimeBegin = new DateTime(2026, 6, 15, 9, 30, 0), // "15.06.2026 9:30"
                TimeFinish = new DateTime(2026, 6, 15, 11, 0, 0), // "15.06.2026 11:00"
                Status = "Завершено",
                Venue = "Город",
                Instructor = instructor,
                Car = car
            };

            // Связываем студента с занятиями 
            student.PracticLessons.Add(practic29);
            student.PracticLessons.Add(practic30);

            // Связываем расписание с занятиями
            schedule.Lessons.Add(practic29);
            schedule.Lessons.Add(practic30);

            // Проверка допуска через ExamController
            var examController = new ExamController();
            string examResult = examController.StartExam(student);
            Console.WriteLine("Результат проверки допуска: " + examResult);

            // Проверка бронирования нового занятия через LessonController
            // Используем автомобиль и инструктора из диаграммы
            var lessonController = new LessonController();

            bool isBooked = lessonController.BookPracticLesson(
                schedule,
                student,
                instructor,
                car,
                new DateTime(2026, 6, 20, 10, 0, 0),
                new DateTime(2026, 6, 20, 12, 0, 0)
            );

            Console.WriteLine("Статус записи на новое практическое занятие: " +
                              (isBooked ? "Успешно записан" : "Время занято"));

            // Демонстрация того, что новое занятие добавилось и в расписание, и к студенту
            Console.WriteLine($"Всего практических занятий у студента: {student.PracticLessons.Count}");
            Console.WriteLine($"Всего занятий в расписании: {schedule.Lessons.Count}");
        }
    }
}
