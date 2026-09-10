using System.Configuration;
using System.Data;
using System.Windows;
using ReserveRoom.Exceptions;
using ReserveRoom.Models;
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
        private readonly NavigationStore _navigationStore;


        public App()
        {
            _hotel = new Hotel("Coco's Boutique");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)

        {

            _navigationStore.CurrentViewModel = new ReservationListingViewModel(_navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new ViewModels.MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
