using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FranchiseManagement.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionTime { get; set; }
        [Column(TypeName = "decimal(15,4)")]
        public decimal PriceTotal { get; set; }
        [Column(TypeName = "decimal(15,4)")]
        public decimal Tax { get; set; }
        public int LocationID { get; set; }
        public int FoodTruckID { get; set; }

        public ICollection<FoodItem> TransactionItems { get; set; }
    }
}
