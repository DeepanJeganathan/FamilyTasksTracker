using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Model
{
    public enum Relationship
    {
        Mother,
        Father,
        Son,
        Daughter,
        GrandFather,
        GrandMother,
        Uncle,
        Aunt
    }

    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public Relationship Relationship { get;set; }   
        public ICollection<TaskToDo> Tasks { get; set; }
        public Email Email { get; set; }
    }
}
