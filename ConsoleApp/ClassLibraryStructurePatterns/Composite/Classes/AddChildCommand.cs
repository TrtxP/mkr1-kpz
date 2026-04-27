namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class AddChildCommand
    {
        private readonly LightElementNode _parentNode;
        private readonly LightNode _childNode;
        public AddChildCommand(LightElementNode parentNode, LightNode childNode)
        {
            _parentNode = parentNode;
            _childNode = childNode;
        }
        public void Execute()
        {
            _parentNode.AppendChild((LightElementNode)_childNode);
        }
        public void Undo()
        {
            _parentNode.RemoveChild((LightElementNode)_childNode);
        }
    }
}
