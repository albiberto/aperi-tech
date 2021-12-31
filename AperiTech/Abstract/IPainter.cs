namespace AperiTech.Abstract;

using Domain;

public interface IPainter
{
    void Paint(IEnumerable<Shape> shapes);
}