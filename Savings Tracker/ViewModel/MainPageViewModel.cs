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
        public List<Goal> GoalList
        {
            get { return DataContextHelper.GetTable<Goal>(); }
          
        }

        public MainPageViewModel()
        {
            _goalList = new ObservableCollection<Goal>();
        }

        public void AddNewGoal(Goal newGoal)
        {
            //add item to our goal list
            DataContextHelper.AddRecord<Goal>(newGoal);
        }
    }
}
