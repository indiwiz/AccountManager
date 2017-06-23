using System;
using System.ComponentModel.DataAnnotations;

namespace AccountManager.Api.Models
{
    public abstract class ContractManipulationDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}
