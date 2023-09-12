using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class Logger
    {
        private string _logPath = @"logs/log.txt";

        public void Log(string message)
        {
            string formattedMessage = $"{DateTime.Now} : {message}";
            using (StreamWriter sr = File.AppendText(_logPath))
            {
                try
                {
                    sr.WriteLine(formattedMessage);
                }
                catch (Exception ex)
                {
                    string value = $"An exception has occured : {ex.Message}";
                    sr.WriteLine(value);
                }
            }
        }
    }
}
