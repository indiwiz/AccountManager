using System;

namespace AccountManager.DataAccess.Entities
{
    public class Contract : EntityBase
    {
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
