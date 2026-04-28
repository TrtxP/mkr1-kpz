using ClassLibraryStructurePatterns.Composite.Enums;
using System.Text;

namespace ClassLibraryStructurePatterns.Composite.Classes
{
    public class LightElementNode : LightNode
    {
        protected string _tagName;
        private DisplayType _displayType;
        private ClosingType _closingType;
        private List<string> _cssClasses = new List<string>();
        internal List<LightNode> _children = new List<LightNode>();

        private IState _state = new NormalState();

        public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType)
        {
            _tagName = tagName;
            _displayType = displayType;
            _closingType = closingType;
        }

        public void SetState(IState state)
        {
            _state = state;
        }

        protected override string PerformRender()
        {
            OnBeforeRender();
            string result = _state.Render(this);
            OnAfterRender();
            return result;
        }

        public override string InnerHTML()
        {
            StringBuilder htmlBuilder = new StringBuilder();

            foreach (var htmlElementChild in _children)
            {
                htmlBuilder.Append(htmlElementChild.OuterHTML());
            }

            return htmlBuilder.ToString();
        }

        public override string OuterHTML()
        {
            StringBuilder result = new StringBuilder();

            if (_displayType == DisplayType.Block)
            {
                result.Append(Environment.NewLine);
            }

            result.Append($"<{_tagName}");

            if (_cssClasses.Any())
            {
                result.Append($" class=\"{string.Join(" ", _cssClasses)}\"");
            }

            result.Append(">");

            if (_closingType == ClosingType.Normal)
            {
                result.Append(InnerHTML());
                result.Append($"</{_tagName}>");
            }

            return result.ToString();
        }

        public void ClassName(string className)
        {
            if (!string.IsNullOrWhiteSpace(className))
            {
                _cssClasses.Add(className);
            }
        }

        public void RemoveClassName(string className)
        {
            if (!string.IsNullOrWhiteSpace(className))
            {
                _cssClasses.Remove(className);
            }
        }

        public void TextContent(LightTextNode textNode)
        {
            if (textNode != null)
            {
                _children.Add(textNode);
            }
        }

        public void AppendChild(LightElementNode elementNode)
        {
            if (elementNode != null)
            {
                _children.Add(elementNode);
            }
        }

        public void RemoveChild(LightElementNode elementNode)
        {
            if (elementNode != null)
            {
                _children.Remove(elementNode);
            }
        }

        public void Click()
        {
            DispatchEvent("click");
        }

        public void MouseOver()
        {
            DispatchEvent("mouseover");
        }

        protected void OnBeforeRender()
        {
            Console.WriteLine($"[Lifesycle] Початок рендерингу елемента <{_tagName}>");
        }

        protected void OnAfterRender()
        {
            Console.WriteLine($"[Lifesycle] Завершення рендерингу елемента <{_tagName}>");
        }

        protected override void OnCreated()
        {
            Console.WriteLine($"[Lifesycle] Елемент <{_tagName}> створено");
        }

        protected override void OnInserted()
        {
            Console.WriteLine($"[Lifesycle] Елемент <{_tagName}> вставлено в DOM");
        }

        protected override void OnRemoved()
        {
            Console.WriteLine($"[Lifesycle] Елемент <{_tagName}> видалено з DOM");
        }

        protected override void OnStylesApplied()
        {
            Console.WriteLine($"[Lifesycle] Стилі застосовано до елемента <{_tagName}>");
        }

        protected override void OnClassListApplied()
        {
            Console.WriteLine($"[Lifesycle] Класи застосовано до елемента <{_tagName}>");
        }

        protected override void OnTextRendered()
        {
            Console.WriteLine($"[Lifesycle] Текст рендерено для елемента <{_tagName}>");
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitElement(this);
            foreach (var child in _children)
            {
                child.Accept(visitor);
            }
        }
    }
}
