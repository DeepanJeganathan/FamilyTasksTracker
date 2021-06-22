using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Model
{
    public class TaskToDo
    {
        [Key]
        public int TaskToDoId { get; set; }
        public string TaskTitle{ get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get { return IsCompleted; } set {value=false; } }
        public DateTime CompleteByDate { get; set; }
        public DateTime StartDate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        
    }
}
