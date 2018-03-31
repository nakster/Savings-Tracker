using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savings_Tracker.ViewModel
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String PropertyName)
        {
            //PropertyChangedEventHandler handler = Propertychanged;
            //if(null != handler)
            //{
            //    handler(this, new PropertyChangedEventArgs(PropertyName));
            //}
            //or this way
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        }
    }
}
