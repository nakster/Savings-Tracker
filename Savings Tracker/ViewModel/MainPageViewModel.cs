using Savings_Tracker.DataContext;
using Savings_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savings_Tracker.ViewModel
{
    public class MainPageViewModel: BaseViewModel
    {
        //this controls the visability of the addtransaction page 
        private bool _showTransactionControl = false;
        public bool ShowTransactionControl
        {
            get { return _showTransactionControl; }
            set
            {
                _showTransactionControl = value;
                NotifyPropertyChanged("ShowTransactionControl");
            }
        }

        public List<Goal> GoalList
        {
            //gets all the records from the datacontexthelper page
            get { return DataContextHelper.GetTable<Goal>(); }
          
        }

        public MainPageViewModel()
        {
        }

        public void AddNewGoal(Goal newGoal)
        {
            //add item to our goal list
            DataContextHelper.AddRecord<Goal>(newGoal);
        }
    }
}
