using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReserveRoom.Models;

namespace ReserveRoom.Exceptions
{
    public class ReservationConflictException : Exception

    {
        public Reservation ExistingReservation { get; }
        public Reservation IncommingReservation { get; }
        // constructor
        public ReservationConflictException(Reservation incommingReservation, Reservation existingReservation)
        {
            IncommingReservation = incommingReservation;
            ExistingReservation = existingReservation;
        }

        public ReservationConflictException(string message, Reservation incommingReservation, Reservation existingReservation) : base(message)
        {
            IncommingReservation = incommingReservation;
            ExistingReservation = existingReservation;
        }
        public ReservationConflictException(string Message, Exception innerException, Reservation incommingReservation, Reservation existingReservation) : base(Message, innerException)
        {
            IncommingReservation = incommingReservation;
            ExistingReservation = existingReservation;
        }
    }
}
