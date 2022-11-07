using Microsoft.Extensions.Logging;

namespace BLeader.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> _logger;

        public MailService(ILogger<MailService> logger)
        {
            _logger = logger;
        }

        public void SomteTestMethod()
        {
            _logger.LogInformation($"Some log message");
        }
    }
}
