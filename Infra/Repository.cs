using System;
using System.IO;
using log_elastic.Aplication;
using Microsoft.Extensions.Logging;

namespace log_elastic.Infra
{
    public class Repository : IRepository
    {
        private readonly ILogger<Repository> _logger;

        public Repository( ILogger<Repository> logger) {
            _logger = logger;
        }

        public void Save(string value)
        {
            string path = @"D:\Projetos\log_elastic\Banco\Todo.txt";
            if (!File.Exists(path))
            {
                _logger.LogInformation("O Arquivo existe");
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(value);
                }
            }
            _logger.LogInformation("Ta fora do if");
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}