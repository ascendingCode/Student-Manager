using System;
using System.Collections.Generic;
namespace src
{
    class Database
    {
        private string[,] database = new string[0,0];
        public int Cools { get { return Settings.MaxCools; } } 
        public int Count { get { return database.GetLength(0); } }
     
        public void Add(Student student)
        {
            string[,]save = database; //0, 0
            database = new string[save.GetLength(0) + 1, Settings.MaxCools]; 
            CopyArray(save, ref database);
            int maxRow = (database.GetLength(0) - 1) < 0 ? 0 : (database.GetLength(0) - 1);

            database[maxRow, Settings.NameIndex] = student.name;
            database[maxRow, Settings.AgeIndex] = student.age.ToString(); 
            database[maxRow, Settings.CourseIndex] = student.course.ToString();
            database[maxRow, Settings.RegistrationIndex] = student.RegistrationDate.ToString();
            database[maxRow, Settings.GuidIndex] = student.id.ToString();

        }
        private void CopyArray(string[,]array, ref string[,]outArray)
        {
            for(int i = 0;i < array.GetLength(0); i++)
            {
                for(int j = 0;j < array.GetLength(1); j++)
                {
                        outArray[i,j] = array[i,j];
                }
             }
        }
        private bool CountIsNull()=> Count <= 0 ? true : false;
        public void Add(List<Student> students)
        {
            for(int i = 0; i < students?.Count; i++)
                if(students[i].age >= Settings.MinAge)
                    Add(students[i]);
        }
        public bool IsInDataBase(Guid guid)
        {
            for(int i = 0; i < database.GetLength(0); i++)
            {
                if(database[i, Settings.GuidIndex] == guid.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public void PrintAllStudents()
        {
            for(int i = 0; i < database.GetLength(0); i++)
            {
                Console.WriteLine("Student number {0}", i + 1);
                for(int j = 0; j < database.GetLength(1); j++)
                {
                    Console.WriteLine(database[i,j]);
                }
            }
        }
        public string[] GetStudentInfo(Guid guid)
        {
            if(IsInDataBase(guid))
            {
                for(int i = 0; i < database.GetLength(0); i++)
                {
                    if(database[i, Settings.GuidIndex] == guid.ToString())
                    {
                        string[] Information = new string[Settings.MaxCools];
                        for(int j = 0; j < Information.Length; j++)
                        {
                            Information[j] = database[i ,j];
                        }
                        return Information;
                    }
                }
            }
            return null;
        }
        public string[,]FindByNameS(string name)
        {
            string[,]result = new string[0,0];
            name??=string.Empty;
            int saveIndex = 0;
            for(int i = 0; i < database.GetLength(0); i++)
            {
                string GetName = database[i, Settings.NameIndex];
                for(int j = 0; j < name.Length; j++)
                {
                    if(GetName[j] != name[j])
                    {
                        break;
                    }
                    if(j == (name.Length - 1))
                    {
                        string[,]save = result;
                        result = new string[result.GetLength(0) + 1, Settings.MaxCools];
                        CopyArray(save, ref result);
                        result[(result.GetLength(0) - 1) < 0 ? 0 : (result.GetLength(0) - 1), Settings.NameIndex] = GetName;
                        result[saveIndex, Settings.AgeIndex] = database[i, Settings.AgeIndex];
                        result[saveIndex, Settings.CourseIndex] = database[i, Settings.CourseIndex];
                        result[saveIndex, Settings.GuidIndex] = database[i, Settings.GuidIndex];
                        result[saveIndex, Settings.RegistrationIndex] = database[i, Settings.RegistrationIndex];
                        saveIndex++;
                    }
                }
            }
            if(result.GetLength(0) != 0)
                return result;
            return null;
        }
        public void Remove(Guid guid)
        {
            if(IsInDataBase(guid))
            {
                int index = 0;
                for(int i = 0; i < database.GetLength(0); i++)
                {
                    if(database[i, Settings.GuidIndex] == guid.ToString())
                    {
                        index = i;
                        break;
                    }
                }
                string[,]save = database;
                database = new string[database.GetLength(0) - 1, Settings.MaxCools];
                for(int i = 0; i < save.GetLength(0); i++)
                {
                    if(i == index)
                        continue;
                    for(int j = 0; j < save.GetLength(1); j++)
                    {
                        if(i > index)
                            database[i - 1,j] = save[i, j];
                        else
                            database[i, j] = save[i,j];
                    }
                }
            }
        }
        public void RemoveLast()
        {
            if(!CountIsNull())
            {
                Remove(Guid.Parse(database[Count - 1, Settings.GuidIndex]));
            }
        }
        public void RemoveFirst()
        {
            if(!CountIsNull())
            {
                Remove(Guid.Parse(database[0, Settings.GuidIndex]));
            }
        }
        public void Clear()
        {
            database = new string[0,0];
        }
        private int GetIndex(Guid guid)
        {
            for(int i = 0; i < database.GetLength(0); i++)
            {
                if(database[i,Settings.GuidIndex] == guid.ToString())
                    return i;
            }
            return -1;
        }
        public void Edit(Guid guid, string newName, int newAge, Course newType)
        {
            if((IsInDataBase(guid)) && (newAge >= Settings.MinAge))
            {
                int index = GetIndex(guid);
                database[index, Settings.NameIndex] = newName ?? "Unknow";
                database[index, Settings.AgeIndex] = newAge.ToString();
                database[index, Settings.CourseIndex] = newType.ToString();
            }
        }
    }
}