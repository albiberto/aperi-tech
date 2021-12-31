namespace AperiTech.Abstract;

using Domain;

public interface IPrinter
{
    void Print(IEnumerable<Shape> shapes);
}