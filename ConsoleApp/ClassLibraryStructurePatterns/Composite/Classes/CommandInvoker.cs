using ClassLibraryBehavioralPatterns.Command;
namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class CommandInvoker
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void UndoCommand()
        {
            if (_history.Count > 0)
            {
                var command = _history.Pop();
                command.Undo();
            }
        }
    }
}
