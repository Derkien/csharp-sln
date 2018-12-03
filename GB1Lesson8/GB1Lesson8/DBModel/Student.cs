using System;

namespace GB1Lesson8.DBModel
{
    [Serializable]
    public class Student
    {
        public Student()
        {

        }

        public Student(
            string firstname,
            string lastname,
            string university,
            string faculty,
            string department,
            int age,
            int course,
            string group,
            string city
            )
        {
            Firstname = firstname;
            Lastname = lastname;
            University = university;
            Faculty = faculty;
            Department = department;
            Age = age;
            Course = course;
            Group = group;
            City = city;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }
        public string City { get; set; }
    }
}
