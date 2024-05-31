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
        private string roomId;
        public string RoomId { get { return roomId; } set { roomId = value; } }
    }
}
