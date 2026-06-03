using System.ComponentModel.DataAnnotations;

namespace Ahmed_Task_2.Web.CustomAttributes
{
    public class DecimalPrecisionAttribute : ValidationAttribute
    {
        private readonly int _precision;

        public DecimalPrecisionAttribute(int precision)
        {
            _precision = precision;
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is decimal decimalValue)
            {
                int[] bits = decimal.GetBits(decimalValue);
                int scale = (bits[3] >> 16) & 31;

                if (scale > _precision)
                {
                    return new ValidationResult(
                        $"Maximum {_precision} decimal places allowed.");
                }
            }

            return ValidationResult.Success;
        }
    }
}