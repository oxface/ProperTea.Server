namespace ProperTea.Shared.Application.Commands;

public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
{
    Task<TResult> HandleAsync(TCommand command);
}

public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, object?>
    where TCommand : ICommand
{
}