namespace AperiTech.Core
{
    using Abstract;
    using Domain;

    public class Printer : IPrinter
    {
        public void Print(IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.WriteToConsole("Printer", false);
                LocalPrint(GetMessage(shape));

                Console.WriteLine();

                Thread.Sleep(Settings.Delay);
            }
        }

        private static string GetMessage(Shape shape)
        {
            string message;

            switch (shape.Angles)
            {
                case 0:
                    message = string.Equals(shape.Color, "Red", StringComparison.OrdinalIgnoreCase)
                        ? string.Format("ID={0} CIRCLE is red", shape.Id)
                        : string.Format("ID={0} CIRCLE is {1}", shape.Id, shape.Color.ToUpperInvariant());
                    break;
                case 4:
                    message = string.Equals(shape.Color, "REd", StringComparison.OrdinalIgnoreCase)
                        ? string.Format("ID={0} SQUARE is red", shape.Id)
                        : string.Format("ID={0} SQUARE is {1}", shape.Id, shape.Color.ToUpperInvariant());
                    break;
                default:
                    // nameof operator: C# 6.0
                    // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/nameof
                    throw new ArgumentOutOfRangeException(nameof(shape));
            }

            return message;
        }

        private static void LocalPrint(string message)
        {
            Console.Write("    ");
            Console.Write($"MESSAGE: {message}");
            Console.WriteLine();
        }
    }
}