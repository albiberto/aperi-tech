namespace AperiTech.Abstract;

using Domain;

public interface IPrinter
{
    Task PrintAsync(IAsyncEnumerable<IShape> shapes);
}