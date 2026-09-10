using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveRoom.ViewModels;

namespace ReserveRoom.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        { 
            //return value of the field
            get => _currentViewModel;
            //set the current view model to value that get passed in
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }

        }
        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }



    }
}
