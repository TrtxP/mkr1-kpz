namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class ElementCounterVisitor : IVisitor
    {
        public int ElementCount { get; private set; } = 0;
        public int TextCount { get; private set; } = 0;

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
        }

        public void VisitText(LightTextNode text)
        {
            TextCount++;
        }
    }
}
