using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Patterns.Builder
{
    public class BuilderPattern
    {
        public BuilderPattern()
        {
            DefaultMethod();
            BetterMethod();
        }

        public void DefaultMethod()
        {
            var hello = "Hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);
        }

        public void BetterMethod()
        {
            var builder = new HtmlBuilder("ul");
            // fluent interface
            builder.AddChild("li", "hello")
                .AddChild("li", "world");
            Console.WriteLine(builder);
        }
    }

    public class HtmlBuilder
    {
        public readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            rootName = rootName.Trim();
            root.Name = rootName;
        }

        public HtmlBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }

        public class HtmlElement
        {
            public string Name, Text;
            public List<HtmlElement> Elements = new List<HtmlElement>();
            public const int indentSize = 2;

            public HtmlElement()
            {

            }

            public HtmlElement(string name, string text)
            {
                Name = name;
                Text = text;
            }

            private string ToStringImp(int indent)
            {
                var sb = new StringBuilder();
                var i = new string(' ', indentSize * indent);
                sb.AppendLine($"{i}<{Name}>");
                if (!string.IsNullOrEmpty(Text))
                {
                    sb.Append(new string(' ', indentSize * (indent + 1)));
                    sb.AppendLine(Text);
                }
                foreach (var element in Elements)
                {
                    sb.Append(element.ToStringImp(indent + 1));
                }
                sb.AppendLine($"{i}</{Name}>");
                return sb.ToString();
            }

            public override string ToString()
            {
                return ToStringImp(0);
            }
        }

    }
}