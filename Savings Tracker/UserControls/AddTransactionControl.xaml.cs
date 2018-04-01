using Savings_Tracker.DataContext;
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
    public sealed partial class AddTransactionControl : UserControl
    {
        private int _goalid;

        public AddTransactionControl()
        {
            this.InitializeComponent();
        }

        private void SetGoalId(int id)
        {
            _goalid = id;

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var NewTransaction = new Transaction();
            NewTransaction.Date = DateTime.Now;
            NewTransaction.Amount = Convert.ToInt32(AmountTextBox.Text);
            NewTransaction.GoalId = _goalid;

            DataContextHelper.AddRecord<Transaction>(NewTransaction);
            ClearFields();
            HideControl();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();

        }

        private void ClearFields()
        {
            AmountTextBox.Text = string.Empty;
        }

        private void HideControl()
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
