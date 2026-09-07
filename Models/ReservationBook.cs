using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveRoom.Exceptions;

namespace ReserveRoom.Models
{
    // hold all reservations in bookings
    public class ReservationBook
    {
        // list of reservations to iterate through
        private readonly List<Reservation> _Reservations;

        public ReservationBook()
        {
            _Reservations =  new List<Reservation>();
        }

        // get reservations for user to view
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _Reservations;
        }

        // Make or create reservations
        // handle conflict when user attempt to add a reservation that has already been booked

        public void AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in _Reservations)
            {
                if (existingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictException(existingReservation, reservation);
                }
            }

            _Reservations.Add(reservation);
        }

    }
}
