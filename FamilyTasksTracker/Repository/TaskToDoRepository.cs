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

        public bool Create(TaskToDo taskToDo)
        {
            _context.TaskToDos.Add(taskToDo);
            return Save();
        }

        public bool Delete(TaskToDo taskToDo)
        {
            _context.TaskToDos.Remove(taskToDo);
            return Save();
        }

        public TaskToDo Get(int id)
        {
            return _context.TaskToDos.FirstOrDefault(x => x.TaskToDoId == id);
        }

        public List<TaskToDo> GetAll()
        {
            return _context.TaskToDos.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool TaskExists(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TaskToDo taskToDo)
        {
            _context.TaskToDos.Update(taskToDo);
            return Save();
        }
    }
}
