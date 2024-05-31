using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class Reception
    {
        Dictionary<Room,string> roomStatus;
        List<string> Log;
        public delegate void RoomStatusHandler(Room room);
        public event RoomStatusHandler OnCheckIn;
        public event RoomStatusHandler OnCheckOut;

        public void CheckIn(string roomId, Visitor visitor)
        {
            Room room = roomStatus.Keys.FirstOrDefault(x => x.Id == roomId);
            if (roomStatus[room] == "Aviable")
            {
                visitor.RoomId = roomId;
                room.Occupier = visitor.Name;
            }
            else
            {
                throw new Exception("Room unaviable");
            }
        }
    }
}
