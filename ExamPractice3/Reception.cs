using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class Reception
    {
        private string _path = "log.{date}.json";
        private Dictionary<int, Room> rooms = new Dictionary<int, Room>();
        private List<LogInfo> logs = new List<LogInfo>();

        public delegate Task RoomStatusHandler(Room room);
        public event RoomStatusHandler OnCheckIn;
        public event RoomStatusHandler OnCheckOut;

        public Reception()
        {
            rooms.Add(1, new GoodRoom(1, "Room 1", 100));
            rooms.Add(2, new GoodRoom(2, "Room 2", 200));
            rooms.Add(3, new GoodRoom(3, "Room 3", 300));
            rooms.Add(4, new HighEndRoom(4, "Room 4", 400));

            OnCheckOut += CleanUp;
        }

        public async Task<bool> CheckIn(int roomId, Visitor visitor, int daysRented)
        {
            if (rooms.ContainsKey(roomId))
            {
                Room room = rooms[roomId];
                if (room.Status == RoomStatus.Available)
                {
                    visitor.RoomId = roomId;
                    room.Occupier = visitor.Name;
                    room.Status = RoomStatus.Occupied;

                    logs.Add(new LogInfo(visitor, roomId, "check in"));

                    return true;
                }
                else
                {
                    while (room.Status == RoomStatus.Cleaning && room.Status != RoomStatus.Occupied)
                    {
                        Console.WriteLine("Room is not available, please wait");

                        await Task.Delay(1000);
                    }

                    visitor.RoomId = roomId;
                    room.Occupier = visitor.Name;
                    room.Status = RoomStatus.Occupied;

                    logs.Add(new LogInfo(visitor, roomId, "check in"));
                    return true;
                }
            }
            else
            {
                throw new Exception($"There is no room with room Id: {roomId}");
            }
        }

        public async Task CleanUp(Room room)
        {
            room.Status = RoomStatus.Cleaning;
            logs.Add(new LogInfo("Cleaning", "Cleaning has started"));
            await Task.Delay(5000);
            logs.Add(new LogInfo("Cleaning", "Cleaning has ended"));
            room.Status = RoomStatus.Available;
        }

        public bool CheckOut(int roomId, Visitor visitor)
        {
            var isRoomExists = rooms.TryGetValue(roomId, out Room room);
            if (isRoomExists && room!.Occupier == visitor.Name)
            {
                visitor.CheckOut();
                room.Occupier = null;
                rooms[room.Id].Status = RoomStatus.Available;
                logs.Add(new LogInfo(visitor, roomId, "check out"));

                OnCheckOut?.Invoke(room);
                return true;
            }
            else
            {
                Console.WriteLine("Room is not occupied by this visitor");
                return false;
            }

        }

        public async Task SaveLogs()
        {
            Console.WriteLine("Saving logs...");
            // симуляція зберігання великого файлу
            await Task.Delay(5000);
            string path = _path.Replace("{date}", DateTime.Now.ToString("dd_MM_yyyy"));
            string json = JsonSerializer.Serialize(logs);
            File.AppendAllText(path, json);
        }
    }
}

