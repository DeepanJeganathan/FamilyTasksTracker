using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTasksTracker.Model
{
    public class Email
    {
        [Key]
        public int EmailId { get; set; }
        [Required]
        public int EmailAddress { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
