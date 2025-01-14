namespace MassTransit.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class TextWriterLoggerOptions
    {
        readonly List<string> _disabled;

        public TextWriterLoggerOptions()
        {
            _disabled = new List<string>();
        }

        public TextWriterLoggerOptions Disable(string name)
        {
            _disabled.Add(name);

            return this;
        }

        public bool IsEnabled(string name)
        {
            return !_disabled.Any(x => name.StartsWith(x, StringComparison.OrdinalIgnoreCase));
        }
    }
}
