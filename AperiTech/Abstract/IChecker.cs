namespace AperiTech.Abstract;

using Domain;

public interface IChecker
{
    IEnumerable<Shape> Check(IEnumerable<Shape> shapes);
}