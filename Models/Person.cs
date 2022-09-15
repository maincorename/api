﻿namespace api.Entities
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public Person()
        {
            Skills = new List<Skill>();
        }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public Guid PersonId { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}