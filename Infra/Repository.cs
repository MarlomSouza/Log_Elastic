using System;
using System.IO;
using log_elastic.Aplication;
using Microsoft.Extensions.Logging;

namespace log_elastic.Infra
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;

        public Repository(ILogger<Repository> logger) => _logger = logger;

        public void Save(string value)
        {
            string path = @"D:\Projetos\log_elastic\Banco\Todo.txt";
            var mensagem = string.Format("Hora = {0}", value);
            if (!File.Exists(path))
            {
                _logger.LogInformation("O Arquivo existe");
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(mensagem);
                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(mensagem);
            }

            _logger.LogInformation("Escreve se ja existe o arquivo");
        }
    }
}