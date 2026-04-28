using ClassLibraryStructurePatterns.Composite.Classes;

namespace ClassLibraryStructurePatterns.Composite
{
    public interface IVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode text);
    }
}
