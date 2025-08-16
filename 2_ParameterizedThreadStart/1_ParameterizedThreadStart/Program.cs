internal class Program
{
    private static void Main(string[] args)
    {
        Thread t_1 = new Thread(start: new ParameterizedThreadStart(Go));
        Thread t_2 = new Thread(start: Go);
        t_1.Start(true);             // == Go(true) 
        t_2.Start(false);             // == Go(false) 
        Go(false);
    }

    /// <summary>
    /// ParameterizedThreadStart может принимать один аргумент типа object
    /// public delegate void ParameterizedThreadStart(object obj);
    /// </summary>
    /// <param name="upperCase"></param>
    private static void Go(object? upperCase)
    {
        bool? upper = (bool?)upperCase;
        Console.WriteLine(upper.HasValue && upper.Value ? "HELLO!" : "hello!");
    }
}