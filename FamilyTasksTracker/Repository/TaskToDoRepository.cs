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

        public async Task<bool> Create(TaskToDo taskToDo)
        {
            await _context.AddAsync(taskToDo);

            return await Save();
            
        }

        public async Task<bool> Delete(TaskToDo taskToDo)
        {
            _context.Remove(taskToDo);
            return await Save();
        }

        public bool Exists(int id)
        {
            return _context.TaskToDos.Any(x => x.TaskToDoId == id);
        }

        public TaskToDo Get(int id)
        {
            return _context.TaskToDos.FirstOrDefault(x => x.TaskToDoId == id);
        }

        public List<TaskToDo> GetAll()
        {
            return _context.TaskToDos.ToList();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> Update(TaskToDo taskToDo)
        {
            _context.TaskToDos.Update(taskToDo);
            return await Save();
        }
    }
}
