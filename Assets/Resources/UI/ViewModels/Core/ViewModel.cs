using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace REDBlend.Assets.UI.ViewModels.Core
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ViewModelValue : ViewModel
    {
        protected object value;

        public object Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value.Equals(this.value))
                    return;

                this.value = value;
                this.RaisePropertyChanged("Value");
            }
        }
    }

    public class ViewModel<TValue> : ViewModelValue
        where TValue : class
    {
        public new TValue Value
        {
            get
            {
                return this.value as TValue;
            }
            set
            {
                if (value.Equals(this.value))
                    return;

                this.value = value;
                this.RaisePropertyChanged("Value");
            }
        }
    }
}
