internal class Program
{
    private static void Main(string[] args)
    {
        Thread worker = new Thread(delegate ()
        {
            Console.ReadLine();
        });

        if (args.Length == 0)
        {
            worker.IsBackground = false;
        }
        else
        {
            worker.IsBackground = true;
        }

        worker.Start();
    }
}