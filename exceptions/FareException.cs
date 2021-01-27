using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCardProblemMF.exceptions
{
    public class FareException : Exception
    {
        public FareException()
        {
        }

        public FareException(string message) : base(message)
        {
        }

        
    }
}
