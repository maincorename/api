namespace api.Entities
{
    using System;

    public class Skill
    {
        public byte Level { get; set; }

        public string Name { get; set; }

        public Guid SkillId { get; set; }

        virtual public Person Person { get; set; }
    }
}