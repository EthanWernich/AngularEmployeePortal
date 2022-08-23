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
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> Get()
        {
            return await _context.Departments.ToListAsync();
        }

        [HttpGet("{DepartmentId}")]
        public async Task<ActionResult<Department>> Get(int DepartmentId)
        {
            var Departments = await _context.Departments.FindAsync(DepartmentId);

            if (Departments == null)
            {
                return NotFound();
            }

            return Departments;
        }

        [HttpPut("{DepartmentId}")]
        public async Task<IActionResult> Put(int DepartmentId, Department Departments)
        {
            if (DepartmentId != Departments.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(Departments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(DepartmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(Departments);
        }

        private bool DepartmentExists(int DepartmentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<Department>> Post(Department Departments)
        {
            _context.Departments.Add(Departments);
            await _context.SaveChangesAsync();
            return Ok(Departments);
        }


        [HttpDelete("{DepartmentId}")]
        public async Task<IActionResult> Delete(int DepartmentId)
        {
            var Departments = await _context.Departments.FindAsync(DepartmentId);
            if (Departments == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(Departments);
            await _context.SaveChangesAsync();
            return Ok(Departments);
        }
    }
}
