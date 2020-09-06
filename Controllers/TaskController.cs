using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;


namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        ApplicationContext db;
        public TaskController(ApplicationContext context){
            db = context;
            if (!db.Tasks.Any())
            {
                db.Tasks.Add(new Task { Text = "To do math!", Category = "Homework", Date = DateTime.Today.Date.AddHours(5), Done = false });
                //db.Tasks.Add(new Task { Text = "To do chemistry!", Category = new Category { Name = "Homework", Color = "Yellow" }, Date = DateTime.Today, Done = false });
                db.Tasks.Add(new Task { Text = "To add angular material", Category = "Work", Date = DateTime.Today.Date.AddHours(5), Done = false});
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return db.Tasks.ToList();
        }

        [HttpGet("{id}")]
        public Task Get(int id)
        {
            Task task = db.Tasks.FirstOrDefault(x => x.Id == id);
            return task;
        }

        [HttpPost]
        public IActionResult Post(Task task)
        {
            if (ModelState.IsValid)
            {
                task.Date.AddHours(5);
                db.Tasks.Add(task);
                db.SaveChanges();
                return Ok(task);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Task task)
        {
            if (ModelState.IsValid)
            {
                task.Date.AddHours(5);
                db.Update(task);
                db.SaveChanges();
                return Ok(task);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Task task = db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return Ok(task);
        }
    }
}
