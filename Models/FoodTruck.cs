using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FranchiseManagement.Models
{
    public class FoodTruck
    {
        public int FoodTruckID { get; set; }
        public string Name { get; set; }

        public int LocationID { get; set; }
        public Location Location { get; set; }
        
        public ICollection<FoodItem> Menu { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
