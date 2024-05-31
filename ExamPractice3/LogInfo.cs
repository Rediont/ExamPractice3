using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice3;
public class LogInfo
{

    public string Type { get; set; }
    public string Message { get; set; }
    public DateTime Time { get; set; }

    public LogInfo(string type, string message)
    {
        Type = type;
        Message = message;
        Time = DateTime.Now;
    }

    public LogInfo(Visitor visitor, int roomId, string type)
    {
        Type = type;
        Message = $"Visitor {visitor.Name} {type} in room #{roomId}";
        Time = DateTime.Now;
    }

    public void Save()
    {

    }
}
