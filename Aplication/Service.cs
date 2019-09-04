using Microsoft.Extensions.Logging;

namespace log_elastic.Aplication
{
    public class Service
    {
        private readonly IRepository _repository;
        private readonly ILogger<Service> _logger;

        public Service(IRepository repository, ILogger<Service> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void Salvar(string valor) { 
            _logger.LogInformation($"Chamou salvar com o texto =>  {valor}");
            _repository.Save(valor); }
    }
}