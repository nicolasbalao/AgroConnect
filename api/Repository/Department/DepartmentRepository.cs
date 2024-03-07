using api.database;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationContext _context;

    public DepartmentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task<List<Department>> GetDepartment()
    {
        return _context.Departments.ToListAsync();
    }



    public async Task<Department> CreateDepartment(Department department)
    {
        var departmentCreated = await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return departmentCreated.Entity;
    }

    public async Task<Department?> GetDepartment(int id)
    {
        return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Department> UpdateDepartment(Department department)
    {
        var updatedDepartment = _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return updatedDepartment.Entity;
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        if (department == null)
        {
            return false;
        }
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DepartmentHaveEmployees(int id)
    {
        return await _context.Employees.AnyAsync(x => x.DepartmentId == id);
    }

    public async Task<bool> DepartmentExists(int id)
    {
        return await _context.Departments.AnyAsync(x => x.Id == id);
    }
}