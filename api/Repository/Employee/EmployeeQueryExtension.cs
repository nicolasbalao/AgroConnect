using api.Model;
using api.utils;
namespace api.Repository.employee.EmployeeQueryExtension;
public static class EmployeeQueryExtension
{
    public static IQueryable<Employee> ApplyFilters(this IQueryable<Employee> query, EmployeeFilters filters)
    {
        if (filters.DepartmentId.HasValue)
            query = query.Where(e => e.DepartmentId == filters.DepartmentId);
        if (filters.SiteId.HasValue)
            query = query.Where(e => e.SiteId == filters.SiteId);
        return query;
    }
    public static IQueryable<Employee> ApplyPagination(this IQueryable<Employee> query, PaginationParams paginationParams)
    {
        return query.Skip(paginationParams.GetOffset()).Take(paginationParams.GetLimit());
    }

    public static IQueryable<Employee> ApplySearch(this IQueryable<Employee> query, string search)
    {
        return query.Where(e => e.Firstname.Contains(search) || e.Lastname.Contains(search) || e.Department.Name.Contains(search) || e.Site.City.Contains(search));
    }
}


