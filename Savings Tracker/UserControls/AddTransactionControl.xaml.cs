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

        private readonly DependencyProperty GoalIdProperty = DependencyProperty.Register("GoalId", typeof(int), typeof(AddTransactionControl), null);

        public event EventHandler TransactionSavedFinished;
        private void FireTransactionSavedFinished()
        {
            if(TransactionSavedFinished != null)
            {
                TransactionSavedFinished(null, null);
            }
        }


        public AddTransactionControl()
        {
            this.InitializeComponent();
        }


        private async void ConfirmButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            var NewTransaction = new Transaction();
            NewTransaction.Date = DateTime.Now;
            NewTransaction.Amount = Convert.ToDecimal(AmountTextBox.Text);
            NewTransaction.GoalId = GoalId;

            await DataContextHelper.AddRecord<Transaction>(NewTransaction);
            //fire this event 
            FireTransactionSavedFinished();
            ClearFields();
            HideControl();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
           
            ClearFields();
            HideControl();
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
