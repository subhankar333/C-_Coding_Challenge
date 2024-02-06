using Loan_Manage.Service;

namespace Loan_Manage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("----Welcome to Loan Management System-----\n");
            Console.WriteLine("Enter key to get details.\n");

            Console.WriteLine("1--> ApplyLoan");
            Console.WriteLine("2--> CalculateInterest");
            Console.WriteLine("3--> LoanStatus");
            Console.WriteLine("4--> CalculateEMI");
            Console.WriteLine("5--> LoanRepayment");
            Console.WriteLine("6--> GetAllLoan");
            Console.WriteLine("7--> GetLoanById");
            Console.WriteLine("8--> Exit");

            int key = int.Parse(Console.ReadLine());
            ILoanService _loanService = new LoanService();

            switch (key)
            {
                case 1:
                    _loanService.applyLoan();
                     break;
                case 2:
                    _loanService.calculateInterest();
                    break;
                case 3:
                    _loanService.loanStatus();
                    break;
                case 4:
                    _loanService.calculateEMI();
                    break;
                case 5:
                    _loanService.loanRepayment();
                    break;
                case 6:
                    _loanService.getAllLoan();
                    break;
                case 7:
                    _loanService.getLoanById();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You entered a wrong key");
                    break;

            }
        }
    }
}
