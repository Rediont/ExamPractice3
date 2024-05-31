using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3
{
    public class Visitor
    {
        private string _name;
        private string roomId;
        public string Name { get { return _name; } set { _name = value; } }
        public string RoomId { get { return roomId; } set { roomId = value; } }
    }
}
