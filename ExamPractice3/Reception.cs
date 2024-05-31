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

        public bool CheckIn(int roomId, Visitor visitor,int daysRented)
        {
            if (rooms.ContainsKey(roomId)) 
            {
                Room room = rooms[roomId];
                if (rooms[room._id].Status == "Available")
                {
                    visitor.RoomId = roomId;
                    room.Occupier = visitor.Name;
                    rooms[room._id].Status = "Occupied";
                    Log.Add($"{room._name} is occupied by {visitor.Name}");
                    return true;
                }
                else
                {
                    throw new Exception("Room unaviable");
                }
            }
            else
            {
                throw new Exception($"There is no room with room Id: {roomId}");
            }
        }

        public void StartCleanUp(Room room)
        {
            room.Status = "Cleaning";
            Log.Add($"Started cleaning of {room._name}");
        }

        public bool CheckOut(int roomId, Visitor visitor, int daysRented)
        {
            if (CheckIn(roomId, visitor, daysRented))
            {
                Room room = rooms[rooms.Keys.FirstOrDefault(x => x == roomId)];
                visitor.CheckOut();
                room.Occupier = null;
                rooms[room._id].Status = "Available";
                Log.Add($"{visitor.Name} checked out from {room._name}");
                return true;
            }
            else
            {
                throw new Exception("somethig went wrong");
            }
        }

        public void Save(string path)
        {
            using(StreamWriter sw = new StreamWriter("/"+path))
            {
                foreach(string line in Log)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
