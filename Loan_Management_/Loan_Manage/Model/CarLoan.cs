using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Manage.Model
{
    internal class CarLoan:Loan
    {

        public string carModel { get; set; }
        public int carValue { get; set; }

        // Constructors
        public CarLoan()
        {

        }

        public CarLoan(string _carModel, int _carValue,int LoanID, int CustomerID, int PrincipalAmount, int InterestRate, int LoanTerm, string LoanType, string LoanStatus) : base(LoanID, CustomerID, PrincipalAmount, InterestRate, LoanTerm, LoanType, LoanStatus)
        {
            carModel = _carModel;
            carValue = _carValue;
        }

        // Constructor overloading
        public void carLoanDetails(string _carModel, int _carValue)
        {
            Console.WriteLine($"CarModel :: {carModel}\t CarValue:: {carValue}");
        }

        public void carLoanDetails(string _carModel, int _carValue, int LoanID)
        {
            Console.WriteLine($"CarModel :: {carModel}\t CarValue:: {carValue} LoanID:: {LoanID}");
        }
    }
}
