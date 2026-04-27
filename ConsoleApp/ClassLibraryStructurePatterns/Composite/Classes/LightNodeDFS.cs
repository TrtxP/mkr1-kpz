namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class LightNodeDFS : LightNodeIterator
    {
        private Stack<LightNode> _stack;
        public LightNodeDFS(LightNode node)
        {
            _stack = new Stack<LightNode>();
            _stack.Push(node);
        }

        public override LightNode GetNext()
        {
            if (_stack.Count == 0)
            {
                return null;
            }
            var node = _stack.Pop();
            if (node is LightElementNode element)
            {
                for (int i = element._children.Count - 1; i >= 0; i--)
                {
                    _stack.Push(element._children[i]);
                }
            }
            return node;
        }

        public override bool HasMore()
        {
            return _stack.Count > 0;
        }
    }
}
