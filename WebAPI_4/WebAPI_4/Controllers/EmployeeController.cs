using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Employee>> GetEmployees(int Id)
        {
            var employees = await _context.Employees.FindAsync(Id);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

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

        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee Employees)
        {
            _context.Employees.Add(Employees);
            await _context.SaveChangesAsync();          
            return Ok(Employees);
        }


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
