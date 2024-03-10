using api.database;
using api.Decorators;
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

    public async Task<List<Employee>> GetEmployees(PaginationParams paginationParams)
    {
        return await _context.Employees.Include(e => e.Department)
            .Include(e => e.Site)
            .Skip(paginationParams.GetOffset())
            .Take(paginationParams.GetLimit())
            .ToListAsync();
    }

    public async Task<List<Employee>> GetEmployees(PaginationParams paginationParams, string search)
    {
        return await _context.Employees.Include(e => e.Department)
            .Include(e => e.Site)
            .Include(e => e.Department)
            .Where(e => e.Firstname.Contains(search) || e.Lastname.Contains(search) || e.Department.Name.Contains(search) || e.Site.City.Contains(search))
            .Skip(paginationParams.GetOffset())
            .Take(paginationParams.GetLimit())
            .ToListAsync();

    }
    public async Task<Employee> CreateEmployee(Employee employee)
    {
        var createdEmploye = await _context.Employees.AddAsync(employee);
        LoadReferences(createdEmploye.Entity);
        await _context.SaveChangesAsync();
        return createdEmploye.Entity;
    }
    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        LoadReferences(employee);
        return employee;
    }

    private void LoadReferences(Employee employee)
    {
        _context.Entry(employee).Reference(e => e.Department).Load();
        _context.Entry(employee).Reference(e => e.Site).Load();
    }

    public async Task<Employee?> GetEmployee(int id)
    {
        return await _context.Employees.Include(e => e.Department).Include(e => e.Site).FirstAsync(e => e.Id == id);
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

    public async Task<int> EmployeeCount()
    {
        return await _context.Employees.CountAsync();
    }

    public async Task LockEmployeeForModification(Employee employee, string lockedBy)
    {
        employee.IsLocked = true;
        employee.LockedBy = lockedBy;
        await _context.SaveChangesAsync();
    }
    public async Task<bool> IsEmployeeLockedByAnotherAdmin(int id, string lockedBy)
    {
        var employee = await _context.Employees.FindAsync(id);
        Detach(employee!);
        return employee!.IsLocked && employee.LockedBy != lockedBy;
    }

    public async Task UnlockEmployeeForModification(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        employee!.IsLocked = false;
        employee.LockedBy = null;
        await _context.SaveChangesAsync();

    }

    public async Task<string> GetLockedBy(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        return employee!.LockedBy!;
    }

    public void Detach(Employee employee)
    {
        _context.Entry(employee).State = EntityState.Detached;
    }


}