/// <summary>
/// В главном потоке создается новый поток thread, исполняющий метод, 
/// который непрерывно печатает символы в зависимости от подставляемой реализации.
/// Одновременно главный поток непрерывно печатает символ 'x'.
/// CLR назначает каждому потоку свой стек, так что локальные переменные хранятся раздельно.
/// </summary>
internal class Program
{
    private enum Choise { SelfMethod = 0, OuterMethod, Delegate, AnonymousFunc }

    private static void Main(string[] args)
    {
        Choise choise = Choise.SelfMethod;
        Thread thread = null!;

        switch (choise)
        {
            case Choise.SelfMethod:
                thread = new(WriteY);
                break;
            case Choise.OuterMethod:
                Internal @internal = new Internal();
                thread = new Thread(@internal.Go);
                break;
            case Choise.Delegate:
                // Все время печатать 'delegate@Run!'
                thread = new Thread(start: delegate ()
                {
                    while (true)
                    {
                        Console.Write("delegate@Run!");
                    }
                });
                break;
            case Choise.AnonymousFunc:
                // Все время печатать 'Func@Run!'
                thread = new Thread(start: () =>
                {
                    while (true)
                    {
                        Console.Write("Func@Run!");
                    }
                });
                break;
            default:
                break;
        }

        // Выполнить Method в новом потоке
        thread.Start();

        // Все время печатать 'x'
        while (true)
        {
            Console.Write("x");
        }
    }

    /// <summary>
    /// Все время печатать 'y'
    /// </summary>
    private static void WriteY()
    {
        while (true)
        {
            Console.Write("y");
        }
    }
}

internal class Internal
{
    /// <summary>
    /// Все время печатать 'Internal@Go!'
    /// </summary>
    internal void Go()
    {
        while (true)
        {
            Console.Write("Internal@Go!");
        }
    }
}