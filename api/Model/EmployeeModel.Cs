
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model;

public class Employee : BaseModel
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;

    [Column(TypeName = "varchar(20)")]
    public string? HomePhone { get; set; } = string.Empty;

    [Column(TypeName = "varchar(20)")]
    public string CellPhone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsLocked { get; set; } = false;

    public string? LockedBy { get; set; }

    public DateTime? LockedAt { get; set; }

    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    [ForeignKey(nameof(Site))]
    public int SiteId { get; set; }
    public virtual Site? Site { get; set; }

}