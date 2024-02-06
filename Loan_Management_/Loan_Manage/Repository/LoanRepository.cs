using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan_Manage.Model;
using Loan_Manage.Repository;
using System.Data.SqlClient;
using Loan_Manage.Utility;
using Loan_Manage.Exception;
using System.Diagnostics.Metrics;

namespace Loan_Manage.Repository
{
    internal class LoanRepository:ILoanRepository
    {

        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public LoanRepository()
        {
            sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        private bool IsLoanExists(int Id)
        {

            SqlConnection sqlconnection = new SqlConnection(DbConnUtil.GetConnectionString()); ;
            SqlCommand cmd = new SqlCommand(); ;
            cmd.CommandText = "select * from Loan where LoanID = @Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            object obj = cmd.ExecuteScalar();
            return obj != null;
        }
        public int applyLoan(Loan loan)
        {
            cmd.CommandText = "insert into Loan values(@LoanID,@CustomerID,@PrincipalAmount,@InterestRate,@LoanTerm,@LoanType,@LoanStatus)";
            cmd.Parameters.AddWithValue("@LoanID", loan.LoanID);
            cmd.Parameters.AddWithValue("@CustomerID", loan.CustomerID);
            cmd.Parameters.AddWithValue("@PrincipalAmount", loan.PrincipalAmount);
            cmd.Parameters.AddWithValue("@InterestRate", loan.InterestRate);
            cmd.Parameters.AddWithValue("@LoanTerm", loan.LoanTerm);
            cmd.Parameters.AddWithValue("@LoanType", loan.LoanType);
            cmd.Parameters.AddWithValue("@LoanStatus", loan.LoanStatus);
            
            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            int addUserStatus = cmd.ExecuteNonQuery();
            sqlconnection.Close();
            cmd.Parameters.Clear();
            

            return addUserStatus;
        }
        public int calculateInterest(int Id)
        {
            try
            {
                if(!IsLoanExists(Id))
                {
                    throw new InvalidLoanException($"No Loan record found for id-{Id}");
                }

                cmd.CommandText = "select * from Loan where LoanID = @Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Loan loan = new Loan();

                while (reader.Read())
                {
                    loan.LoanID = (int)reader["LoanID"];
                    loan.CustomerID = (int)reader["CustomerID"];
                    loan.PrincipalAmount = (int)reader["PrincipalAmount"];
                    loan.InterestRate = (int)reader["InterestRate"];
                    loan.LoanTerm = (int)reader["LoanTerm"];
                    loan.LoanType = (string)reader["LoanType"];
                    loan.LoanStatus = (string)reader["LoanStatus"];

                }
                sqlconnection.Close();

                int interestAmount = (loan.PrincipalAmount * loan.InterestRate * loan.LoanTerm) / 12;
                return interestAmount;
            }
            catch(InvalidLoanException ex)
            {
                Console.WriteLine($"error occured : {ex.Message}");
            }

            return -1;
        } 


        public void loanStatus(int Id)
        {
            cmd.CommandText = "select Customer.creditScore, Loan.LoanStatus from Loan INNER JOIN Customer ON Loan.CustomerID = Customer.CustomerID where Loan.LoanID=@Id";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Loan loan = new Loan();
            Customer customer = new Customer();

            while (reader.Read())
            {
                loan.LoanStatus = (string)reader["LoanStatus"];
                customer.creditScore = (int)reader["creditScore"];

            }
            sqlconnection.Close();

            if (customer.creditScore > 650)
            {
                Console.WriteLine("The loan is approved");
                loan.LoanStatus = "Approved";
            }
            else if(customer.creditScore <= 650)
            {
                Console.WriteLine("The loan is Rejected");
                loan.LoanStatus = "Rejected";
            }

        }

        public long calculateEMI(int Id)
        {
            try
            {
                if (!IsLoanExists(Id))
                {
                    throw new InvalidLoanException($"No Loan record found for id-{Id}");
                }

                cmd.CommandText = "select * from Loan where LoanID = @Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Loan loan = new Loan();

                while (reader.Read())
                {
                    loan.LoanID = (int)reader["LoanID"];
                    loan.CustomerID = (int)reader["CustomerID"];
                    loan.PrincipalAmount = (int)reader["PrincipalAmount"];
                    loan.InterestRate = (int)reader["InterestRate"];
                    loan.LoanTerm = (int)reader["LoanTerm"];
                    loan.LoanType = (string)reader["LoanType"];
                    loan.LoanStatus = (string)reader["LoanStatus"];

                }
                sqlconnection.Close();

                int p = loan.PrincipalAmount;
                int r = (loan.InterestRate % 12);
                int n = loan.LoanTerm;

                long b = (long)Math.Pow((1 + r), n);

                //Console.WriteLine(p); 
                //Console.WriteLine(r); 
                //Console.WriteLine(n); 
                //Console.WriteLine(b); 

                long emiAmount = (p * r * b) / (b - 1);
                //Console.WriteLine(emiAmount);
                return emiAmount;
            }
            catch(InvalidLoanException ex)
            {
                Console.WriteLine($"error occured : {ex.Message}");
            }

            return -1;
        }


        public long loanRepayment(int Id, int Amount)
        {
            cmd.CommandText = "select * from Loan where LoanID = @Id and PrincipalAmount = @Amount";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Loan loan = new Loan();

            while (reader.Read())
            {
                loan.LoanID = (int)reader["LoanID"];
                loan.CustomerID = (int)reader["CustomerID"];
                loan.PrincipalAmount = (int)reader["PrincipalAmount"];
                loan.InterestRate = (int)reader["InterestRate"];
                loan.LoanTerm = (int)reader["LoanTerm"];
                loan.LoanType = (string)reader["LoanType"];
                loan.LoanStatus = (string)reader["LoanStatus"];

            }
            sqlconnection.Close();
            cmd.Parameters.Clear();

            long interestAmount = calculateEMI(Id);
            long months = Amount / interestAmount;
            return months;
        }


        public List<Loan> getAllLoan()
        {
            cmd.CommandText = "select * from Loan";
            cmd.Connection = sqlconnection;
            sqlconnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Loan> loanList = new List<Loan>();

            while (reader.Read())
            {
                Loan loan = new Loan();
                loan.LoanID = (int)reader["LoanID"];
                loan.CustomerID = (int)reader["CustomerID"];
                loan.PrincipalAmount = (int)reader["PrincipalAmount"];
                loan.InterestRate = (int)reader["InterestRate"];
                loan.LoanTerm = (int)reader["LoanTerm"];
                loan.LoanType = (string)reader["LoanType"];
                loan.LoanStatus = (string)reader["LoanStatus"];
                loanList.Add(loan);
            }
            sqlconnection.Close();

            return loanList;
        }


        public Loan getLoanById(int Id)
        {
            try
            {
                if (!IsLoanExists(Id))
                {
                    throw new InvalidLoanException($"No Loan record found for id-{Id}");
                }

                cmd.CommandText = "select * from Loan where LoanID = @Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Loan loan = new Loan();

                while (reader.Read())
                {
                    loan.LoanID = (int)reader["LoanID"];
                    loan.CustomerID = (int)reader["CustomerID"];
                    loan.PrincipalAmount = (int)reader["PrincipalAmount"];
                    loan.InterestRate = (int)reader["InterestRate"];
                    loan.LoanTerm = (int)reader["LoanTerm"];
                    loan.LoanType = (string)reader["LoanType"];
                    loan.LoanStatus = (string)reader["LoanStatus"];

                }
                sqlconnection.Close();
                return loan;
            }
            catch(InvalidLoanException ex)
            {
                Console.WriteLine($"error occured : {ex.Message}");
            }

            return null;
        }
    }
}
