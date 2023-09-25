using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CSV
    {
        [Key]
        public string ContractId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
