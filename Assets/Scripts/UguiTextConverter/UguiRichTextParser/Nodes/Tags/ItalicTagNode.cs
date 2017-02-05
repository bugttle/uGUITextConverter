namespace UguiTextConverter.UguiRichTextParser.Nodes.Tags
{
    public class ItalicTagNode : TagNode
    {
        public ItalicTagNode(RichTextNode parent) : base(parent)
        {
            TagType = TagTypes.I;
        }

        public override string ToString()
        {
            return "<i>" + base.ToString() + "</i>";
        }

        public override string ToHtmlString()
        {
            return "<i>" + base.ToHtmlString() + "</i>";
        }
    }
}
