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

        public async Task<bool> Create(Email email)
        {
            await _context.Emails.AddAsync(email);
            return await Save();
        }

        public async Task<bool> Delete(Email email)
        {
            _context.Emails.Remove(email);
            return await Save();
        }

        public bool Exists(int id)
        {
            return _context.Emails.Any(x => x.EmailId == id);
        }

        public Email Get(int id)
        {
            return _context.Emails.FirstOrDefault(x => x.EmailId == id);
        }

        public List<Email> GetAll()
        {
            return _context.Emails.ToList();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> Update(Email email)
        {
            _context.Emails.Update(email);
            return await Save();
        }
    }
}
