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
        Task<bool> Create(Email email);
        Task<bool> Update(Email email);
        Task<bool> Delete(Email email);
        bool Exists(int id);
        Task<bool> Save();
    }
}
