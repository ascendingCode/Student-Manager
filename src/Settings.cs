namespace src
{
    static class Settings
    {
        public static readonly int MaxCools = 5; // Это поле отвечает за максимальный размер колонок в базе данных, а также за размер возвращаемого массива. 
        public static readonly int MinCools = 5; //Тоже самое, что и MaxCools, только отвечает за минимальный размер. Не рекомендуется менять это поле. 

        public static readonly int NameIndex = 0; //Это поле отвечает за индекс имени.
        public static readonly int AgeIndex = 1; // Это поле отвечает за индекс возраста.
        public static readonly int CourseIndex = 2; //Это поле отвечает за индекс курса.
        public static readonly int RegistrationIndex = 3; // Это поле отвечает за индекс даты регестрации.
        public static readonly int GuidIndex = 4;  //Это поле отвечает за индекс айди студента.

        public static readonly int MinAge = 10; //Это поле отвечает за минимальный возраст студента.

    }
}