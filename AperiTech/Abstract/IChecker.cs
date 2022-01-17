namespace AperiTech.Abstract;

using Domain;

public interface IChecker
{
    IEnumerable<IShape> Check(IEnumerable<IShape> shapes);
}