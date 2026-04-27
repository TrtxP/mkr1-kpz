using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using ClassLibraryStructurePatterns.Composite.Classes;
using ClassLibraryStructurePatterns.Composite.Enums;
using ClassLibraryStructurePatterns.Flyweight;

namespace ConsoleApp
{
    [MemoryDiagnoser]
    [GcServer(true)]
    public class FlyweightBecnhmark
    {
        private string? bookText;
        [GlobalSetup]
        public void Setup()
        {
            var client = new HttpClient();
            var url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
            bookText = client.GetStringAsync(url).Result;
        }

        [Benchmark]
        public void WithoutFlyweight()
        { 

            var factory = new LightElementFactory();

            var root = new LightElementNode("div", DisplayType.Block, ClosingType.Normal);

            string[] lines = bookText!.Split("\n");

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrEmpty(line)) continue;

                LightElementNode node;

                if (i == 0)
                {
                    node = new LightElementNode("h1", DisplayType.Block, ClosingType.Normal);
                }
                else if (line.Length < 20)
                {
                    node = new LightElementNode("h2", DisplayType.Block, ClosingType.Normal);
                }
                else if (char.IsWhiteSpace(lines[i][0]))
                {
                    node = new LightElementNode("blockquote", DisplayType.Block, ClosingType.Normal);
                }
                else
                {
                    node = new LightElementNode("p", DisplayType.Block, ClosingType.Normal);
                }

                node.TextContent(new LightTextNode(line));
                root.AppendChild(node);
            }
        }

        [Benchmark]
        public void WithFlyweight()
        {
            var factory = new LightElementFactory();
            var root = new LightElementNodeWithInfo(factory.GetElementInfo("div", DisplayType.Block, ClosingType.Normal));

            string[] lines = bookText!.Split("\n");

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrEmpty(line)) continue;

                LightElementNodeWithInfo node;

                if (i == 0)
                {
                    node = new LightElementNodeWithInfo(factory.GetElementInfo("h1", DisplayType.Block, ClosingType.Normal));
                }
                else if (line.Length < 20)
                {
                    node = new LightElementNodeWithInfo(factory.GetElementInfo("h2", DisplayType.Block, ClosingType.Normal));
                }
                else if (char.IsWhiteSpace(lines[i][0]))
                {
                    node = new LightElementNodeWithInfo(factory.GetElementInfo("blockquote", DisplayType.Block, ClosingType.Normal));
                }
                else
                {
                    node = new LightElementNodeWithInfo(factory.GetElementInfo("p", DisplayType.Block, ClosingType.Normal));
                }

                node.TextContent(new LightTextNode(line));
                root.AppendChild(node);
            }
        }
    }
}
