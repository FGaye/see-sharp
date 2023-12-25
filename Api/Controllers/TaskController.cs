using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TodoAppContext _context;

        public TaskController(TodoAppContext context)
        {
            _context = context;
        }


        [HttpPost]

        public ActionResult<Models.Task> CreateTask(Models.Task task)
        {

            var newTask = new Models.Task
            {
                Name = task.Name,
                Description = task.Description,
            };
            _context.Tasks.Add(newTask);
            _context.SaveChanges();


            return Ok();

        }
        

        [HttpGet]
        public ActionResult<IEnumerable<Models.Task>> GetTasks()
        {
            return _context.Tasks.ToList();
        }
        
        [HttpPut("{id}")]
        public ActionResult<Models.Task> UpdateTask(int id, Models.Task task)
        {
            var taskToUpdate = _context.Tasks.Find(id);
            if (taskToUpdate == null)
            {
                return NotFound();
            }

            taskToUpdate.Name = task.Name;
            taskToUpdate.Description = task.Description;
            _context.Tasks.Update(taskToUpdate);
            _context.SaveChanges();
            return Ok();
        }



        [HttpDelete("{id}")]
        public ActionResult<Models.Task> DeleteTask(int id)
        {
            var taskToDelete = _context.Tasks.Find(id);

            if(taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
            
        }
    }
}