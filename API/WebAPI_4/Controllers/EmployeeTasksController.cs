using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_4.Data;
using WebAPI_4.Models;

namespace WebAPI_4.Controllers
{
    [Route("api/EmployeeTasks")]
    [ApiController]

    public class EmployeeTasksController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeTasksController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all employeetasks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTasks>>> GetTasks()
        {
            var query = from task in _context.Tasks
                        .Include(e => e.Employee) 
                        select task;

            var tasks = await query.ToListAsync();
            return tasks;
        }

        /// <summary>
        /// Get employeetask by taskId.
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<EmployeeTasks>> GetTaskByTaskId(int taskId)
        {
            var Task = await _context.Tasks.FindAsync(taskId);

            if (Task == null)
            {
                return NotFound();
            }

            return Task;

        }

        /// <summary>
        /// Update employeeTasks by employeeId.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="Tasks"></param>
        /// <returns></returns>
        [HttpPut("Employee/{EmployeeId}")]
        public async Task<IActionResult> Put(int EmployeeId, EmployeeTasks Tasks)
        {
            if (EmployeeId != Tasks.EmployeeId)
            {
                return BadRequest();
            }

            var createdOn = await _context.Tasks.Where(t => t.Id == Tasks.Id).Select(t => t.CreatedOn).FirstOrDefaultAsync();

            Tasks.CreatedOn = createdOn;
            Tasks.ModifiedOn = DateTime.Now;

            try
            {
                _context.Entry(Tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception error)
            {
                if (!EmployeeTaskExists(EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(Tasks);

        }

        private bool EmployeeTaskExists(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add employeetasks by employeeId
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost("Employee/{EmployeeId}")]
        public async Task<ActionResult<EmployeeTasks>> Post(int EmployeeId, EmployeeTasks task)
        {
            if (EmployeeId != task.EmployeeId)
            {
                return BadRequest();
            }

            task.CreatedOn = DateTime.Now;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }
        /// <summary>
        /// Delete a employee task
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var Tasks = await _context.Tasks.FindAsync(Id);
            if (Tasks == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(Tasks);
            await _context.SaveChangesAsync();
            return Ok(Tasks);
        }
    }
}
