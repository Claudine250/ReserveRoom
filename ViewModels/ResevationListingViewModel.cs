using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReserveRoom.Commands;
using ReserveRoom.Stores;
using ReserveRoom.Services;
using System.Security.Cryptography.X509Certificates;
using ReserveRoom.Models;

namespace ReserveRoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly Hotel _hotel;

        //kept private to be editable here only
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        //private readonly Hotel hotel;
        //notify UI when reservations are added or removed
        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand MakeReservationCommand { get; }
        public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
        {
            _hotel = hotel;
            _reservations = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
            UpdateReservation();
            }
            //clear existing reservation
            private void UpdateReservation()
            
            {
            _reservations.Clear();

            // iterate over each reservation in our hotel
            foreach (Reservation reservation in _hotel.GetAllReservations())
            {
                //map each reservation to a view model
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                // add viewmodel to our observable collection
                _reservations.Add(reservationViewModel);
            }

        }
    }
}

