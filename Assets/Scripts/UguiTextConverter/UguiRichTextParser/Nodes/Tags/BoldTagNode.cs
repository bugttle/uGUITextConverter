namespace UguiTextConverter.UguiRichTextParser.Nodes.Tags
{
    public class BoldTagNode : TagNode
    {
        public BoldTagNode(RichTextNode parent) : base(parent)
        {
            TagType = TagTypes.B;
        }

        public override string ToString()
        {
            return "<b>" + base.ToString() + "</b>";
        }

        public override string ToHtmlString()
        {
            return "<b>" + base.ToHtmlString() + "</b>";
        }
    }
}
