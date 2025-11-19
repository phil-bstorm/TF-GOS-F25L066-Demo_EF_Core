namespace Domain.Models
{
    public class CarOption
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Car> Cars { get; set; } = [];
    }
}
