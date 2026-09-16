using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveRoom.Stores;
using ReserveRoom.ViewModels;
using ReserveRoom.Models;

namespace ReserveRoom.Commands
{
    public class NavigateCommand : CommandBase
    {
        //store shared navigation tracker
        private readonly NavigationStore _navigationStore;
        //saved ref to the method that build screen whatever screen this command should navigate to
        private readonly Func<ViewModelBase> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        //build new viewmodel or screen to show
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
