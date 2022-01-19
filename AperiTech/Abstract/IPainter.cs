namespace AperiTech.Abstract;

using Domain;

public interface IPainter
{
    Task<IEnumerable<IShape>> PaintAsync(IEnumerable<IShape> shapes);
}