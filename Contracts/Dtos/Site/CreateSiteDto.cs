using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos
{
    public class CreateSiteDto
    {
        [Required]
        public string City { get; set; } = String.Empty;
    }
}