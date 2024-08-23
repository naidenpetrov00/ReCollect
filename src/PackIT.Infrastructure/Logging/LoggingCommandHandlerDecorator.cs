namespace PackIT.Infrastructure.Logging;

using MediatR;
using Microsoft.Extensions.Logging;

internal sealed class LoggingCommandHandlerDecorator<TCommand> : IRequestHandler<TCommand>
    where TCommand : class, IRequest
{
    private readonly IRequestHandler<TCommand> commandHandler;
    private readonly ILogger<LoggingCommandHandlerDecorator<TCommand>> logger;

    public LoggingCommandHandlerDecorator(
        IRequestHandler<TCommand> commandHandler,
        ILogger<LoggingCommandHandlerDecorator<TCommand>> logger
    )
    {
        this.commandHandler = commandHandler;
        this.logger = logger;
    }

    public async Task Handle(TCommand request, CancellationToken cancellationToken)
    {
        var commandType = request.GetType().Name;

        try
        {
            this.logger.LogInformation($"Started processing {commandType} command.");
            await this.commandHandler.Handle(request, cancellationToken);
            this.logger.LogInformation($"Finished processing {commandType} command.");
        }
        catch
        {
            this.logger.LogError($"Failed to process {commandType} command");
            throw;
        }
    }
}
