using FamilyTasksTracker.Data;
using FamilyTasksTracker.Model;
using FamilyTasksTracker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Repository
{
    public class TaskToDoRepository:ITaskToDo
    {
        private readonly FamilyTasksTrackerDbContext _context;

        public TaskToDoRepository(FamilyTasksTrackerDbContext familyTasksTrackerDbContext)
        {
            this._context = familyTasksTrackerDbContext;
        }

        public Task<bool> Create(TaskToDo taskToDo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(TaskToDo taskToDo)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public TaskToDo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskToDo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TaskToDo taskToDo)
        {
            throw new NotImplementedException();
        }
    }
}
