using System.ComponentModel.DataAnnotations;

namespace DNCP5_ModelBinding.Models
{
    public class Invoice_price_validation : ValidationAttribute
    {
        public override ValidationResult? IsValid(object? value, ValidationContext vContext)
        {
            int val = Convert.ToInt32(value);

            if (value != null)
            {
                return new ValidationResult("");
                
                if (val == 2000)
                {
                    return ValidationResult.Success;
                }
                else
                {

                }
            }
            
            return null;
        }
    }
}
