using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public string Username { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public TimeSpan Length => EndTime.Subtract(StartTime); // length og reservation

        // constructors to get the reservation info from
        public Reservation(RoomID roomID, string username, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            Username = username;
            StartTime = startTime;
            EndTime = endTime;

        }

        public bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomID != RoomID) // no conflicts if room ID do not match
                return false;

            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }

    }
}
