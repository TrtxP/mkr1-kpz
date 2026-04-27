using ClassLibraryBehavioralPatterns.Command;

namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode _node;
        private readonly string _className;

        public AddClassCommand(LightElementNode node, string className)
        {
            _node = node;
            _className = className;
        }

        public void Execute()
        {
            _node.ClassName(_className);
        }

        public void Undo()
        {
            _node.RemoveClassName(_className);
        }
    }
}
