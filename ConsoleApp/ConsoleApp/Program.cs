using ClassLibraryStructurePatterns.Adapter;
using ClassLibraryStructurePatterns.Bridge.Renderers;
using ClassLibraryStructurePatterns.Bridge.Shapes;
using ClassLibraryStructurePatterns.Composite.Classes;
using ClassLibraryStructurePatterns.Composite.Enums;
using ClassLibraryStructurePatterns.Decorator.Characters;
using ClassLibraryStructurePatterns.Decorator.Inventory;
using ClassLibraryStructurePatterns.Flyweight;
using ClassLibraryStructurePatterns.Proxy;
using BenchmarkDotNet.Running;
using ConsoleApp;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // Демонстрування роботи шаблону адаптер

        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Демонстрація роботи шаблону адаптер");
        Console.WriteLine(new string('-', 50));

        Logger logger = new Logger();
        logger.Log("Це звиччайне повідомлення");
        logger.Error("Це повідомлення про помилку");
        logger.Warn("Це попереджувальне повідомлення");
        Console.WriteLine(new string('-', 30));

        Logger fileLogger = new FileLogger("C:\\" +
                                                    "Users\\Ilya\\Desktop\\" +
                                                    "Предмети з Житомирської політехи\\" +
                                                    "Конструювання ПЗ\\lab3\\ConsoleApp\\" +
                                                    "ConsoleApp\\FileWritingTesting\\logs.txt");

        // Відображаємо записані дані у файлі

        Console.WriteLine("Записані дані у файлі logs.txt:");
        fileLogger.Log("Звичайне повідомлення");
        fileLogger.Error("Повідомлення про помилку");
        fileLogger.Warn("Попереджувальне повідомлення");
        Console.WriteLine(new string('-', 50));

        // Демонстрування роботи шаблону декоратор

        Console.WriteLine("Демонстрування роботи шаблону декоратор");

        Console.WriteLine(new string('-', 50));

        ICharacter mage = new Mage();
        mage = new Clothing(mage);
        mage = new Clothing(mage);
        mage = new Artefact(mage);
        mage = new Artefact(mage);
        Console.WriteLine(mage.GetDescription());
        Console.WriteLine($"Атака: {mage.GetAttack()}");
        Console.WriteLine($"Захист: {mage.GetDefence()}");
        Console.WriteLine($"Магія: {mage.GetMagic()}");

        Console.WriteLine();

        ICharacter palladin = new Palladin();
        palladin = new Sword(palladin);
        palladin = new Sword(palladin);
        palladin = new Clothing(palladin);
        palladin = new Artefact(palladin);
        palladin = new Artefact(palladin);
        Console.WriteLine(palladin.GetDescription());
        Console.WriteLine($"Атака: {palladin.GetAttack()}");
        Console.WriteLine($"Захист: {palladin.GetDefence()}");
        Console.WriteLine($"Магія: {palladin.GetMagic()}");

        Console.WriteLine();

        ICharacter warrior = new Warrior();
        warrior = new Sword(warrior);
        warrior = new Sword(warrior);
        warrior = new Clothing(warrior);
        warrior = new Clothing(warrior);
        Console.WriteLine(warrior.GetDescription());
        Console.WriteLine($"Атака: {warrior.GetAttack()}");
        Console.WriteLine($"Захист: {warrior.GetDefence()}");
        Console.WriteLine($"Магія: {warrior.GetMagic()}");

        Console.WriteLine(new string('-', 50));

        // Демонстрування роботи шаблону міст

        Console.WriteLine("Демонстрація роботи шаблону міст");
        Console.WriteLine(new string('-', 50));

        Shape vectorCircle = new Circle(new VectorRenderer());
        vectorCircle.Draw();

        Shape rasterCircle = new Circle(new RasterRender());
        rasterCircle.Draw();

        Shape vectorSquare = new Square(new VectorRenderer());
        vectorSquare.Draw();

        Shape rasterShape = new Square(new RasterRender());
        rasterShape.Draw();

        Shape vectorTriangle = new Triangle(new VectorRenderer());
        vectorTriangle.Draw();

        Shape rasterTriangle = new Triangle(new RasterRender());
        rasterTriangle.Draw();

        Console.WriteLine(new string('-', 50));

        // Демонстрування роботи шаблону проксі

        Console.WriteLine("Демонстрація роботи шаблону проксі");
        Console.WriteLine(new string('-', 50));

        ISmartTextReader reader = new SmartTextReader();

        reader = new SmartTextChecker(reader);

        reader = new SmartTextReaderLocker(reader, @"password");

        Console.WriteLine("File");
        reader.ReadFile("..\\..\\..\\Files\\lorem.txt");

        Console.WriteLine(new string('-', 20));

        Console.WriteLine("Denied file");
        reader.ReadFile("..\\..\\..\\Files\\private_passwords.txt");
        Console.WriteLine(new string('-', 50));
         
        // Демонстрування роботи шаблону компонувальник на прикладі власної розмітки HTML

        Console.WriteLine("Демонстрація роботи шаблону компонувальник\nна прикладі власної розмітки HTML");
        Console.WriteLine(new string('-', 50));

        var div = new LightElementNode("div", DisplayType.Block, ClosingType.Normal);
        div.ClassName("container");
        div.ClassName("main-content");

        var h1 = new LightElementNode("h1", DisplayType.Block, ClosingType.Normal);
        h1.TextContent(new LightTextNode("Моя власна розмітка LightHTML"));

        var hr = new LightElementNode("hr", DisplayType.Block, ClosingType.Single);

        var ul = new LightElementNode("ul", DisplayType.Block, ClosingType.Normal);
        ul.ClassName("list-items");

        for (int i = 1; i <= 3; i++)
        {
            var li = new LightElementNode("li", DisplayType.Block, ClosingType.Normal);
            li.TextContent(new LightTextNode($"Пункт списку №{i}"));
            ul.AppendChild(li);
        }

        div.AppendChild(h1);
        div.AppendChild(hr);
        div.AppendChild(ul);

        Console.WriteLine(div.OuterHTML().Trim());
        Console.WriteLine(new string('-', 50));

        // Демонстрування роботу шаблону легковаговик

        Console.WriteLine("Демонстрація роботи шаблону легковаговик");

        Console.WriteLine(new string('-', 50));

        Console.WriteLine("Конвертування змісту книжки у HTML формат\nз використанням шаблону легковаговик");
        Console.WriteLine(new string('-', 50));

        var client = new HttpClient();
        var url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
        var bookText = client.GetStringAsync(url).Result;

        var factory = new LightElementFactory();
        var root = new LightElementNodeWithInfo(factory.GetElementInfo("div", DisplayType.Block, ClosingType.Normal));

        string[] lines = bookText.Split("\n");

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

        Console.WriteLine(root.OuterHTML().Substring(0, 2003));

        BenchmarkRunner.Run<FlyweightBecnhmark>();

        Console.WriteLine(new string('-', 50));
    }
}