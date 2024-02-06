using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan_Manage.Model;
using Loan_Manage.Repository;

namespace Loan_Manage.Service
{
    internal class LoanService:ILoanService
    {
        readonly ILoanRepository _loanrepository; 

        public LoanService()
        {
            _loanrepository = new LoanRepository();
        }

        public void applyLoan()
        {
            Console.WriteLine("Do you want to apply for loan");
            string ans = Console.ReadLine();

            if(ans == "Yes")
            {
                Loan loan = new Loan();

                Console.WriteLine("Enter loan id :");
                loan.LoanID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Customer id :");
                loan.CustomerID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter principal amount :");
                loan.PrincipalAmount = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter rate of interest :");
                loan.InterestRate = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter term of loan:");
                loan.LoanTerm = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter type of loan :");
                loan.LoanType = (Console.ReadLine());

                loan.LoanStatus = "Pending";

                int status = _loanrepository.applyLoan(loan);
                if(status >0)
                {
                    Console.WriteLine("Loan added successfully");
                }
                else
                {
                    Console.WriteLine("Loan not added");
                }
            }
            else
            {
                Console.WriteLine("Thanks for visiting system");
            }
        }

        public void calculateInterest()
        {
            Console.WriteLine("Enter id of the loan");
            int Id = int.Parse(Console.ReadLine());

            int interestAmount = _loanrepository.calculateInterest(Id);
            if(interestAmount > -1)
            {
                Console.WriteLine($"Interset Amount : {interestAmount}");
            }
            
        } 


        public void loanStatus()
        {
            Console.WriteLine("Enter id of the loan");
            int Id = int.Parse(Console.ReadLine());

            _loanrepository.loanStatus(Id);
            
        }

        public void calculateEMI()
        {
            Console.WriteLine("Enter id of the loan");
            int Id = int.Parse(Console.ReadLine());

            long emiAmount = _loanrepository.calculateEMI(Id);
            if (emiAmount > -1)
            {
                Console.WriteLine($"EMI Amount : {emiAmount / 12}");
            }
            
        } 


        public void loanRepayment()
        {
            Console.WriteLine("Enter id of the loan");
            int Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter amount of the loan");
            int Amount = int.Parse(Console.ReadLine());

            long months = _loanrepository.loanRepayment(Id, Amount);
            if(months <= 0)
            {
                Console.WriteLine("Payment failed");
            }
            if (months > 0)
            {
                Console.WriteLine("Payment done successfully");
            }
        }


        public void getAllLoan()
        {
            List<Loan> loanList = new List<Loan>();
            loanList = _loanrepository.getAllLoan();

            foreach(var loan in loanList )
            {
                Console.WriteLine(loan);
            }
        }

        public void getLoanById()
        {
            Console.WriteLine("Enter id of loan:");
            int Id = int.Parse(Console.ReadLine());

            Loan loan = _loanrepository.getLoanById(Id);
            if(loan != null)
            {
                Console.WriteLine(loan);
            }
            
        }
    }
}
