namespace AperiTech.Abstract;

using Domain;

public interface IChecker
{
    Task<IEnumerable<IShape>> CheckAsync(IEnumerable<IShape> shapes);
}