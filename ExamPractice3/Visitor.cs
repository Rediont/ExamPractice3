using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class Visitor
    {
        public string Name { get; private set; }
        public int? RoomId { get; set; }
        public Visitor(string name, int? roomId = null)
        {
            Name = name;
            RoomId = roomId;
        }

        public async Task<bool> StayInRoom(int time)
        {
            await Task.Delay(time * 1000);
            return true;
        }

        public void CheckOut()
        {
            RoomId = null;
        }
    }
}

