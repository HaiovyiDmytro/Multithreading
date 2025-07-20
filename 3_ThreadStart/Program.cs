/// <summary>
/// Вместе с тем потоки разделяют данные, относящиеся к тому же экземпляру объекта, что и сами потоки:
/// Так как оба потока вызывают метод Go() одного и того же экземпляра ThreadTest, они разделяют поле done.
/// Результат – 'Done', напечатанное один раз вместо двух:
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        ThreadTest tt = new ThreadTest();   // Создаем общий объект
        new Thread(tt.Go).Start();          // Новый стек для потока
        tt.Go();                            // Стек основного потока
    }
}

internal class ThreadTest
{
    // Heap
    private bool done;

    // Stack
    // Go сейчас – экземплярный метод
    internal void Go()
    {
        if (!done)
        {
            done = true;
            Console.WriteLine("Done");
        }
        for (int cycles = 0; cycles < 5; cycles++)
        {
            Console.Write(cycles.ToString());
        }
    }
}