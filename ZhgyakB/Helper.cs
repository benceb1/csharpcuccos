using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ZhgyakB
{
    public class Helper
    {
        public static string StringOfImportantProps(object instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            Type type = instance.GetType();

            List<string> stringProperties = new List<string>();

            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.GetCustomAttribute<ImportantPropertyAttribute>() != null)
                {
                    stringProperties.Add(property.GetValue(instance).ToString());
                }
            }
            return String.Join(", ", stringProperties);
        }
    }
}
