namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class NormalState : IState
    {
        public string Render(LightElementNode node)
        {
            return node.OuterHTML();
        }
    }
}
