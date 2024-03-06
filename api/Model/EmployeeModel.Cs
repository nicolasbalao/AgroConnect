
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model;

public class Employee : BaseModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string HomePhone { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string CellPhone { get; set; }

    public string Email { get; set; }

    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }

    public virtual Service Service { get; set; }

    [ForeignKey(nameof(Site))]
    public int SiteId { get; set; }
    public virtual Site Site { get; set; }

}