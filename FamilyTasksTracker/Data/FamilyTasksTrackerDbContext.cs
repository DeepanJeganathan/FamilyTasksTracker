using FamilyTasksTracker.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Data
{
    public class FamilyTasksTrackerDbContext:DbContext
    {
        public FamilyTasksTrackerDbContext(DbContextOptions<FamilyTasksTrackerDbContext> options):base(options)
        {
        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TaskToDo> TaskToDos { get; set; }


    }
}
