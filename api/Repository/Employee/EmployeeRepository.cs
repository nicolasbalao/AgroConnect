using api.Employee.Model;
using api.Employee.Repository.Extension;
using api.Infrastructure.Database;
using api.utils;
using Microsoft.EntityFrameworkCore;

namespace api.Employee.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationContext _context;

    public EmployeeRepository(ApplicationContext context)
    {
        _context = context;
    }

    #region GetEmployees
    public async Task<(List<EmployeeModel>, int)> GetEmployees(PaginationParams paginationParams, string? search, EmployeeFilters? filters)
    {
        var query = GetEmployeeQuery();

        if (filters is not null)
            query = query.ApplyFilters(filters);

        if (search is not null)
        {
            query = query.ApplySearch(search);
        }

        var totalItems = await query.CountAsync();
        var employees = await query.ApplyPagination(paginationParams).ToListAsync();



        return (employees, totalItems);
    }


    private IQueryable<EmployeeModel> GetEmployeeQuery()
    {
        return _context.Employees.Include(e => e.Department)
            .Include(e => e.Site).AsQueryable();
    }

    #endregion


    public async Task<EmployeeModel> CreateEmployee(EmployeeModel employee)
    {
        var createdEmploye = await _context.Employees.AddAsync(employee);
        LoadReferences(createdEmploye.Entity);
        await _context.SaveChangesAsync();
        return createdEmploye.Entity;
    }
    public async Task<EmployeeModel> UpdateEmployee(EmployeeModel employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        LoadReferences(employee);
        return employee;
    }

    private void LoadReferences(EmployeeModel employee)
    {
        _context.Entry(employee).Reference(e => e.Department).Load();
        _context.Entry(employee).Reference(e => e.Site).Load();
    }

    public async Task<EmployeeModel?> GetEmployee(int id)
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

    public async Task LockEmployeeForModification(EmployeeModel employee, string lockedBy)
    {
        employee.IsLocked = true;
        employee.LockedBy = lockedBy;
        employee.LockedAt = DateTime.Now;
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
        employee.LockedAt = null;
        await _context.SaveChangesAsync();

    }

    public async Task<string> GetLockedBy(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        return employee!.LockedBy!;
    }

    public void Detach(EmployeeModel employee)
    {
        _context.Entry(employee).State = EntityState.Detached;
    }


}