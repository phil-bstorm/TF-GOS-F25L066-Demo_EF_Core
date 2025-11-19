namespace Domain.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public required Client Client { get; set; }
        public required Car Car { get; set; }
    }
}
