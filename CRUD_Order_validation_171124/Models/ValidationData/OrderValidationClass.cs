using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD_Order_validation_171124.Models.ValidationData
{
    public class OrderValidationClass
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Product Name required!!!")]
        public string ProductName { get; set; }
        [Required]
        [Range(0, int.MaxValue,ErrorMessage ="Order Quantity Must be +ve")]
        public Nullable<int> Quantity { get; set; }
        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Price must be Greater than 0")]
        public Nullable<int> Price { get; set; }
    }
}