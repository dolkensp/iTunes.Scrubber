using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace iTunes.Scrubber.Helpers
{
    public static class Extensions
    {
        public static T Clone<T>(this T source, T destination = null) where T : class
        {
            if (destination == null)
                destination = default(T);

            foreach (PropertyInfo prop in source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
                if (prop.CanRead && prop.CanWrite)
                    prop.SetValue(destination, prop.GetValue(source, null), null);

            foreach (FieldInfo field in source.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
                field.SetValue(destination, field.GetValue(source));

            return destination;
        }
    }
}