using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.DTOs
{
    public class CheckoutDTO
    {
        [Required(ErrorMessage = "Customer Name is required.")]
        public string CustomerName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }

       
        public string? CustomerEmail
        {
            get => Email;
            set => Email = value;
        }

        [Required(ErrorMessage = "Shipping address is required.")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Payment method is required.")]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}