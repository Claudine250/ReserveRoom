using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReserveRoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {

        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }
        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            _reservations.Add(new ReservationViewModel(new Models.Reservation(new Models.RoomID(1, 2), "cocoN", DateTime.Now, DateTime.Now.AddDays(4))));
            _reservations.Add(new ReservationViewModel(new Models.Reservation(new Models.RoomID(4, 2), "NanaU", DateTime.Now, DateTime.Now.AddDays(4))));
            _reservations.Add(new ReservationViewModel(new Models.Reservation(new Models.RoomID(6, 2), "NelyU", DateTime.Now, DateTime.Now.AddDays(4))));

        }
    }
}
