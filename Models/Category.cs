using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Category
    {
        //[Key]
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        public string Color { get; set; }
        //public virtual List<Task> Tasks { get; set; }

    }
}
