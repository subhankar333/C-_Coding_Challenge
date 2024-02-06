using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Manage.Exception
{
    internal class InvalidLoanException:ApplicationException
    {
        public InvalidLoanException() 
        { 

        }

        public InvalidLoanException(string message) : base(message)
        {

        }
    }
}
