namespace AperiTech.Abstract;

using Domain;

public interface IPainter
{
    IAsyncEnumerable<IShape> PaintAsync(IAsyncEnumerable<IShape> shapes);
}