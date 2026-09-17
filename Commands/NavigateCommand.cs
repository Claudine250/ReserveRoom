using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveRoom.Stores;
using ReserveRoom.ViewModels;
using ReserveRoom.Models;
using ReserveRoom.Services;

namespace ReserveRoom.Commands
{
    public class NavigateCommand : CommandBase
    {
        //store shared navigation tracker
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        //build new viewmodel or screen to show
        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
