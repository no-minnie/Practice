namespace Task3
{
    using System;

    public class BankAccountService
    {
        public void Transfer(decimal amount, string fromAccount, string toAccount)
        {
            Console.WriteLine($"Перевод {amount} со счета {fromAccount} на счет {toAccount}");
        }
    }
}