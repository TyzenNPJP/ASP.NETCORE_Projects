using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using DNCP5_ModelBinding.Models;

namespace DNCP5_ModelBinding.Models
{
    public class Order : ValidationAttribute
    {
        public static bool is_transaction_valid = false;
        public static double temp_invoice_price;
        public static int temp_random;

        [Required]
        [Range(100,1000, ErrorMessage="Order number must be between 100 and 1000")]
        [Order()]
        public int order_num { get; set; }

        [Required]
        [Range(0.1, 1000, ErrorMessage="Must purchase at least 1 product and purchase must be less than 1000$\nOr Invoice price does not match with total cost.")]
        public double invoice_price { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage="Must be a valid datetime with date and time")]
        public DateTime date { get; set; }

        [Required]
        public List<Product>? product_List{ get; set; }

        // Constructor
        public Order()
        {
            Order order = new Order();

            var rand = new Random();
            order.order_num = rand.Next(0, 100000);

            temp_random = order.order_num;
            temp_invoice_price = 0;
            //this.invoice_price = 0;

            if (order.product_List == null)
            {
                temp_invoice_price = 1;
            }

            if (order.product_List != null)
            {
                foreach (Product product_item in order.product_List)
                {
                    temp_invoice_price += product_item.price * product_item.qty;
                }
            }

            if (invoice_price == temp_invoice_price)
            {
                is_transaction_valid = true;
            }
        }
    }
}
