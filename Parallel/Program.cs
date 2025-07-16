using System.Diagnostics;

Console.WriteLine("Doing stuff");

var sw = new Stopwatch();
sw.Start();

 var doStuff = DoStuffAsync();
  Study();
await Task.WhenAll(doStuff);

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

static async Task MakeCoffeeAsync()
{
    Console.WriteLine("Machine is making a coffee");
    await Task.Delay(5000);
    Console.WriteLine("Coffee is ready");
}

static async Task WashClothesInTheMachineAsync()
{
    Console.WriteLine("Machine is starting");
    await Task.Delay(5000);
    Console.WriteLine("Clothes are being soaked and washed");
    await Task.Delay(5000);
    Console.WriteLine("Washing clothes");
    await Task.Delay(1000);
    Console.WriteLine("Done washing clothes");
}

static async Task DoStuffAsync()
{
    var wash = WashClothesInTheMachineAsync();
    var coffee = MakeCoffeeAsync();
    await Task.WhenAll(wash, coffee);
}
