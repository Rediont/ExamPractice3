using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class Reception
    {
        Dictionary<int,Room> rooms;
        List<string> Log;
        public delegate void RoomStatusHandler(Room room);
        public event RoomStatusHandler OnCheckIn;
        public event RoomStatusHandler OnCheckOut;

        public async Task<bool> CheckIn(int roomId, Visitor visitor,int daysRented)
        {
            Room room = rooms[rooms.Keys.FirstOrDefault(x => x == roomId)];
            if (rooms[room._id]._status == "Available")
            {
                visitor.RoomId = roomId;
                room._occupier = visitor.Name;
                rooms[room._id]._status = "Occupied";
                await Task.Delay(daysRented * 1000);
                return true;
            }
            else
            {
                throw new Exception("Room unaviable");
            }
        }

        public async Task<bool> CheckOut(int roomId, Visitor visitor, int daysRented)
        {
            if (CheckIn(roomId, visitor, daysRented).Result)
            {
                Room room = rooms[rooms.Keys.FirstOrDefault(x => x == roomId)];
                visitor.CheckOut();
                room._occupier = null;
                rooms[room._id]._status = "Open";
                return true;
            }
            else
            {
                throw new Exception("somethig went wrong");
            }
        }
    }
}
