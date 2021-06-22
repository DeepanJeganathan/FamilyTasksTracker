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
        bool Create(Person person);
        bool Update(Person person);
        bool Delete(Person person);
        bool TaskExists(int id);
        bool Save();
    }
}
