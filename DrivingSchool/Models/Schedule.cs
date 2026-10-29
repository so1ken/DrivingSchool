using System;
using System.Collections.Generic;

namespace DrivingSchool.Models
{
    public class Schedule
    {
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        public bool CheckIntersecption(DateTime time)
        {
            foreach (var lesson in Lessons)
            {
                if (lesson.TimeBegin <= time && lesson.TimeFinish >= time)
                    return true;
            }
            return false;
        }
    }
}