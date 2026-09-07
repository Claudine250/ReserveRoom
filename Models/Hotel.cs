using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;
        public String Name{ get; } //get name from the constructor
        public Hotel(string name)
        {
            Name = name;
            _reservationBook = new ReservationBook();
        }
        /// <summary>
        /// get allreservations
        /// </summary>
        /// <returns>All reservations </returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }

        /// <summary>
        /// make reservations
        /// </summary>
        /// <param name="reservation"></param>
        /// <exception cref="ReservartionConflictException"

        public void MakeReservation(Reservation reservation) {
            _reservationBook.AddReservation(reservation);
        }
    }
}

