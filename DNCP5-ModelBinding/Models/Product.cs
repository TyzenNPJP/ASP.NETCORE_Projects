using System.ComponentModel.DataAnnotations;

namespace DNCP5_ModelBinding.Models
{
    // Product class
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, 10000, ErrorMessage = "{0} should be between a 1 and 10000")]
        public int pid { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, 500, ErrorMessage = "{0} should be between a 1 and 500")]
        public double price { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, 10, ErrorMessage = "{0} should be between a valid number")]
        public int qty { get; set; }
    }
}
