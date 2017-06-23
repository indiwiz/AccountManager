using System;
using System.ComponentModel.DataAnnotations;

namespace AccountManager.Api.Models
{
    public class ContractUpdateDto : ContractManipulationDto
    {
        [Required]
        public override DateTime? EndDate { get => base.EndDate; set => base.EndDate = value; }
    }
}
