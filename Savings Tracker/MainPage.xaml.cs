using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Savings_Tracker.DataContext;
using Savings_Tracker.Model;
using Savings_Tracker.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Savings_Tracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel mainPageViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //when we click goalcontrol which is the add button it fires the onGoalsaved event 
            //which inturn starts a new method
            //OnGoalSaved is the event handler 
            goalControl.OnGoalSaved += GoalControl_OnGoalSaved;
            //TransactionControl name of the button
            TransactionControl.TransactionSavedFinished += TransactionControl_TransactionSavedFinished;
            //use this to clear all the data from sqlite 
            //DataContextHelper.DeleteAllGoals();

            if(mainPageViewModel == null)
            {
                mainPageViewModel = new MainPageViewModel();
                DataContext = mainPageViewModel;
            }
        }

        private void TransactionControl_TransactionSavedFinished(object sender, EventArgs e)
        {
            GoalListView.ItemsSource = mainPageViewModel.GoalList;
        }

        //this method is now hooked on this event handler OnGoalSaved
        private void GoalControl_OnGoalSaved(object sender, System.EventArgs e)
        {  //reset the itemsousre to the new goallist
            GoalListView.ItemsSource = mainPageViewModel.GoalList;

        }

        //this method makes the addgoalcontrol page visible 
        private void AppBarAddButton_Click(object sender, RoutedEventArgs e)
        {
            goalControl.Visibility = Visibility.Visible;
        }
    }
}
