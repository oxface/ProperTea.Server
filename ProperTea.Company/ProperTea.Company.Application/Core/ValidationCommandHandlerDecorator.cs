using FluentValidation;

namespace ProperTea.Company.Application.Core;

public class ValidationCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand
{
    private readonly ICommandHandler<TCommand, TResult> _decorated;
    private readonly IValidator<TCommand>? _validator;

    public ValidationCommandHandlerDecorator(
        ICommandHandler<TCommand, TResult> decorated,
        IValidator<TCommand>? validator = null)
    {
        _decorated = decorated;
        _validator = validator;
    }

    public async Task<TResult> HandleAsync(TCommand command)
    {
        if (_validator != null)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        return await _decorated.HandleAsync(command);
    }
}


public class ValidationCommandHandlerDecorator<TCommand> : 
    ValidationCommandHandlerDecorator<TCommand, object?>, ICommandHandler<TCommand>
    where TCommand : ICommand
{
    public ValidationCommandHandlerDecorator(
        ICommandHandler<TCommand> decorated,
        IValidator<TCommand>? validator = null): base(decorated, validator)
    {
    }
}