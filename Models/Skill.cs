namespace api.Entities
{
    /// <summary>
    /// Класс скиллов.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Уровень.
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сотрудник.
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Ид.
        /// </summary>
        public long? SkillId { get; set; }
    }
}