using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ReserveRoom.Exceptions;
using ReserveRoom.Models;
using ReserveRoom.ViewModels;

namespace ReserveRoom.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel)
        {
           _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            //subscribe to event to know changes have been made
            _makeReservationViewModel.PropertyChanged += onViewModelPropertyChanged;
        }

        

        //disabled button if user hasn't entered username using can execute

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) &&
                _makeReservationViewModel.FloorNumber > 0 && 
                base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Username,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate);

            try
            {
                _hotel.MakeReservation(reservation);

                MessageBox.Show("Sucessfully Reserved.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ReservationConflictException) { 
                MessageBox.Show("This room is already taken.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        //enable the submit button when username is entered[raise a can execute event]
        private void onViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber)) {
                OnCanExecuteChanged();
            }
        }
    }
    
}
