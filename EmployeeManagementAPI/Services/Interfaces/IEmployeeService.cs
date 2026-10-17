using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services.Interfaces;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken);

    Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<Employee> CreateAsync(Employee employee, CancellationToken cancellationToken);

    Task<bool> UpdateAsync(int id, Employee employee, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}