using System.ComponentModel.DataAnnotations;
namespace Task1.Models.DAL.Entities
{
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
	[Required]
        public String? OrderDiscription{ get; set; }
        public int OrderPrice { get; set; }
    }
}
