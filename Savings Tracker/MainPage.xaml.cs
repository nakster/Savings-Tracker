using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Savings_Tracker.Model;
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
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //when we click goalcontrol which is the add button it fires the onGoalsaved event 
            //which inturn starts a new method
            goalControl.OnGoalSaved += GoalControl_OnGoalSaved;

        }

        private void GoalControl_OnGoalSaved(object sender, Model.Goal e)
        {
           
        }

        //this method makes the addgoalcontrol page visible 
        private void AppBarAddButton_Click(object sender, RoutedEventArgs e)
        {
            goalControl.Visibility = Visibility.Visible;
        }
    }
}
