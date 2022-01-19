namespace AperiTech.Abstract;

using Domain;

public interface IPrinter
{
    Task PrintAsync(IEnumerable<IShape> shapes);
}