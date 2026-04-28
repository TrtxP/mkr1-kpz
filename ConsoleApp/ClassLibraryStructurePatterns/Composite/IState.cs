using ClassLibraryStructurePatterns.Composite.Classes;

namespace ClassLibraryStructurePatterns.Composite
{
    public interface IState
    {
        string Render(LightElementNode node);
    }
}
