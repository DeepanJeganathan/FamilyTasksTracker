using FamilyTasksTracker.Model;
using FamilyTasksTracker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTasksTracker.Data;

namespace FamilyTasksTracker.Repository
{
    public class EmailRepository : IEmail
    {
        private readonly FamilyTasksTrackerDbContext _context;

        public EmailRepository(FamilyTasksTrackerDbContext familyTasksTrackerDbContext)
        {
            this._context = familyTasksTrackerDbContext;
        }
        public bool Create(Email email)
        {
            _context.Emails.Add(email);
            return Save();
        }

        public bool Delete(Email email)
        {
            _context.Emails.Remove(email);
            return Save();
        }

        public Email Get(int id)
        {
            return _context.Emails.FirstOrDefault(x => x.EmailId== id);
        }

        public List<Email> GetAll()
        {
            return _context.Emails.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool TaskExists(int id)
        {
            return _context.Emails.Any(x => x.EmailId == id);
        }

        public bool Update(Email email)
        {
            _context.Emails.Update(email);
            return Save();
        }
    }
}
