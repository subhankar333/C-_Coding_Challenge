using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Manage.Model
{
    internal class Customer
    {
        public int CustomerID {  get; set; }
        public string Name {  get; set; }
        public string Email {  get; set; }
        public string Phone_Number {  get; set; }
        public string Address {  get; set; }
        public int creditScore {  get; set; }

        public Customer()
        {

        }
        public override string ToString()
        {
            return $"CustomerID:: {CustomerID}\t Name:: {Name}\t Email:: {Email}\t Phone_Number:: {Phone_Number} Address:: {Address}\t creditScore:: {creditScore}";
        }
    }
}
