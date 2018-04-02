using Savings_Tracker.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Savings_Tracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailGoalPage : Page
    {
        DetailGoalViewModel _detailGoalViewModel;
        public DetailGoalPage()
        {
            this.InitializeComponent();
            Loaded += DetailGoalPage_Loaded;
        }

        private void DetailGoalPage_Loaded(object sender, RoutedEventArgs e)
        {
            //this checks if you can go back or not
            var rootFrame = Window.Current.Content as Frame;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                 rootFrame.CanGoBack ?
                 AppViewBackButtonVisibility.Visible :
                 AppViewBackButtonVisibility.Collapsed;

            //event handler for it
            SystemNavigationManager.GetForCurrentView().BackRequested += DetailGoalPage_BackRequested;
        }

        private void DetailGoalPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                e.Handled= true;
                rootFrame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var Id = (int)e.Parameter;
           if(_detailGoalViewModel == null)
            {
                _detailGoalViewModel = new DetailGoalViewModel(Id);
            }

            DataContext = _detailGoalViewModel.CurrentGoal;
        }
    }
}
