using Microsoft.Extensions.Logging;

namespace App.Logging
{
    public class LoggerService:ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;
        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }
        public void LogInfo(string message)
        {
            _logger.LogInformation($"[INFO] {DateTime.UtcNow}: {message}");
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning($"[WARNING] {DateTime.UtcNow}: {message}");
        }

        public void LogError(string message, Exception ex)
        {
            _logger.LogError(ex, $"[ERROR] {DateTime.UtcNow}: {message}");
        }
    }
}

