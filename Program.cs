using System;
using System.Collections.Generic;
using src;
namespace StudentManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            List<Student>students = new List<Student>()
            {
                new Student("James", 18, Course.First),
                new Student("Jony", 20, Course.Second),
                new Student("Bob", 23, Course.Third),
                new Student("Zanne", 9, Course.First) // Этот студент не будет добавлен в базу данных, т.к его возраст ниже чем минимальный (Смотреть Settings.cs).
            };
            database.Add(students); //Добавить в базу данных студентов. 
            (string name, int age, string course, string date) = database.GetStudentInfo(students[1].id); //Получим информацию об Jony.
            string[] JonyInfo = database.GetStudentInfoToArray(students[1].id); //Также можно получить информацию в массив.

            Console.WriteLine("Jony information");
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(course);
            Console.WriteLine(date);   
            /*
                Поиск студентов по имени. 
                Можно указывать просто букву, на которую начинается имя, или начало имени.
            */
            (string[]StudentsName, int[]StudentsAge, string[]StudentsCourse, string[]StudentsDate) information = database.FindByName("J"); 
            string[,]FindStudentsArray = database.FindByNameToArray("J"); //Также можно получить результаты поиска в массив.

            Console.WriteLine("=================");
            Console.WriteLine("Searching results: ");
            foreach(string readNames in information.StudentsName)
            {
                Console.WriteLine(readNames);
            }

            if(database.IsInDataBase(students[2].id)) //Если Bob есть в базе данных
            {
                database.Remove(students[2].id); //Удалим его.
                /*
                    Также есть методы RemoveLast, и RemoveFirst.
                    RemoveLast - удаляет последнего студента из базы данных.
                    RemoveFirst - удаляет первого студента из базы данных.
                */
            }
            
            Console.WriteLine("All students: ");
            database.PrintAllStudents(); //Выводим всех студентов на экран, которые есть в базе данных.


            database.Edit(students[1].id, students[1].name, students[1].age, Course.Fourth); //Изменим Jony курс на четвертый.

            JonyInfo = database.GetStudentInfoToArray(students[1].id); //Проверим это.

            Console.WriteLine("New information about Jony.");
            foreach(string readInfo in JonyInfo)
            {
                Console.WriteLine(readInfo);
            }            
            database.Clear(); //Очистим базу данных.
        }
    }
}
