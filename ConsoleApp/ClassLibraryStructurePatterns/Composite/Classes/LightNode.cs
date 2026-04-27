using ClassLibraryBehavioralPatterns.Iterator;
using ClassLibraryBehavioralPatterns.Observer;

namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public abstract class LightNode : EventTarget, IIterable<LightNode>
    {
        public abstract string InnerHTML();
        public abstract string OuterHTML();

        public IHTMLIterator<LightNode> CreateIterator(TraversalIterator traversal)
        {
            return traversal == TraversalIterator.DepthFirst ? new LightNodeDFS(this) : new LightNodeBFS(this);
        }

        public IHTMLIterator<LightNode> CreateIterator() => CreateIterator(TraversalIterator.DepthFirst);
    }
}
