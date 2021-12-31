namespace AperiTech
{
    using Domain;

    public static class Helpers
    {
        // extension methods: C# 3.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
        // DOC: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/extension-methods
        public static void WriteToConsole(this Shape shape, string step, bool newLine = true)
        {
            Console.WriteLine(String.Format("{0}_{1} run at {2}", step, shape.Id, DateTime.Now.ToString("O")));
            Console.Write("    ");
            Console.Write(shape);
            Console.WriteLine();

            if (newLine) Console.WriteLine();
        }
    }
}