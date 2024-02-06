using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Manage.Model
{
    internal class HomeLoan:Loan
    {
   
        public string propertyAddress { get; set; }
        public int propertyValue { get; set; }

        // Constructors
        public HomeLoan()
        {

        }
        public HomeLoan(string _propertyAddress, int _propertyValue, int LoanID, int CustomerID, int PrincipalAmount, int InterestRate, int LoanTerm, string LoanType, string LoanStatus) : base(LoanID, CustomerID, PrincipalAmount, InterestRate, LoanTerm, LoanType, LoanStatus)
        {
            propertyAddress = _propertyAddress;
            propertyValue = _propertyValue;
        }

        // Constructor overloading
        public void homeLoanDetails(string propertyAddress, int propertyValue)
        {
            Console.WriteLine($"PropertyAddress :: {propertyAddress}\t PropertyValue:: {propertyValue}");
        }

        public void homeLoanDetails(string propertyAddress, string propertyValue, int LoanID)
        {
            Console.WriteLine($"PropertyAddress :: {propertyAddress}\t PropertyValue:: {propertyValue}\t LoanID:: {LoanID}");
        }
    }
}
