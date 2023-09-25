namespace VendingMachine.API.Models
{
    public class ItemTypeDto
    {
        public Guid Id { get; set; }
        public int ItemTypeCode { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
