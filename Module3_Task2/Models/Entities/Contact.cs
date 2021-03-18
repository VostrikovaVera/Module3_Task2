namespace Module3_Task2.Models.Entities
{
    public class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string PhoneNumber { get; set; }
    }
}