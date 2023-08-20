using System.ComponentModel.DataAnnotations;

namespace DNCP5_ModelBinding.Models
{
    // Product class
    public class Product : ValidationAttribute
    {
        // Required properties
        // Range validation
        [Required]
        public int pid { get; set; }

        [Required]
        [Range(0.1, 500, ErrorMessage="Price must be between 0.1$ and 500$")]
        public double price { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage="Must order at least 1qty and below 50qty")]
        public int qty { get; set; }
    }
}
