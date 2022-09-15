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
        /// <param name="my"></param>
        public static void Initialize(MyContext my)
        {
            var sk = new Skill { Name = "Красноречие", Level = 5};
            var sk2 = new Skill { Name = "Крутизна", Level = 7 };
            my.Skills.Add(new Skill { Name = "Усердие", Level = 9 });
            my.Skills.Add(sk);
            my.Skills.Add(sk2);


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
            my.SaveChanges();
        }
    }
}