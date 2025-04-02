namespace LeadManagementAPI.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal PriceToPay { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Lead(string firstName, string fullName, string phoneNumber, string email, string suburb, string category, string description)
        {
            FirstName = firstName;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Suburb = suburb;
            Category = category;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            Status = "Invited";
        }
    }
}
