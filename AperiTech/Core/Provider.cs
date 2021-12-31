namespace AperiTech.Core
{
    using Abstract;
    using Bogus;
    using Domain;

    public class Provider : IProvider
    {
        private static IEnumerable<int> Angles
        {
            get { return new HashSet<int>() {0, 4}; }
        }

        private readonly Faker _faker = new Faker();

        public IEnumerable<Shape> Get()
        {
            var acc = new List<Shape>();

            foreach (var index in Enumerable.Range(0, Settings.Total))
            {
                var shape = new Shape()
                {
                    Id = index,
                    Angles = _faker.PickRandom(Angles)
                };

                shape.WriteToConsole("Provider");
                acc.Add(shape);
                Thread.Sleep(Settings.Delay);
            }

            return acc;
        }
    }
}