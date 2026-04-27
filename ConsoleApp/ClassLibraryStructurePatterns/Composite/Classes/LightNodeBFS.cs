namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class LightNodeBFS : LightNodeIterator
    {
        private Queue<LightNode> _queue;
        public LightNodeBFS(LightNode node)
        {
            _queue = new Queue<LightNode>();
            _queue.Enqueue(node);
        }

        public override LightNode GetNext()
        {
            if (_queue.Count == 0)
            {
                return null;
            }
            var node = _queue.Dequeue();
            if (node is LightElementNode element)
            {
                foreach (var child in element._children)
                {
                    _queue.Enqueue(child);
                }
            }
            return node;
        }

        public override bool HasMore()
        {
            return _queue.Count > 0;
        }
    }
}