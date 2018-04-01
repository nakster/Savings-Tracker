﻿using Savings_Tracker.ButtonCommands;
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

        //this controls the visability of the addtransaction page 
        private bool _showGoalControl = false;
        public bool ShowGoalControl
        {
            get { return _showGoalControl; }
            set
            {
                _showGoalControl = value;
                NotifyPropertyChanged("ShowGoalControl");
            }
        }

        public List<Goal> GoalList
        {
            //gets all the records from the datacontexthelper page
            get { return DataContextHelper.GetTable<Goal>(); }
          
        }

        public ButtonCommand TransactionButtonCommand { get; set; }
        public ButtonCommand GoalButtonCommand { get; set; }

        public MainPageViewModel()
        {
            TransactionButtonCommand = new ButtonCommand(ChangeTransactionVisability);
            GoalButtonCommand = new ButtonCommand(ChangeGoalVisability);
        }

        private void ChangeGoalVisability()
        {
            ShowGoalControl = true;
        }

        public void AddNewGoal(Goal newGoal)
        {
            //add item to our goal list
            DataContextHelper.AddRecord<Goal>(newGoal);
        }

        private void ChangeTransactionVisability()
        {
            ShowTransactionControl = true;
        }
    }
}
