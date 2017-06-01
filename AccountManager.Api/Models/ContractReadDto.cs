using System;

namespace AccountManager.Api.Models
{
    public class ContractReadDto
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
