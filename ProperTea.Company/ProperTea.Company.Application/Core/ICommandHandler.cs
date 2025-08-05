using System.Threading.Tasks;

namespace ProperTea.Company.Application.Core
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand
    {
        Task<TResult> HandleAsync(TCommand command);
    }

    public interface ICommandHandler<TCommand>: ICommandHandler<TCommand, object?>
        where TCommand : ICommand
    {
    }
}
