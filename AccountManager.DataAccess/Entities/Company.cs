namespace AccountManager.DataAccess.Entities
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string Identifier { get; set; }
        public bool IsActive { get; set; }
    }
}
