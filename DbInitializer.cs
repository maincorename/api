namespace api
{
    using System.Collections.Generic;

    using api.Entities;

    /// <summary>
    /// Инициализатор бд.
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// Инициализировать записи в бд.
        /// </summary>
        /// <param name="my"> Контекст. </param>
        public static void Initialize(MyContext my)
        {
            var pers2 = new Person
            {
                Name = "Виталий",
                DisplayName = "HR",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "sk3",
                        Level = 5
                    },
                    new Skill
                    {
                        Name = "sk4",
                        Level = 6
                    }
                }
            };

            var pers = new Person
            {
                Name = "Олег",
                DisplayName = "Middle",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "Скилл1",
                        Level = 3
                    },
                    new Skill
                    {
                        Name = "Скилл2",
                        Level = 4
                    }
                }
            };

            my.Persons.Add(pers);
            my.Persons.Add(pers2);
            my.SaveChanges();
        }
    }
}