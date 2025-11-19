using Domain.CustomEnums;

namespace Domain.Models
{
    public class Car
    {
        public int Id { get; set; }
        public required string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public CarStateEnum State { get; set; }

        public Brand Brand { get; set; } = null!;
        public ICollection<CarOption> Options = [];
    }
}
