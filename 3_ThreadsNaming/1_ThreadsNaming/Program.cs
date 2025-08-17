/// <summary>
/// Поток можно поименовать, используя свойство Name.
/// Это предоставляет большое удобство при отладке: имена потоков можно вывести в Console.WriteLine
/// и увидеть в окне Debug – Threads в Microsoft Visual Studio.
/// Имя потоку может быть назначено в любой момент.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Thread thread = new Thread(() =>
        {
            Thread.CurrentThread.Name = "@lambda";
            Console.WriteLine("Hello from " + Thread.CurrentThread.Name);
        });
        Thread worker = new Thread(Go)
        {
            Name = "worker"
        };
        worker.Start();
        thread.Start();
        Thread.CurrentThread.Name = "main";
        Go();
    }

    private static void Go()
    {
        Console.WriteLine("Hello from " + Thread.CurrentThread.Name);
    }
}