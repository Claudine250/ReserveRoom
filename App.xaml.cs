using System.Configuration;
using System.Data;
using System.Windows;
using ReserveRoom.Exceptions;
using ReserveRoom.Models;

namespace ReserveRoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //hotel to be used in all of our application
        private readonly Hotel _hotel;

        public App()
        {
            _hotel = new Hotel("Coco's Boutique");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new ViewModels.MainViewModel(_hotel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
