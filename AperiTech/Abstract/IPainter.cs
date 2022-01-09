namespace AperiTech.Abstract;

using Domain;

public interface IPainter
{
    IEnumerable<Shape> Paint(IEnumerable<Shape> shapes);
}