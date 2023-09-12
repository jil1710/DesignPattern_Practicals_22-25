using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Singleton
{
    public sealed class SingletonClass
    {
        private static Logger _logger = null;
        public static Logger GetLoggerInstance()
        {
            if (_logger == null)
            {
                _logger = new Logger();
                return _logger;
            }
            return _logger;
        }
    }
}
