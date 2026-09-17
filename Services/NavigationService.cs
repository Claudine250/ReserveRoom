using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveRoom.Stores;
using ReserveRoom.ViewModels;

namespace ReserveRoom.Services
{
    public class NavigationService
    {
        //store shared navigation tracker
        private readonly NavigationStore _navigationStore;
        //saved ref to the method that build screen whatever screen this command should navigate to
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
