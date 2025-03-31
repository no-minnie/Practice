namespace Task3
{
    public class TransferMoneyCommand : ICommand
    {
        private readonly BankAccountService _receiver;
        private readonly decimal _amount;
        private readonly string _fromAccount;
        private readonly string _toAccount;

        public TransferMoneyCommand(BankAccountService receiver, decimal amount, string fromAccount, string toAccount)
        {
            _receiver = receiver;
            _amount = amount;
            _fromAccount = fromAccount;
            _toAccount = toAccount;
        }

        public void Execute()
        {
            _receiver.Transfer(_amount, _fromAccount, _toAccount);
        }
    }
}