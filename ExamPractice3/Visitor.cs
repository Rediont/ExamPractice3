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
        private int? _roomId;
        public int? RoomId { get { return _roomId; } set { if (value > 0 && value < 11) { _roomId = value; } } }
        public Visitor(string name, int? roomId = null)
        {
            Name = name;
            _roomId = roomId;
        }

        public void CheckOut()
        {
            _roomId = 0;
        }
    }
}
