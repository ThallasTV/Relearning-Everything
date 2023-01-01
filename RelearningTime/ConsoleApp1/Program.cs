// See https://aka.ms/new-console-template for more information
using System;
using System.Linq.Expressions;

namespace Classes;

class HelloWorld
{
    static void Main()
    {
        var account = new BankAccount("Big Sid", 20000);
        Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

        account.MakeWithdrawl(750, DateTime.Now, "house payment");
        Console.WriteLine(account.Balance);
        account.MakeDeposit(200, DateTime.Now, "Friend decided to pay me back");
        Console.WriteLine(account.Balance);
        Console.WriteLine(account.GetAccountHistory());

        try
        {
            account.MakeWithdrawl(23000, DateTime.Now, "Attempting a Withdrawl");
        }
        catch(ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught for trying to withdraw");
            Console.WriteLine(e.ToString());
        }

        BankAccount invalidAccount;
        try 
        {
            invalidAccount = new BankAccount("invalid", -438927);
        }
        catch(ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught creating account with negative balance");
            Console.WriteLine(e.ToString());
            return;
        }
    }
}
