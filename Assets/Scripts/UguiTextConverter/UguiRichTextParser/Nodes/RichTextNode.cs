using System.Collections.Generic;

namespace UguiTextConverter.UguiRichTextParser.Nodes
{
    public class RichTextNode
    {
        public NodeTypes NodeType;
        public RichTextNode Parent;
        public List<RichTextNode> ChildNodes = new List<RichTextNode>();

        public RichTextNode(RichTextNode parent = null)
        {
            Parent = parent;
        }

        public override string ToString()
        {
            var str = "";
            foreach (var child in ChildNodes)
            {
                str += child.ToString();
            }
            return str;
        }

        public virtual string ToHtmlString()
        {
            var str = "";
            foreach (var child in ChildNodes)
            {
                str += child.ToHtmlString();
            }
            return str;
        }
    }
}
