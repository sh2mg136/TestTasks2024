using TestTasks2024;

Console.WriteLine("Task #1");

ISortingMethod method = new MyBubbleSortDesc();

T1_Sorting ts1 = new T1_Sorting(4, method, 100);
ts1.Sort();
Console.WriteLine(ts1);
Console.WriteLine(ts1.Info);
Console.WriteLine();

ts1 = new T1_Sorting(100, method, 1000);
ts1.Sort();
Console.WriteLine(ts1);
Console.WriteLine(ts1.Info);
Console.WriteLine();

Console.WriteLine("\r\n\r\nTask #2\r\n");

T2_Threads.PingPong_Variant_1();
Console.WriteLine();
T2_Threads.PingPong_Variant_2();
Console.WriteLine();
T2_Threads.PingPong_Variant_3();

Console.WriteLine();
Console.WriteLine("\r\n\r\nTask #3 (Standard Deviation)\r\n");
var stdev = T3_StandardDeviation.StandardDeviation([3, 5, 7, 4, 56, 9, 67, 4, 56,]);
Console.WriteLine($"\r\n\r\nStandardDeviation = {stdev}");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("\r\n\r\nTask #5 (LinkedList)\r\n");
MyLinkedList<int> list = new MyLinkedList<int>();

list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);

list.PrintAll();
Console.WriteLine($"Closed: {list.IsClosed()}");
list.CloseListForTest();
Console.WriteLine("Closing list for test purpose...");
Console.WriteLine($"Closed: {list.IsClosed()}");
Console.WriteLine();
