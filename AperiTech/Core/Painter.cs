namespace AperiTech.Core
{
    using Abstract;
    using Bogus;
    using Domain;

    public class Painter : IPainter
    {
        private static IEnumerable<string> Colors
        {
            get { return new HashSet<string>() {"red", "blue", "yellow"}; }
        }

        private readonly Faker _faker = new Faker();

        public void Paint(IEnumerable<Shape> shapes)
        {
            using (var enumerator = shapes.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var shape = enumerator.Current;
                    shape.Color = _faker.PickRandom(Colors).OrNull(_faker, 0.2f);

                    shape.WriteToConsole("Painter");
                    Thread.Sleep(Settings.Delay);
                }
            }
        }
    }
}