using System;

namespace src
{
    enum Course : byte
    {
        First = 1,
        Second,
        Third,
        Fourth
    }
    class Student
    {
        public readonly string name;
        public readonly int age;
        public readonly Course course;
        public readonly Guid id;
        public readonly DateTime RegistrationDate;

        public Student(string name, int age, Course type)
        {
            if(!string.IsNullOrEmpty(name))
            {
                this.name = name;
                this.age = age;
                this.course = type;
                 RegistrationDate = DateTime.Now;
                id = Guid.NewGuid();
            }
        }
        public Student(Student student)
        {
            name = student?.name;
            age = student.age;
            course = student.course;
            id = student.id;
             RegistrationDate = student. RegistrationDate;
        }
    }
}