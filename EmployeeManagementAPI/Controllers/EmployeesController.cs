using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    // GET: api/Employees
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var employees = await _employeeService.GetAllAsync(cancellationToken);

        return Ok(employees);
    }

    // GET: api/Employees/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var employee = await _employeeService.GetByIdAsync(id, cancellationToken);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    // POST: api/Employees
    [HttpPost]
    public async Task<IActionResult> Create(Employee employee, CancellationToken cancellationToken)
    {
        var createdEmployee = await _employeeService.CreateAsync(employee, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdEmployee.Id },
            createdEmployee
        );
    }

    // PUT: api/Employees/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Employee employee, CancellationToken cancellationToken)
    {
        var result = await _employeeService.UpdateAsync(id, employee, cancellationToken);

        if (!result)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/Employees/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await _employeeService.DeleteAsync(id, cancellationToken);

        if (!result)
            return NotFound();

        return NoContent();
    }
}