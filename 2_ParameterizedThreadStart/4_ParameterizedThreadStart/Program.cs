/// <summary>
/// Другой способ передачи данных в поток состоит в запуске в потоке метода определенного экземпляра объекта,
/// а не статического метода.
/// Тогда свойства выбранного экземпляра объекта будут определять поведение потока,
/// как в следующем варианте примера:
/// </summary>
internal class Program
{
    bool upper;

    private static void Main(string[] args)
    {
        Program instance1 = new Program();
        instance1.upper = true;
        Thread t = new Thread(instance1.Go);
        t.Start();
        Program instance2 = new Program();
        instance2.Go();  // Запуск в главном потоке - с upper=false
    }

    private void Go()
    {
        Console.WriteLine(upper ? "HELLO!" : "hello!");
    }
}