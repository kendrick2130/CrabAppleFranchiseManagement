using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseManagement.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int FoodTruckID { get; set; }

        public ICollection<FoodItem> OrderItems { get; set; }
        

    }
}
