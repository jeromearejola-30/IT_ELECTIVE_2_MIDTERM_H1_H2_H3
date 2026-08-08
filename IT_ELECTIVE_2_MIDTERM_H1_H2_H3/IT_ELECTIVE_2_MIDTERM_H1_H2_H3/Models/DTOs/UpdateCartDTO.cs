using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM_H1_H2_H3.Models.DTOs
{
    public class UpdateCartDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}