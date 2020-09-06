using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ToDoApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();// migrate() made a lot of bugs

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}
