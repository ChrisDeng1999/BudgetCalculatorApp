using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetCalculator.Models
{
    public class BudgetItems
    {
        public int BudgetItemsId { get; set; }

        public string ItemName { get; set; }

        public int ItemPrice { get; set; }

        // Foreign key 
        [Display(Name = "Budget")]
        public int BudgetId { get; set; }

        [ForeignKey("BudgetId")]
        public virtual Budget Budgets { get; set; }

        public BudgetItems()
        {

        }
    }
}



