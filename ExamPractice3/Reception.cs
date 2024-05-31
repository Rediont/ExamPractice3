using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class Reception
    {
        Dictionary<string,Room> rooms;
        List<string> Log;
        public delegate void RoomStatusHandler(Room room);
        public event RoomStatusHandler OnCheckIn;
        public event RoomStatusHandler OnCheckOut;

        public void CheckIn(string roomId, Visitor visitor,int daysRented)
        {
            Room room = rooms[rooms.Keys.FirstOrDefault(x => x == roomId)];
            if (rooms[room._id]._status == "Available")
            {
                visitor.RoomId = roomId;
                room._occupier = visitor.Name;
                rooms[room._id]._status = "Occupied";
            }
            else
            {
                throw new Exception("Room unaviable");
            }


        }
    }
}
