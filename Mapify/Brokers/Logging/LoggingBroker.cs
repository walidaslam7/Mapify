namespace Mapify.Brokers.Logging;

public class LoggingBroker : ILoggingBroker
{
    private readonly ILogger _logger;
    public LoggingBroker(ILogger logger) => _logger = logger;
    public void LogError(Exception exception) => _logger.LogError(exception, exception.Message);
    public void LogInformation(string @event) => _logger.LogInformation(@event);
    public void LogWarning(string @event) => _logger.LogWarning(@event);
    public void LogDebug(string @event) => _logger.LogDebug(@event);
    public void LogTrace(string @event) => _logger.LogTrace(@event);
    public void LogCritical(Exception exception) => _logger.LogCritical(exception, exception.Message);
}