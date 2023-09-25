namespace VendingMachine.API.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public int ItemCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
