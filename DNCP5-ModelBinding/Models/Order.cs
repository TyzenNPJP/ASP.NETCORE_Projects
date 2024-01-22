using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

using DNCP5_ModelBinding.Models;
using DNCP5_ModelBinding.CustomValidators;

namespace DNCP5_ModelBinding.Models
{
    public class Order
    {
        public int? order_num { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [DateValidator("2000-01-01", ErrorMessage = "Order Date should be greater than or equal to 2000")] //custom validator
        public DateTime order_date { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [InvoicePriceValidator] //custom validator
        [Range(1, 10000, ErrorMessage = "{0} should be between 1 and 10000")]
        public double invoice_price { get; set; }

        [ProductsListValidator] //custom validator
        public List<Product> products { get; set; } = new List<Product>();

        public Order()
        {
            //generate a random order number between 1 and 99999
            Random random = new Random();
            int order_num = random.Next(1, 99999);
        }
    }
}
