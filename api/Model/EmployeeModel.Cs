
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model;

public class Employee : BaseModel
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;

    [Column(TypeName = "varchar(20)")]
    public string HomePhone { get; set; } = string.Empty;

    [Column(TypeName = "varchar(20)")]
    public string? CellPhone { get; set; }

    public string Email { get; set; } = string.Empty;

    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    [ForeignKey(nameof(Site))]
    public int SiteId { get; set; }
    public virtual Site? Site { get; set; }

}