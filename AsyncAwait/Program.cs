using System.Diagnostics;

Console.WriteLine("Let's Procrastinate");
var sw = new Stopwatch();
sw.Start();
var procrastinate = ProcrastinateAsync();
// WaitTillTomorrowToStudy();
// LearnProgramming();
await Task.WhenAll(procrastinate);
sw.Stop();
var seconds = sw.Elapsed.TotalSeconds;
Console.WriteLine("Procrastination done");
Console.WriteLine($"Total time: {seconds}");

Console.WriteLine("We do not procrastinate");
var sw2 = new Stopwatch();
sw2.Start();
// await StudyNowAsync();
// await SelfLearnProgrammingAsync();
var doNotProcrastinate = DoNotProcrastinateAsync();
await Task.WhenAll(doNotProcrastinate);
sw2.Stop();
var seconds2 = sw2.Elapsed.TotalSeconds;
Console.WriteLine($"Total time: {seconds2}");
Console.WriteLine("We do not procrastinate done");
return;

// synchronous operations
static void WaitTillTomorrowToStudy()
{
    Console.WriteLine("Hello, World!");
    Console.WriteLine("I have to study");
    Task.Delay(1000).Wait();
    Console.WriteLine("Studied");
}

static void LearnProgramming()
{
    Console.WriteLine("I have to learn programming!");
    Task.Delay(5000).Wait();
    Console.WriteLine("Let me wait till I get into Uni");
    Console.WriteLine("Waiting done");
}

// asynchronous operations
static async Task StudyNowAsync()
{
    Console.WriteLine("Hello, World!");
    Console.WriteLine("I have to study");
    await Task.Delay(1000);
    Console.WriteLine("Studied");
}

static async Task SelfLearnProgrammingAsync()
{
    Console.WriteLine("I have to learn programming!");
    await Task.Delay(5000);
    Console.WriteLine("Let me self study");
    Console.WriteLine("Waiting done");
}

static async Task ProcrastinateAsync()
{
    WaitTillTomorrowToStudy();
    LearnProgramming();
}

static async Task DoNotProcrastinateAsync()
{
    await StudyNowAsync();
    await SelfLearnProgrammingAsync();
}



// parallel operations