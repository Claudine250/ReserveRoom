using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.ViewModels
{
   public class ViewModelBase : INotifyPropertyChanged
    {
        // when this event is raised, we will tell UI which bindings we're going to update
        public event PropertyChangedEventHandler PropertyChanged;

        //only inherited classes can used it
        protected void OnPropertyChanged(string propertyName) {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
