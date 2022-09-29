namespace api.Entities
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public Person()
        {
            Skills = new List<Skill>();
        }
    }
}