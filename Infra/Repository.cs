using System;
using System.IO;
using log_elastic.Aplication;

namespace log_elastic.Infra
{
    public class Repository : IRepository
    {
        public Repository() { }

        public void Save(string value)
        {
            string path = @"D:\Projetos\log_elastic\Banco\Todo";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("value");
                }
            }

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