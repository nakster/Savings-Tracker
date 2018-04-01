using Savings_Tracker.Enums;
using Savings_Tracker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Savings_Tracker.UserControls
{
    public sealed partial class AddGoalControl : UserControl
    {
        public event EventHandler<Goal> OnGoalSaved;


        private readonly DependencyProperty GoalIdProperty = DependencyProperty.Register("GoalId", typeof(int), typeof(AddGoalControl), null);
        public int GoalId
        {
            get
            {
                return (int)GetValue(GoalIdProperty);
            }
            set
            {
                SetValue(GoalIdProperty, value);
            }
        }

        /////
        private readonly DependencyProperty ActionProperty = DependencyProperty.Register("Action", typeof(GoalAction), typeof(AddGoalControl), null);
        public GoalAction Action
        {
            get
            {
                return (GoalAction)GetValue(ActionProperty);
            }
            set
            {
                SetValue(ActionProperty, value);
            }
        }


        public AddGoalControl()
        {
            this.InitializeComponent();
        }

        //this method here when clicked will return to the home page 
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            //create a new goal
            var newGoal = new Goal();
            newGoal.Name = GoalNameTextBox.Text;
            newGoal.SavingGoal = Convert.ToInt32(savingAmountTextBox.Text);
            newGoal.Notes = notesTextBox.Text;
            newGoal.Date = DateTime.Now;
            newGoal.Balance = 0;

            //fire our on goal save event
            fireOneGoalSaved(newGoal);

            cleartextBoxes();
            Visibility = Visibility.Collapsed;
        }
        //this here will cancel and clear the boxes and return to the homepage
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
            cleartextBoxes();

        }
        // this here clears all the boxes
        private void cleartextBoxes()
        {
            GoalNameTextBox.Text = string.Empty;
            savingAmountTextBox.Text = string.Empty;
            notesTextBox.Text = string.Empty;
        }

        private void fireOneGoalSaved(Goal newGoal)
        {
            OnGoalSaved?.Invoke(null, newGoal);
        }
    }
}
