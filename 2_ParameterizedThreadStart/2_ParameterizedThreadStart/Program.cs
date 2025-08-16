internal class Program
{
    private static void Main(string[] args)
    {
        Thread t = new Thread(delegate ()
        {
            WriteText("Hello");
        });
        t.Start();
    }

    /// <summary>
    /// В качестве альтернативы можно использовать анонимный метод
    /// </summary>
    /// <param name="text"></param>
    private static void WriteText(string text)
    {
        Console.WriteLine(text);
    }
}