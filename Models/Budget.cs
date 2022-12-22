using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetCalculator.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        public int StartingBalance { get; set; }

        public int RemainingBalance { get; set; }

        public string User { get; set; }

        public Budget()
        {


        }

    }
}
