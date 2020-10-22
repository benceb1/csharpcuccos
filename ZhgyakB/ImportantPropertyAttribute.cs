using System;
using System.Collections.Generic;
using System.Text;

namespace ZhgyakB
{
    [AttributeUsage(AttributeTargets.Property)]
    class ImportantPropertyAttribute : Attribute
    {
        public string Reason { get; set; }

        public ImportantPropertyAttribute(string reason)
        {
            Reason = reason;
        }
    }
}
