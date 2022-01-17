namespace AperiTech.Abstract;

using Domain;

public interface IProvider
{
    IEnumerable<IShape> Get();
}