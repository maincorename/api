namespace api.Entities
{
    using System;

    public class Skill
    {
        public byte Level { get; set; }
        public string Name { get; set; }

        public long? SkillId { get; set; }
        public Person Person { get; set; }
    }
}