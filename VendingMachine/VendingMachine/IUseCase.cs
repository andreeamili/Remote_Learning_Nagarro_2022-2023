namespace iQuest.VendingMachine
{
    internal interface IUseCase
    {
       public string Name { get; }
        public string Description { get; }
        public bool CanExecute { get; }
        public void Execute();
    }
}