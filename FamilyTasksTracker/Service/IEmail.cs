using FamilyTasksTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Service
{
   public  interface IEmail
    {
        List<Email> GetAll();
        Email Get(int id);
        bool Create(Email email);
        bool Update(Email email);
        bool Delete(Email email);
        bool TaskExists(int id);
        bool Save();
    }
}
