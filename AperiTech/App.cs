namespace AperiTech
{
    using Abstract;

    public class App
    {
        private const string Provider = "Provider";
        private const string Painter = "Painter";
        private const string Checker = "Checker";
        private const string Printer = "Printer";

        private readonly IProvider _provider;
        private readonly IPainter _painter;
        private readonly IChecker _checker;
        private readonly IPrinter _printer;

        public App(IProvider provider, IPainter painter, IChecker checker, IPrinter printer)
        {
            _provider = provider;
            _painter = painter;
            _checker = checker;
            _printer = printer;
        }

        public void Run()
        {
            CountDown(Provider);
            var shapes = _provider.Get();
            Complete(Provider);

            CountDown(Painter);
            _painter.Paint(shapes);
            Complete(Painter);

            CountDown(Checker);
            var valid = _checker.Check(shapes);
            Complete(Checker);

            CountDown(Printer);
            _printer.Print(valid);
            Complete(Printer);
        }

        private static void CountDown(string message)
        {
            Console.WriteLine();
            Console.Write("{0} launching ", message);

            foreach (var _ in Enumerable.Range(0, 3))
            {
                Console.Write(".");
                Thread.Sleep(Settings.Delay);
            }

            Console.WriteLine();
            Console.WriteLine("{0} launched at: {1}", message, DateTime.Now.ToString("O"));
            Console.WriteLine();
        }

        private static void Complete(string message)
        {
            Console.WriteLine();
            Console.WriteLine("{0} completed at: {1}", message, DateTime.Now.ToString("O"));
            Console.WriteLine();

            Thread.Sleep(Settings.Delay * 2);
        }
    }
}