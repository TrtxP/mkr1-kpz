namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public interface IVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode text);
    }
}
