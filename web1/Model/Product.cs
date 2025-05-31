using System.ComponentModel.DataAnnotations;

namespace Web1.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 100 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        public required string Category { get; set; }

        //[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(20, ErrorMessage = "Unit cannot exceed 20 characters.")]
        public required string Unit { get; set; } // e.g., "kg", "unit", "liter"

        [Range(0, int.MaxValue, ErrorMessage = "Available quantity cannot be negative.")]
        public int AvailableQuantity { get; set; }
    }
}
