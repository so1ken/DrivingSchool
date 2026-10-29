using System;
using DrivingSchool.Models;
using DrivingSchool.Controllers;

namespace DrivingSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                FIO = "Иванов Иван",
                Phone = "+79991112233",
                Access = new AccessOfExam()
            };

            // Добавим часов для теста допуска
            for (int i = 0; i < 16; i++) student.TheoryLessons.Add(new TheoryLesson()); // 32 часа
            for (int i = 0; i < 30; i++) student.PracticLessons.Add(new PracticLesson()); // 60 часов

            // Проверка допуска через контроллер
            var examController = new ExamController();
            string examResult = examController.StartExam(student);
            Console.WriteLine("Результат проверки допуска: " + examResult);

            // Проверка нового сценария - Запись на занятие
            var schedule = new Schedule();
            var instructor = new Instructor { FIO = "Петров П.П." };
            var car = new Car { StateNumber = "Х123УМ70" };
            var lessonController = new LessonController();

            bool isBooked = lessonController.BookPracticLesson(
                schedule, student, instructor, car,
                DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2)
            );

            Console.WriteLine("Статус записи на практическое занятие: " + (isBooked ? "Успешно записан" : "Время занято"));
        }
    }
}