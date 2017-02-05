using System.Collections.Generic;

namespace UguiTextConverter.UguiRichTextParser.Nodes.Tags
{
    public class TagNode : RichTextNode
    {
        public TagTypes TagType;

        public TagNode(RichTextNode parent) : base(parent)
        {
            NodeType = NodeTypes.Tag;
        }
    }
}
