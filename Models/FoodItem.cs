using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranchiseManagement.Models
{
    public class FoodItem
    {
        public int FoodItemID { get; set; }
        public string Name { get; set; }
        [Column(TypeName ="decimal(15,4)")]
        public decimal Price { get; set; }
        public string FoodItemDescription { get; set; }
    }
}
