using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseManagement.Models
{
    public class CartItem
    {
        public FoodItem FoodItem { get; set; }
        public int Quantity { get; set; }
    }
}
