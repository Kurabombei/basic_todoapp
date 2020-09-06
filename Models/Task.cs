using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;


namespace ToDoApp.Models
{
    public class Task
    {
        //[Key]
        public int Id { get; set; }
        //[Required]
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public Boolean Done { get; set; }
    }
}
