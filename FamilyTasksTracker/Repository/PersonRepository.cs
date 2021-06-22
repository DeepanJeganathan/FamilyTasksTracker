using FamilyTasksTracker.Data;
using FamilyTasksTracker.Model;
using FamilyTasksTracker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Repository
{
    public class PersonRepository : IPerson
    {
        private readonly FamilyTasksTrackerDbContext _context;

        public PersonRepository(FamilyTasksTrackerDbContext familyTasksTrackerDbContext)
        {
            this._context = familyTasksTrackerDbContext;
        }
        public bool Create(Person person)
        {
            _context.Persons.Add(person);
            return Save();
        }

        public bool Delete(Person person)
        {
            _context.Persons.Remove(person);
            return Save();
        }

        public Person Get(int id)
        {
            return _context.Persons.FirstOrDefault(x => x.PersonId == id);
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool TaskExists(int id)
        {
           return _context.Persons.Any(x => x.PersonId == id);
        }

        public bool Update(Person person)
        {
            _context.Persons.Update(person);
            return Save();
        }
    }
}
