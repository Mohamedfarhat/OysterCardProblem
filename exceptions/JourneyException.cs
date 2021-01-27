using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCardProblemMF.exceptions
{
    public class JourneyException:Exception
    {
        public JourneyException()
        {
        }

        public JourneyException(string message) : base(message)
        {
        }

        
    }
}
