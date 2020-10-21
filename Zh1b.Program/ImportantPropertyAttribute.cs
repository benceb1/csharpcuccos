using System;
using System.Collections.Generic;
using System.Text;

namespace Zh1b.Program
{
    [AttributeUsage(AttributeTargets.Property)]
    class ImportantPropertyAttribute: Attribute
    {
        public string Reason { get; }
        public ImportantPropertyAttribute(string reason)
        {
            Reason = reason;
        }
    }
}
