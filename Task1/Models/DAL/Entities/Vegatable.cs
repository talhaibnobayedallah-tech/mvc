namespace Task1.Models.DAL.Entities
{
    public class Vegetable
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
