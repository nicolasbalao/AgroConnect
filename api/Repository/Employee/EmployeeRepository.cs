using api.database;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationContext _context;

    public EmployeeRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await _context.Employees.Include(e => e.Department).Include(e => e.Site).ToListAsync();
    }
    public async Task<Employee> CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }
    public async Task<Employee?> GetEmployee(int id)
    {
        return await _context.Employees.Include(e => e.Department).Include(e => e.Site).FirstAsync(e => e.Id == id);
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee is null)
            return false;

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return true;
    }


}