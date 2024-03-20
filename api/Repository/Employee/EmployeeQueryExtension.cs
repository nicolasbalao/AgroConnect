using api.Employee.Model;
using api.utils;
namespace api.Employee.Repository.Extension;
public static class EmployeeQueryExtension
{
    public static IQueryable<EmployeeModel> ApplyFilters(this IQueryable<EmployeeModel> query, EmployeeFilters filters)
    {
        if (filters.DepartmentId.HasValue)
            query = query.Where(e => e.DepartmentId == filters.DepartmentId);
        if (filters.SiteId.HasValue)
            query = query.Where(e => e.SiteId == filters.SiteId);
        return query;
    }
    public static IQueryable<EmployeeModel> ApplyPagination(this IQueryable<EmployeeModel> query, PaginationParams paginationParams)
    {
        return query.Skip(paginationParams.GetOffset()).Take(paginationParams.GetLimit());
    }

    public static IQueryable<EmployeeModel> ApplySearch(this IQueryable<EmployeeModel> query, string search)
    {
        return query.Where(e => e.Firstname.Contains(search) || e.Lastname.Contains(search) || e.Department.Name.Contains(search) || e.Site.City.Contains(search));
    }
}


