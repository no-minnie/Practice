using Task3;

class Program
{
    static void Main(string[] args)
    {
        BankAccountService bankAccountService = new BankAccountService();

        ICommand transferMoney = new TransferMoneyCommand(bankAccountService, 1000, "1234567890", "9876543210");

        BankingTerminal bankingTerminal = new BankingTerminal();

        bankingTerminal.ExecuteCommand(transferMoney);

        Console.ReadKey();
    }
}