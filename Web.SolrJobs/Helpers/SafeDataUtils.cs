using System;

namespace Web.SolrJobs.Helpers
{
    public static class SafeDataUtils
    {
        public static int SafeInt(string obj, int defaultValue = 0)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                int result;
                if (int.TryParse((string)obj, out result))
                    return result;
                return defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static int SafeInt(object obj, int defaultValue = 0)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static long SafeLong(string obj, long defaultValue = 0)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                long result;
                if (long.TryParse(obj, out result))
                    return result;
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static long SafeLong(object obj, long defaultValue = 0)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToInt64(obj);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }


        public static bool SafeBool(string obj, bool defaultValue = false)
        {
            if (String.IsNullOrEmpty(obj))
            {
                return defaultValue;
            }
            var bstr = obj.Trim().ToUpper();
            if ((bstr == "T") || (bstr == "TRUE") || (bstr == "Y") || (bstr == "YES") || (bstr == "1") || (SafeInt(bstr) > 0))
                return true;
            return false;
        }

        public static bool SafeBool(object obj, bool defaultValue = false)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                var s = obj as string;
                if (s != null)
                    return SafeBool(s, defaultValue);
                return Convert.ToBoolean(obj);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static DateTime SafeDateTime(string obj, DateTime defaultValue)
        {
            if (String.IsNullOrEmpty(obj))
            {
                return defaultValue;
            }
            try
            {
                DateTime result;
                if (DateTime.TryParse(obj, out result))
                    return result;
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime SafeDateTime(string obj)
        {
            return SafeDateTime(obj, DateTime.MinValue);
        }

        public static DateTime? SafeNullableDateTime(string obj, DateTime? defaultValue)
        {
            if (String.IsNullOrEmpty(obj))
            {
                return defaultValue;
            }
            try
            {
                DateTime result;
                if (DateTime.TryParse(obj, out result))
                    return result;
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static byte SafeByte(string obj, byte defaultValue = 0)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                byte result;
                if (byte.TryParse(obj, out result))
                    return result;
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal SafeDecimal(string obj, decimal defaultValue = 0)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                decimal result;
                if (decimal.TryParse(obj, out result))
                    return result;
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static float SafeFloat(object obj, float defaultValue = 0)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToSingle(obj);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static double SafeDouble(object obj, double defaultValue = 0.0)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToDouble(obj);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string SafeString(object obj, string defaultValue = "")
        {
            if (obj == null)
            {
                return defaultValue;
            }
            try
            {
                return Convert.ToString(obj);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static T SafeEnum<T>(string enumString, object defaultValue)
        {
            var enumValue = default(T);

            if (!string.IsNullOrEmpty(enumString))
            {
                try
                {
                    enumValue = (T)Enum.Parse(typeof(T), enumString);
                }
                catch (Exception)
                {
                    if (defaultValue != null)
                        enumValue = (T)Enum.ToObject(typeof(T), defaultValue);
                }
            }
            else
            {
                if (defaultValue != null)
                    enumValue = (T)Enum.ToObject(typeof(T), defaultValue);
            }
            return enumValue;
        }

        public static T SafeEnum<T>(int enumValue, object defaultValue)
        {
            var enumRet = default(T);

            try
            {
                enumRet = (T)Enum.ToObject(typeof(T), enumValue);
            }
            catch (Exception)
            {
                enumRet = (T)Enum.ToObject(typeof(T), defaultValue);
            }

            return enumRet;
        }

        public static object SafeEnum(Type enumType, string enumString, object defaultValue)
        {
            object enumValue = null;

            if (!string.IsNullOrEmpty(enumString))
            {
                try
                {
                    enumValue = Enum.Parse(enumType, enumString);
                }
                catch (Exception)
                {
                    if (defaultValue != null)
                        enumValue = Enum.ToObject(enumType, defaultValue);
                }
            }
            else
            {
                if (defaultValue != null)
                    enumValue = Enum.ToObject(enumType, defaultValue);
            }

            return enumValue;
        }

        public static object SafeEnum(Type enumType, int enumValue, object defaultValue)
        {
            object enumRet = null;

            try
            {
                enumRet = Enum.ToObject(enumType, enumValue);
            }
            catch (Exception) { enumRet = Enum.ToObject(enumType, defaultValue); }

            return enumRet;
        }

        public static Guid SafeGuid(string value, Guid defaultValue)
        {
            try
            {
                Guid result;
                if (Guid.TryParse(value, out result))
                    return result;
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static Guid SafeGuid(string value)
        {
            return SafeGuid(value, Guid.NewGuid());
        }
    }
}
