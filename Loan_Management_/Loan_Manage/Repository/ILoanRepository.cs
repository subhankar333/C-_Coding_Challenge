using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan_Manage.Model;

namespace Loan_Manage.Repository
{
    internal interface ILoanRepository
    {
        int applyLoan(Loan loan);

        int calculateInterest(int Id);

        void loanStatus(int Id);

        long calculateEMI(int Id);

        long loanRepayment(int Id, int Amount);
        List<Loan> getAllLoan();

        Loan getLoanById(int Id);
    }
}
