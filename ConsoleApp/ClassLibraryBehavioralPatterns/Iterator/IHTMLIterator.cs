namespace ClassLibraryBehavioralPatterns.Iterator
{
    public interface IHTMLIterator<T>
    {
        T GetNext();
        bool HasMore();
    }
}
