using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace log_elastic.Aplication
{
    public class BackgroudService : IHostedService, IDisposable
    {
        private readonly ILogger<BackgroudService> _logger;
        private readonly IServiceProvider _services;
        private readonly IRepository _repository;
        private Timer _timer;

        public BackgroudService(ILogger<BackgroudService> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;

            using (var scope = _services.CreateScope())
            {
                var repository =
                    scope.ServiceProvider
                        .GetRequiredService<IRepository>();

                _repository = repository;
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                        TimeSpan.FromSeconds(20));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var data = DateTime.UtcNow.ToString();
            _repository.Save(data);


            _logger.LogInformation("Timed Background Service is working.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}