using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savings_Tracker.Model
{
    //make it public so you can access it 
    public class Goal
    {
        public string Name { get; set; }
        public decimal SavingGoal { get; set; }
        public string Notes { get; set; }
    }
}
