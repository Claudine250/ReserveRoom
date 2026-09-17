using System.Configuration;
using System.Data;
using System.Diagnostics.Tracing;
using System.Windows;
using ReserveRoom.Exceptions;
using ReserveRoom.Models;
using ReserveRoom.Services;
using ReserveRoom.Stores;
using ReserveRoom.ViewModels;

namespace ReserveRoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //hotel to be used in all of our application
        private readonly Hotel _hotel;
        //keep which viewmodel is currently shown
        private readonly NavigationStore _navigationStore;

        //run when application is started
        public App()
        {
            _hotel = new Hotel("Coco's Boutique");
            _navigationStore = new NavigationStore();
        }
        //runs once application is launched
        protected override void OnStartup(StartupEventArgs e)

        {
            //tells navigation store which screen to show first
            _navigationStore.CurrentViewModel = CreateMakeReservationViewModel();
            //create main window an connects it to the mainViewModel
            MainWindow = new MainWindow()
            {
                DataContext = new ViewModels.MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        //build the make reservation screen
        private MakeReservationViewModel CreateMakeReservationViewModel()
        {

            //pass hotel, nav store, and a way to get to viewmodel
            return new MakeReservationViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel() { 
            return new ReservationListingViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }

}
