using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.DTOs
{
    public class CheckoutDTO
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Shipping Address is required.")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a payment method.")]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}