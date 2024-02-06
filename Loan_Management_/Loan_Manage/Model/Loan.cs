using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Manage.Model
{
    internal class Loan
    {
        public int LoanID { get; set; }
        public int CustomerID { get; set; }
        public int PrincipalAmount { get; set; }
        public int InterestRate { get; set; }
        public int LoanTerm { get; set; }
        public string LoanType { get; set; }
        public string LoanStatus { get; set; }

        // Constructors
        public Loan()
        {

        }

        public Loan(int _LoanID, int _CustomerID, int _PrincipalAmount, int _InterestRate, int _LoanTerm, string _LoanType, string _LoanStatus)
        {
            LoanID = _LoanID;
            CustomerID = _CustomerID;
            PrincipalAmount = _PrincipalAmount;
            InterestRate = _InterestRate;
            LoanTerm = _LoanTerm;
            LoanType = _LoanType;
            LoanStatus = _LoanStatus;
        }
        public override string ToString()
        {
            return $"LoanID:: {LoanID}\t CustomerID:: {CustomerID}\t PrincipalAmount:: {PrincipalAmount}\t InterestRate:: {InterestRate}\t LoanTerm:: {LoanTerm} LoanType:: {LoanType}\t LoanStatus:: {LoanStatus}";
        }

        

    }
}
