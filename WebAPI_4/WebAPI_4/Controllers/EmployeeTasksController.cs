using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WebAPI_4.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebAPI_4.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_4.Controllers
{
    // 
    [Route("api/employeeTasks")]
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
            return await _context.Tasks.ToListAsync();
        }


        
        /// <summary>
        /// Get all employeetasks by employeeId.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeTasks>> GetTaskByEmployeeId(int employeeId)
        {
            var Tasks = await _context.Tasks.FindAsync(employeeId);

            if (Tasks == null)
            {
                return NotFound();
            }

            return Tasks;
            
        }
        /// <summary>
        /// Update employeeTasks by employeeId.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="Tasks"></param>
        /// <returns></returns>

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> Put(int employeeId, EmployeeTasks Tasks)
        {
            if (employeeId != Tasks.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(Tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTaskExists(employeeId))
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

        private bool EmployeeTaskExists(int employeeId)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Edit employeetasks by employeeId
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EmployeeTasks>> Post(EmployeeTasks tasks)
        {
            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();
            return Ok(tasks);
        }

        [HttpDelete("{EmployeeId}")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            var Tasks = await _context.Tasks.FindAsync(employeeId);
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
