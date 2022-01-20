namespace AperiTech.Abstract;

using Domain;

public interface IProvider
{
    IAsyncEnumerable<IShape> GetAsync();
}