namespace api.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Класс сотрудника.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Ид.
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Выводимое имя.
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Скилы сотрудника.
        /// </summary>
        public ICollection<Skill> Skills { get; set; }
        
        /// <summary>
        /// Создать сотрудника.
        /// </summary>
        public Person()
        {
            Skills = new List<Skill>();
        }
    }
}