using ExamPractice3;
using System.Runtime.InteropServices;

var reception = new Reception();
var visitor1 = new Visitor("John");
var visitor2 = new Visitor("Jane");

await reception.CheckIn(1, visitor1, 5);
reception.CheckOut(1, visitor1);

await reception.CheckIn(1, visitor2, 5);

Console.WriteLine("Press any key to save logs");
Console.ReadKey();

Task logTask = reception.SaveLogs();
Console.WriteLine("Logs saving is in progress");
Console.WriteLine("Reception is open");


await logTask;
Console.WriteLine("Logs saved successfully");