using System.Diagnostics;

internal class Program
{
    /// <summary>
    /// Свойство Priority определяет, сколько времени на исполнение будет выделено потоку 
    /// относительно других потоков того же процесса. Существует 5 градаций приоритета потока:
    /// enum ThreadPriority { Lowest, BelowNormal, Normal, AboveNormal, Highest }
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        // Значение приоритета становится существенным, когда одновременно исполняются несколько потоков.
        // Установка приоритета потока на максимум еще не означает работу в реальном времени(real-time),
        // так как существуют еще приоритет процесса приложения.
        // Чтобы работать в реальном времени, нужно использовать класс Process из пространства имен
        // System.Diagnostics для поднятия приоритета процесса
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High; // ProcessPriorityClass.RealTime;


        Console.WriteLine("Hello, World!");
    }
}