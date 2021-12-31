namespace AperiTech.Domain
{
    public class Shape
    {
        public int Id { get; set; }
        public int Angles { get; set; }
        public string Color { get; set; }

        // ?: operator: C# 1.0
        // DOC: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
        public override string ToString()
        {
            return string.Format("SHAPE: ID={0} Angles={1} Color={2}", Id, Angles, string.IsNullOrEmpty(Color) ? "N/A" : Color.ToUpperInvariant());
        }
    }
}