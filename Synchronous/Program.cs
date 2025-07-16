using System.Diagnostics;

Console.WriteLine("Doing stuff");

var sw = new Stopwatch();
sw.Start();

WashClothesInTheMachine();
MakeCoffee();
Study();

sw.Stop();
var seconds = sw.Elapsed.TotalSeconds;
Console.WriteLine("Stuff is done");
Console.WriteLine($"Total time: {seconds}");
return;

static void Study()
{
    Console.WriteLine("Hello, World!");
    Console.WriteLine("I have to study");
    Console.WriteLine("Studied");
}

static void MakeCoffee()
{
    Console.WriteLine("Machine is making a coffee");
    Task.Delay(5000).Wait();
    Console.WriteLine("Coffee is ready");
}

static void WashClothesInTheMachine()
{
    Console.WriteLine("Machine is starting");
    Task.Delay(5000).Wait();
    Console.WriteLine("Clothes are being soaked and washed");
    Task.Delay(5000).Wait();
    Console.WriteLine("Washing clothes");
    Task.Delay(1000).Wait();
    Console.WriteLine("Done washing clothes");
}