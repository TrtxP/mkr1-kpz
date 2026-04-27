namespace ClassLibraryBehavioralPatterns.Iterator
{
    public interface IIterable<T>
    {
        IHTMLIterator<T> CreateIterator();
    }
}
