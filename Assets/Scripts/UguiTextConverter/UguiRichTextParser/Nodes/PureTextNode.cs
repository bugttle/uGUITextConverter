namespace UguiTextConverter.UguiRichTextParser.Nodes
{
    public class PureTextNode : RichTextNode
    {
        public string Text;

        public PureTextNode(RichTextNode parent) : base(parent)
        {
            NodeType = NodeTypes.Text;
        }

        public override string ToString()
        {
            return Text + base.ToString();
        }

        public override string ToHtmlString()
        {
            return Text + base.ToHtmlString();
        }
    }
}
