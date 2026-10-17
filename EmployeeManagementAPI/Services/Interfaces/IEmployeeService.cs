using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services.Interfaces;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken);

    Task<Employee?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken
    );

    Task<Employee> CreateAsync(
        CreateEmployeeDto employeeDto,
        CancellationToken cancellationToken
    );

    Task<bool> UpdateAsync(
        int id,
        UpdateEmployeeDto employeeDto,
        CancellationToken cancellationToken
    );

    Task<bool> DeleteAsync(
        int id,
        CancellationToken cancellationToken
    );
}