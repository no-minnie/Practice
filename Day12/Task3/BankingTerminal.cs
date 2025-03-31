namespace Task3
{
    public class BankingTerminal
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}