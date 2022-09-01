using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_4.Models;
using WebAPI_4.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a employee
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employeeList = await _context.Employees.ToListAsync();
            return employeeList;
        }
        /// <summary>
        /// Get a employee by EmployeeId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int Id)
        {
            var employees = await _context.Employees.FindAsync(Id);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }
        //Update
        /// <summary>
        /// Update a existing employee
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Employees"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, Employee Employees)
        {
            if (Id != Employees.Id)
            {
                return BadRequest();
            }

            _context.Entry(Employees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(Employees);
        }

        private bool EmployeeExists(int Id)
        {
            throw new NotImplementedException();
        }
        //Add
        /// <summary>
        /// Add a employee
        /// </summary>
        /// <param name="Employees"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee Employees)
        {
            _context.Employees.Add(Employees);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                var t = 5;
            }
            return Ok(Employees);
        }

        /// <summary>
        /// Delete Employee by EmployeeId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Employees = await _context.Employees.FindAsync(id);
            if (Employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(Employees);
            await _context.SaveChangesAsync();

            return Ok(Employees);
        }

        private bool InspectionExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
