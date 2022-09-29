namespace api
{
    using System.Linq;

    using api.Entities;
    using Microsoft.EntityFrameworkCore;

    public sealed class MyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
            if (!Persons.Any())
                DbInitializer.Initialize(this);
        }
    }
}