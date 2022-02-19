using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetExam.Models
{
    public class Product
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please Enter Product Rate")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Please Enter Product Description")]
        public string Description { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please Enter Product Category Name")]
        public string CategoryName { get; set; }
    }
}