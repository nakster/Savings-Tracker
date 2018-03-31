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
        private ObservableCollection<Goal> _goalList;
        public ObservableCollection<Goal> GoalList
        {
            get { return _goalList; }
            set
            {
                _goalList = value;
                NotifyPropertyChanged("GoalList");
            }
        }

        public MainPageViewModel()
        {
            _goalList = new ObservableCollection<Goal>();
        }

        public void AddNewGoal(Goal newGoal)
        {
            //add item to our goal list
            GoalList.Add(newGoal);
        }
    }
}
