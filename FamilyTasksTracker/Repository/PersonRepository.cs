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
        public async Task<bool> Create(Person person)
        {
            await _context.Persons.AddAsync(person);
            return await Save();
        }

        public async Task<bool> Delete(Person person)
        {
            _context.Persons.Remove(person);
            return await Save();
        }

        public Person Get(int id)
        {
            return _context.Persons.FirstOrDefault(x => x.PersonId == id);
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public bool Exists(int id)
        {
           return _context.Persons.Any(x => x.PersonId == id);
        }

        public async Task<bool> Update(Person person)
        {
            _context.Persons.Update(person);
            return await Save();
        }
    }
}
