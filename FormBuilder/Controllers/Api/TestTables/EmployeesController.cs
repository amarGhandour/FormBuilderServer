﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Models;
using FormBuilder.Models.Tables;
using FormBuilder.ViewModels.Employee;

namespace FormBuilder.Controllers.Api.TestTables
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

           // var ImageUrl = $"{}";
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
		public async Task<IActionResult> PutEmployee(int id, EmployeeRequestVM employeeRequestVM)
        {
			if (employeeRequestVM == null)
			{
				return BadRequest();
			}

			var department = _context.Departments.FirstOrDefault(e => e.Id == employeeRequestVM.DepartmentId);

			if (department == null)
			{
				return BadRequest("no department with this id");
			}

			var employee = new Employee()
			{
                Id = id,
				DepartmentId = employeeRequestVM.DepartmentId,
				FirstName = employeeRequestVM.FirstName,
				LastName = employeeRequestVM.LastName,
				Salary = employeeRequestVM.Salary,
				Email = employeeRequestVM.Email,
				Password = employeeRequestVM.Password,
				StartDate = employeeRequestVM.StartDate,
				Gender = employeeRequestVM.Gender,
				Notes = employeeRequestVM.Notes,
				SocialStatus = employeeRequestVM.SocialStatus
			};


			_context.Entry(employee).State = EntityState.Modified;
			try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
		//public async Task<IActionResult> PutEmployee(int id, Employee employee)
		//{
		//    if (id != employee.Id)
		//    {
		//        return BadRequest();
		//    }
		//    employee.Id = id;

		//    _context.Entry(employee).State = EntityState.Modified;

		//    try
		//    {
		//        await _context.SaveChangesAsync();
		//    }
		//    catch (DbUpdateConcurrencyException)
		//    {
		//        if (!EmployeeExists(id))
		//        {
		//            return NotFound();
		//        }
		//        else
		//        {
		//            throw;
		//        }
		//    }

		//    return NoContent();
		//}

		// POST: api/Employees
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeRequestVM employeeRequestVM)
        {
            if (employeeRequestVM == null)
            {
                return BadRequest();
            }

            var department = _context.Departments.FirstOrDefault(e => e.Id == employeeRequestVM.DepartmentId);

            if (department == null)
            {
                return BadRequest("no department with this id");
            }

            var employee = new Employee()
            {
                DepartmentId = employeeRequestVM.DepartmentId,
                FirstName = employeeRequestVM.FirstName,
                LastName = employeeRequestVM.LastName,
                Salary = employeeRequestVM.Salary,
                Email = employeeRequestVM.Email,
                Password = employeeRequestVM.Password,
                StartDate = employeeRequestVM.StartDate,
                Gender = employeeRequestVM.Gender,
                Notes = employeeRequestVM.Notes,
                SocialStatus = employeeRequestVM.SocialStatus
            };


            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var employeeResponse = new EmployeeResponseVM()
            {
                departmentName = department.Name,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Id = employee.Id,
                Salary = employee.Salary,
                StartDate = employee.StartDate
                
            };
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employeeResponse);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        //[HttpGet("/GetImageUrl")]
        //public async Task<IActionResult> GetImage(int empId)
        //{

        //}
    }
}
