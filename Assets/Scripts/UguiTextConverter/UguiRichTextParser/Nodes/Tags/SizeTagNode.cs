namespace UguiTextConverter.UguiRichTextParser.Nodes.Tags
{
    public class SizeTagNode : TagNode
    {
        public int Size;

        public SizeTagNode(RichTextNode parent, int size) : base(parent)
        {
            TagType = TagTypes.Size;

            Size = size;
        }

        public override string ToString()
        {
            return "<size=" + Size + ">" + base.ToString() + "</size>";
        }

        public override string ToHtmlString()
        {
            return "<font size=\"" + Size + "\">" + base.ToHtmlString() + "</font>";
        }
    }
}
