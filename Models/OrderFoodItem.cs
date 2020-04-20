using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseManagement.Models
{
    public class OrderFoodItem
    {
        public int OrderFoodItemID { get; set; }
        public int OrderID { get; set; }
        public int FoodItemID { get; set; }
        public int FoodItemQuantity { get; set; }
    }
}
