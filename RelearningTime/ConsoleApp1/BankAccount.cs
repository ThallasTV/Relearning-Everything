using System.Globalization;

namespace Classes;

public class BankAccount
{
    private static int accountNumberSeed = 1234567890;
    private List<Transaction> allTransactions = new List<Transaction>();
    public string Number { get; }
    public string Owner { get; }
    public virtual void PerformMonthEndTransactions() { }

    public decimal Balance
    { 
        get
        {
            decimal balance = 0;
            foreach(var item in allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        return report.ToString();
    }

    public void MakeBalance(decimal amount, DateTime date, string note)
    {

    }
    public void MakeWithdrawl(decimal amount, DateTime date, string note)
    {

    }

    public BankAccount(string name, decimal currentBalance)
    {
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;

        Owner = name;
        MakeDeposit(currentBalance, DateTime.Now, "Current Balance");
       
    }

    public void MakeDeposit(decimal amount, DateTime date, string note) 
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount),"The deposit should be positive stupid!");
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void makeWithdrawl(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "The Withdrawl should be positive stupid!");
        var withdrawl = new Transaction(amount, date, note);
        allTransactions.Add(withdrawl);
    }
}