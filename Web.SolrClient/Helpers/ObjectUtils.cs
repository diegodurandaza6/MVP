using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Web.SolrClient.Helpers
{
    public enum FieldTypes
    {
        Properties,
        PropertiesAndFields,
        Fields,
    }

    public static class ObjectUtils
    {
        public static T CreateIfNull<T>(this T source)
            where T : class, new()
        {
            if (source == null)
                source = new T();
            return source;
        }


        public static void SetPropertyValue<T>(this T target, Expression<Func<T, object>> memberLamda, object value)
        {
            var memberSelectorExpression = memberLamda.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(target, value, null);
                }
            }
        }

        public static T GetTypeDefaultValue<T>(this T value)
        {
            return default(T);
        }


        public static bool IsNull<T>(this T obj) where T : class
        {
            return (obj == null);
        }

        public static bool IsNotNull<T>(this T obj) where T : class
        {
            return !IsNull(obj);
        }

        public static string ObjectToString(object instanc, string separator = " , ", FieldTypes type = FieldTypes.PropertiesAndFields)
        {
            FieldInfo[] fields = instanc.GetType().GetFields();
            string str = string.Empty;
            if (type == FieldTypes.Properties || type == FieldTypes.PropertiesAndFields)
            {
                foreach (PropertyInfo propertyInfo in instanc.GetType().GetProperties())
                {
                    try
                    {
                        str = str + propertyInfo.Name + ":" + propertyInfo.GetValue(instanc, (object[])null).ToString() + separator;
                    }
                    catch
                    {
                        str = str + propertyInfo.Name + ": n/a" + separator;
                    }
                }
            }
            if (type == FieldTypes.Fields || type == FieldTypes.PropertiesAndFields)
            {
                foreach (FieldInfo fieldInfo in fields)
                {
                    try
                    {
                        str = str + fieldInfo.Name + ": " + fieldInfo.GetValue(instanc).ToString() + separator;
                    }
                    catch
                    {
                        str = str + fieldInfo.Name + ": n/a" + separator;
                    }
                }
            }
            return str;
        }

        public static bool IsEqualToNull(this object @object)
        {
            return ReferenceEquals(@object, null);
        }
        public static bool IsNotEqualToNull(this object @object)
        {
            return !@object.IsEqualToNull();
        }
        public static bool IsSameTypeAs(this object @object1, object @object2)
        {
            return @object1.IsNotEqualToNull() && @object2.IsNotEqualToNull() && @object1.GetType() == @object2.GetType();
        }

        public static bool IsImplementSameInterface<T>(this object @object1, object @object2)
        {
            return
                @object1.IsNotEqualToNull() && @object2.IsNotEqualToNull() && typeof(T).IsInterface &&
                @object1.GetType().GetInterface(typeof(T).Name).IsNotEqualToNull() &&
                @object2.GetType().GetInterface(typeof(T).Name).IsNotEqualToNull();
        }

        public static void CopyPropertyValues(object source, object destination)
        {
            var destProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.CanWrite == true && destProperty.Name == sourceProperty.Name &&
                destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(destination, sourceProperty.GetValue(
                            source, new object[] { }), new object[] { });

                        break;
                    }
                }
            }
        }
    }
}
