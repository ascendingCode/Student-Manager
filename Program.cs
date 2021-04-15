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
            database.PrintAllStudents(); //Вывести на экран всех студентов, которые есть в базе данных.

            Console.WriteLine("=================");
            Console.WriteLine("Jony information");
            string[]GetStudentInfo = database.GetStudentInfo(students[1].id); // Получаем информацию о студенте Jony по его айди.
            foreach(string info in GetStudentInfo) 
            {
                Console.WriteLine(info);
            }
            Console.WriteLine();

            string[,]FindStudents = database.FindByNameS("J"); //Ищем студентов.

            for(int i = 0; i < FindStudents.GetLength(0); i++) //Выводим на экран результат.
            {
                for(int j = 0; j < FindStudents.GetLength(1); j++)
                {
                    Console.WriteLine(FindStudents[i,j]);
                }
            }
            database.Remove(students[1].id); //Удаляем Jony из базы данных.

            Console.WriteLine(database.IsInDataBase(students[1].id)); //Есть ли Jony в базе данных?

            if(database.IsInDataBase(students[2].id)) //Если Bob есть в базе данных
            {
                database.Edit(students[2].id, students[2].name, students[2].age, Course.Fourth); //Изменим курс на 4.
            }

            GetStudentInfo = database.GetStudentInfo(students[2].id); //Проверим, изменился ли курс у Bob?
            Console.WriteLine(GetStudentInfo[Settings.CourseIndex]); //Да, курс изменился.

            database.Clear(); //Очищаем базу данных.
        }
    }
}
