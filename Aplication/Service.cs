namespace log_elastic.Aplication
{
    public class Service
    {
        private readonly IRepository _repository;

        public Service(IRepository repository) => _repository = repository;

        public void Salvar(string valor) => _repository.Save(valor);
    }
}