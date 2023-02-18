using InnovationTask.Core.CustomDataAnnotation;
using System.ComponentModel.DataAnnotations;

namespace InnovationTask.Core.Model
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [ValidateFixedValues("Received", "Completed", "Cancelled")]
        public string OrderStatus { get; set; }
        [Required]
        [ValidateFixedValues("Shipped","not-Shipped")]
        public string ShippingStatus { get; set; }
    }
}
