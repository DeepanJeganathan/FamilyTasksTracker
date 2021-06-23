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
        Task<bool> Create(TaskToDo taskToDo);
        Task<bool> Update(TaskToDo taskToDo);
        Task<bool> Delete(TaskToDo taskToDo);
        bool Exists(int id);
        Task<bool> Save();

    }
}
