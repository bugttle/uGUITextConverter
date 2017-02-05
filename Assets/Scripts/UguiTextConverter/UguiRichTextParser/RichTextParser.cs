using UguiTextConverter.UguiRichTextParser.Nodes;
using UguiTextConverter.UguiRichTextParser.Nodes.Tags;

namespace UguiTextConverter.UguiRichTextParser
{
    public class RichTextParser
    {
        string m_Text;
        int m_TextLength;
        int m_Index;

        RichTextNode m_RootNode;

        public RichTextParser(string text)
        {
            m_Text = text;
            m_TextLength = text.Length;
            m_Index = 0;
            m_RootNode = new RichTextNode();
            Parse();
        }

        public override string ToString()
        {
            return m_RootNode.ToString();
        }

        public string ToHtmlString()
        {
            return m_RootNode.ToHtmlString();
        }

        void Parse()
        {
            var parent = m_RootNode;
            while (m_Index < m_TextLength)
            {
                if (m_Text[m_Index] == '<')
                {
                    var tag = ParseTag(parent);
                    if (tag != null)
                    {
                        // 開始タグ
                        parent = tag;
                    }
                    else
                    {
                        // 終了タグ
                        parent = parent.Parent;
                    }
                }
                else
                {
                    ParseText(parent);
                }
            }
        }

        void ParseText(RichTextNode parent)
        {
            var node = new PureTextNode(parent);
            parent.ChildNodes.Add(node);

            string text = "";
            while (m_Index < m_TextLength)
            {
                if (m_Text[m_Index] == '<')
                {
                    node.Text = text;
                    break;
                }
                text += m_Text[m_Index++];
            }
        }

        TagNode ParseTag(RichTextNode parent)
        {
            m_Index++;
            if (m_Text[m_Index] == '/')
            {
                // 終了タグ
                m_Index++;
                ParseEndTag((TagNode)parent);
                return null;
            }
            else
            {
                // 開始タグ
                var node = ParseStartTag(parent);
                if (node != null)
                {
                    parent.ChildNodes.Add(node);
                }
                return node;
            }
        }

        TagNode ParseStartTag(RichTextNode parent)
        {
            TagNode node = null;

            string tag = null;
            while (m_Index < m_TextLength)
            {
                if (m_Text[m_Index] == '>')
                {
                    // Attribute無し
                    m_Index++;
                    if (tag.ToLower() == TagTypes.B.ToString().ToLower())
                    {
                        node = new BoldTagNode(parent);
                    }
                    else if (tag.ToLower() == TagTypes.I.ToString().ToLower())
                    {
                        node = new ItalicTagNode(parent);
                    }
                    return node;
                }
                else if (m_Text[m_Index] == '=')
                {
                    // Attributeあり
                    m_Index++;
                    var attribute = ParseTagAttribute();
                    if (tag.ToLower() == TagTypes.Color.ToString().ToLower())
                    {
                        node = new ColorTagNode(parent, attribute);
                    }
                    else if (tag.ToLower() == TagTypes.Size.ToString().ToLower())
                    {
                        var size = 0;
                        if (int.TryParse(attribute, out size))
                        {
                            node = new SizeTagNode(parent, size);
                        }
                        else
                        {
                            throw new RichTextException("size attribute exception: size=" + attribute);
                        }
                    }
                    return node;
                }
                tag += m_Text[m_Index++];
            }

            // 最後までパースした
            throw new RichTextException();
        }

        string ParseTagAttribute()
        {
            string attribute = null;
            bool hasQuarto = false;
            bool hasDoubleQuarto = false;

            if (m_Text[m_Index] == '\'')
            {
                hasQuarto = true;
                m_Index++;
            }
            else
            if (m_Text[m_Index] == '"')
            {
                hasDoubleQuarto = true;
                m_Index++;
            }

            while (m_Index < m_TextLength)
            {
                if (hasQuarto && m_Text[m_Index] == '\'' && m_Text[m_Index + 1] == '>')
                {
                    m_Index += 2;
                    return attribute;
                }
                else if (hasDoubleQuarto && m_Text[m_Index] == '"' && m_Text[m_Index + 1] == '>')
                {
                    m_Index += 2;
                    return attribute;
                }
                else if (m_Text[m_Index] == '>')
                {
                    m_Index++;
                    return attribute;
                }

                attribute += m_Text[m_Index++];
            }

            // 最後までパースした
            throw new RichTextException();
        }

        void ParseEndTag(TagNode startTag)
        {
            string tag = "";
            while (m_Index < m_TextLength)
            {
                if (m_Text[m_Index] == '>')
                {
                    if (tag.ToLower() == startTag.TagType.ToString().ToLower())
                    {
                        m_Index++;
                        break;
                    }
                    else
                    {
                        // タグが正しく閉じられていない
                        throw new RichTextException("Tag mismatch exception: start tag=" + startTag.TagType + ", end tag=" + tag);
                    }
                }
                tag += m_Text[m_Index++];
            }
        }
    }
}
