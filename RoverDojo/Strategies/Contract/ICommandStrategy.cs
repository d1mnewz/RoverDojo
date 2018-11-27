using RoverDojo.Core.Data;

namespace RoverDojo.Strategies.Contract
{
    public interface ICommandStrategy
    {
        Vector Apply(Vector vector);
    }
}