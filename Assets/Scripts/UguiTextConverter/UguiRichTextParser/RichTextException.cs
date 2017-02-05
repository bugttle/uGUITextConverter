using System;

namespace UguiTextConverter.UguiRichTextParser
{
    public class RichTextException : SystemException
    {
        public RichTextException() : base()
        {
        }

        public RichTextException(string message) : base(message)
        {
        }

        public RichTextException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
