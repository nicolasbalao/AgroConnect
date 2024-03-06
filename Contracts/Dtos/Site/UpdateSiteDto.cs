using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos
{
    public class UpdateSiteDto : CreateSiteDto
    {
        [Required]
        public int Id { get; set; }
    }
}