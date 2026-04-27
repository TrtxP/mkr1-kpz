using ClassLibraryBehavioralPatterns.Iterator;

namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public abstract class LightNodeIterator : IHTMLIterator<LightNode>
    {
        public abstract LightNode GetNext();

        public abstract bool HasMore();
    }
}
