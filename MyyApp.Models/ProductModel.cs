using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyyApp.Models
{
    public class ProductModel
    {
        [Display(Name ="Category Name")]
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductDate { get; set; }
        public  List<Category> categories { get; set; }
        
    }
}
