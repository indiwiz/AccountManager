using System.ComponentModel.DataAnnotations;

namespace AccountManager.Api.Models
{
    public class CompanyCreateDto
    {
        [Required]        
        public string Name { get; set; }
        [Required]
        [MaxLength(8)]
        public string CompanyRegistrationNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public string Identifier { get; set; }
    }
}
