using ClassLibraryStructurePatterns.Composite.Enums;

namespace ClassLibraryStructurePatterns.Flyweight
{
    public class LightElementFactory
    {
        private readonly Dictionary<string, LightElementInfo> _flyweights = new Dictionary<string, LightElementInfo>();

        public LightElementInfo GetElementInfo(string tagName, DisplayType display, ClosingType closing)
        {
            string key = $"{tagName}_{display}_{closing}";

            if (!_flyweights.ContainsKey(key))
            {
                _flyweights[key] = new LightElementInfo(tagName, display, closing);
            }

            return _flyweights[key];
        }
    }
}
