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
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("Cocos boutique");

            try
            {


                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 3),
                    "claudine",
                    new DateTime(2009, 1, 1),
                    new DateTime(2010, 1, 2)));

                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 3),
                    "claudine1",
                    new DateTime(2009, 1, 1),
                    new DateTime(2010, 1, 2)));
            }
            catch (ReservationConflictException ex)
            {

            }
            IEnumerable<Reservation> reservation = hotel.GetReservationsForUser("claudine");

            base.OnStartup(e);
        }
    }

}
