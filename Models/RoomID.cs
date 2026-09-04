using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Models
{
    public class RoomID
    {
        public int FloorNumber {get; }
        public int RoomNumber { get; }
    // constructors of where room info will be gotten from
    public RoomID(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }
    // override Strings
    public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }

    // add override so that dictionary knows how to compare keys when values are added or gotten

        public override bool Equals(object obj)
        {
            return obj is RoomID roomID &&
                FloorNumber == roomID.FloorNumber &&
                RoomNumber == roomID.RoomNumber;
        }
        // when we override equals, then we must override gethash codes
        public override int GetHashCode()
        {
            return HashCode.Combine(FloorNumber, RoomNumber); // this return a unique id for our roomID
        }

        public static bool operator ==(RoomID roomID1, RoomID roomID2)
        {
            if(roomID1 is null && roomID2 is null)
            {
                return true;
            }
            return !(roomID1 is null) && roomID1.Equals(roomID2);
        }
        public static bool operator !=(RoomID roomID1, RoomID roomID2)
        {
            return !(roomID1 == roomID2);
        }

    }

}
