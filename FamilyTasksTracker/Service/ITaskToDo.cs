using FamilyTasksTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Service
{
   public interface ITaskToDo
    {
        List<TaskToDo> GetAll();
        TaskToDo Get(int id);
        bool Create(TaskToDo taskToDo);
        bool Update(TaskToDo taskToDo);
        bool Delete(TaskToDo taskToDo);
        bool TaskExists(int id);
        bool Save();

    }
}
