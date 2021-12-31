namespace AperiTech.Core
{
    using Abstract;
    using Domain;

    public class Checker : IChecker
    {
        private static IEnumerable<int> Angles
        {
            get { return new HashSet<int>() {0, 4}; }
        }

        private static IEnumerable<string> Colors
        {
            get { return new HashSet<string>() {"red", "blue", "yellow"}; }
        }

        private readonly IEnumerable<Shape> _validShapes;

        public Checker()
        {
            // language integrated query (LINQ): C# 3.0
            // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
            _validShapes =
                from id in Enumerable.Range(0, Settings.Total)
                from angles in Angles
                from color in Colors
                select new Shape()
                {
                    Id = id,
                    Angles = angles,
                    Color = color
                };
        }

        public IEnumerable<Shape> Check(IEnumerable<Shape> shapes)
        {
            var acc = new List<Shape>();

            foreach (var shape in shapes)
            foreach (var validShape in _validShapes)
            {
                if (validShape.Id != shape.Id || validShape.Angles != shape.Angles || validShape.Color != shape.Color) continue;

                shape.WriteToConsole("Checker");
                acc.Add(shape);
                Thread.Sleep(Settings.Delay);
                break;
            }

            return acc;
        }
    }
}