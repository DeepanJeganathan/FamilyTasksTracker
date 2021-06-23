using FamilyTasksTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Service
{
    public interface IPerson
    {
        List<Person> GetAll();
        Person Get(int id);
        Task<bool> Create(Person person);
        Task<bool> Update(Person person);
        Task<bool> Delete(Person person);
        bool Exists(int id);
        Task<bool> Save();
    }
}
