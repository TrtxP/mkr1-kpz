namespace ClassLibraryBehavioralPatterns.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
