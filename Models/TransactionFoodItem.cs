using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseManagement.Models
{
    public class TransactionFoodItem
    {
        public int TransactionFoodItemID { get; set; }
        public int TransactionID { get; set; }
        public int FoodItemID { get; set; }
        public int FoodItemQuantity { get; set; }
    }
}
