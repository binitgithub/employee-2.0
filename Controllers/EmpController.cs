using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_2._0.Models;
using employee_2._0.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace employee_2._0.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmpController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmp()
        {
            var GetEmpModel = await employeeRepository.GetAllEmployeeAsync();
            if (GetEmpModel == null)
            {
                return NotFound();
            }

            return Ok(GetEmpModel);
        }

        [HttpGet ("{id:int}")]
        public async Task<IActionResult> GetEmpById([FromRoute] int id)
        {
            var GetByIdModel = await employeeRepository.GetEmployeeByIdAsync(id);
            if (GetByIdModel == null)
            {
                return NotFound();
            }
            return Ok(GetByIdModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmp([FromBody] Employee employee)
        {
            var CreateEmpModel = await employeeRepository.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmpById), new {id = CreateEmpModel.Id }, CreateEmpModel);
        }

       [HttpPut ("{id:int}")]
       public async Task<IActionResult> UpdateEmp([FromBody] Employee employee, [FromRoute] int id)
       {
        var UpdateEmpModel = await employeeRepository.UpdateEmployeeAsync(id, employee);
        if (UpdateEmpModel == null)
        {
            return NotFound();
        }
        return Ok(UpdateEmpModel);
       }

       [HttpDelete ("{id:int}")]
       public async Task<IActionResult> DeleteEmp([FromRoute] int id)
       {
        var DelEmpModel = await employeeRepository.DeleteEmployeeAsync(id);
        if (DelEmpModel == null)
        {
            return NotFound();
        }
        return Ok(DelEmpModel);
       }
    }
}