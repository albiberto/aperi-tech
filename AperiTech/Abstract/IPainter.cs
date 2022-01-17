namespace AperiTech.Abstract;

using Domain;

public interface IPainter
{
    IEnumerable<IShape> Paint(IEnumerable<IShape> shapes);
}