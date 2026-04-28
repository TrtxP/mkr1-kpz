namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class HiddenState : IState
    {
        public string Render(LightElementNode node)
        {
            return string.Empty;
        }
    }
}
