using Savings_Tracker.DataContext;
using Savings_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savings_Tracker.ViewModel
{
    public class DetailGoalViewModel
    {
        private int goalId;

        public Goal CurrentGoal
        {
            get {
                var goal =  DataContextHelper.GetItem<Goal>(goalId);
                goal.Transactions = DataContextHelper.GetTransactionByGoalId(goal.GoalId);
                return goal;
            }            
        }

        public DetailGoalViewModel(int Id)
        {
            goalId = Id;
        }
    }
}
