using System;

namespace AccountManager.Api.Models
{
    public class ContractUpdateDto
    {
        public string CompanyIdentifier { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
