namespace AperiTech.Abstract;

using Domain;

public interface IProvider
{
    Task<IEnumerable<IShape>> GetAsync();
}