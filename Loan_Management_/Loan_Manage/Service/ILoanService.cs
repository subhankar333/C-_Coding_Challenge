using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Manage.Service
{
    internal interface ILoanService
    {
        void applyLoan();

        void calculateInterest();

        void loanStatus();
        void calculateEMI();
        void loanRepayment();
        void getAllLoan();

        void getLoanById();
    }
}
