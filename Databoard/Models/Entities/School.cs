namespace Databoard.Models.Entities
{
    public class School
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Medium { get; set; } = string.Empty;
        public DateTime Establish { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Authorised { get; set; } = string.Empty;
    }
}
