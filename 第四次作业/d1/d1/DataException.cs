using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1
{
    internal class DataException : ApplicationException
    {
        public DataException(string message) : base(message) { }
    }
}