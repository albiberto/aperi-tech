namespace AperiTech.Abstract;

using Domain;

public interface IChecker
{
    IAsyncEnumerable<IShape> CheckAsync(IAsyncEnumerable<IShape> shapes);
}