namespace UguiTextConverter.UguiRichTextParser.Nodes.Tags
{
    public class ColorTagNode : TagNode
    {
        public string Color;

        public ColorTagNode(RichTextNode parent, string color) : base(parent)
        {
            TagType = TagTypes.Color;
            Color = color;
        }

        public override string ToString()
        {
            return "<color=" + Color + ">" + base.ToString() + "</color>";
        }

        public override string ToHtmlString()
        {
            return "<font color=\"" + Color + "\">" + base.ToHtmlString() + "</font>";
        }
    }
}
