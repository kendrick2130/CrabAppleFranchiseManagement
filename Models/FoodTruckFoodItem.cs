using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseManagement.Models
{
    public class FoodTruckFoodItem
    {
        public int FoodTruckFoodItemID { get; set; }
        public int FoodTruckID { get; set; }
        public int FoodItemID { get; set; }
        public int FoodItemQuantity { get; set; }
    }
}
