using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _context.Employees
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Employee?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public async Task<Employee> CreateAsync(
        CreateEmployeeDto employeeDto,
        CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            FullName = employeeDto.FullName,
            Email = employeeDto.Email,
            Department = employeeDto.Department,
            Salary = employeeDto.Salary,
            HireDate = employeeDto.HireDate
        };

        await _context.Employees.AddAsync(employee, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return employee;
    }

    public async Task<bool> UpdateAsync(
        int id,
        UpdateEmployeeDto employeeDto,
        CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (employee == null)
            return false;

        employee.FullName = employeeDto.FullName;
        employee.Email = employeeDto.Email;
        employee.Department = employeeDto.Department;
        employee.Salary = employeeDto.Salary;
        employee.HireDate = employeeDto.HireDate;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        if (employee == null)
            return false;

        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}