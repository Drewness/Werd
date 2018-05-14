namespace Backend.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + ", " + FirstName;
    }
}