using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Web.SolrJobs.Helpers
{
    public static class StringUtils
    {
        private static readonly string extractTermRegex = @"(?s)(?<={0}).+?(?={1})";

        public static string UTF8ByteArrayToString(Byte[] characters)
        {
            var encoding = new UTF8Encoding();
            var constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        public static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            var encoding = new UTF8Encoding();
            var byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        public static string FirstFewChars(this string Item, int Count)
        {
            if (Item.Length < Count)
                return Item;
            return Item.Substring(0, Count);
        }

        public static string ToString(this List<string> obj, string sep = " ", bool useNewLine = true)
        {
            if (obj == null)
                return "";
            return ToString((IList<string>)obj.ToArray(), sep, useNewLine);
        }

        public static string ToString(this string[] obj, string sep = " ", bool useNewLine = true)
        {
            if (obj == null)
                return "";
            var sb = new StringBuilder();
            var pos = 0;
            foreach (var item in obj)
            {
                if (useNewLine)
                    sb.AppendLine(item + ((pos != obj.Length - 1) ? sep : ""));
                else
                    sb.Append(item + ((pos != obj.Length - 1) ? sep : ""));
                pos++;
            }
            return sb.ToString();
        }

        public static string ToString(this IList<string> obj, string sep = " ", bool useNewLine = true)
        {
            if (obj == null)
                return "";
            return ToString(obj.ToArray(), sep, useNewLine);
        }

        public static List<string> ToStringList<T>(this IList<T> lst)
        {
            var sl = new List<string>();
            foreach (var item in lst)
            {
                sl.Add(item.ToString());
            }
            return sl;
        }

        public static string ToString<T>(this IList<T> obj, string sep = " ", bool useNewLine = true)
        {
            return ToString(ToStringList(obj), sep, useNewLine);
        }

        public static void Trim(this List<string> obj)
        {
            if (obj == null)
                return;
            obj.RemoveAll(string.IsNullOrWhiteSpace);
            obj.RemoveAll(string.IsNullOrEmpty);
        }


        public static IEnumerable<string> IfLengthEquals(this IEnumerable<string> myList, int itemLength)
        {
            foreach (var item in myList.Where(item => item.Length == itemLength))
                yield return item;
        }

        public static IEnumerable<string> IfLengthInRange(this IEnumerable<string> myList, int startOfRange, int endOfRange)
        {
            foreach (var item in myList.Where(item => item.Length >= startOfRange || item.Length <= endOfRange))
                yield return item;
        }

        public static IEnumerable<string> IgnoreNullOrEmptyOrSpace(this IEnumerable<string> myList)
        {
            foreach (var item in myList.Where(item => !string.IsNullOrEmpty(item) && item != " "))
                yield return item;
        }

        public static IEnumerable<string> MakeAllLower(this IEnumerable<string> myList)
        {
            foreach (var item in myList)
                yield return item.ToLower();
        }

        public static IEnumerable<string> MakeAllUpper(this IEnumerable<string> myList)
        {
            foreach (var item in myList)
                yield return item.ToUpper();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public static string StreamToString(Stream stream)
        {
            string s = null;
            stream.Seek(0, SeekOrigin.Begin);
            using (StreamReader reader = new StreamReader(stream))
            {
                s = reader.ReadToEnd();
            }
            return s;
        }

        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        public static string SqlSafeString(string String, bool IsDel)
        {
            if (IsDel)
            {
                String = String.Replace("'", "");
                String = String.Replace("\"", "");
                return String;
            }
            String = String.Replace("'", "&#39;");
            String = String.Replace("\"", "&#34;");
            return String;
        }

        public static string GenerateUniqueId(int stringSize = 8)
        {
            string str = "abcdefghijkmnopqrstuvwxyz1234567890";
            StringBuilder stringBuilder = new StringBuilder(stringSize);
            int num1 = 0;
            foreach (byte num2 in Guid.NewGuid().ToByteArray())
            {
                stringBuilder.Append(str[(int)num2 % (str.Length - 1)]);
                ++num1;
                if (num1 >= stringSize)
                    return ((object)stringBuilder).ToString();
            }
            return ((object)stringBuilder).ToString();
        }

        public static long GenerateUniqueNumericId()
        {
            return BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0);
        }

        public static string ToString<T>(this List<T> obj, string sep = " ", bool useNewLine = true)
        {
            return ToString(ToStringList(obj), sep, useNewLine);
        }

        public static string InitialCap(this string inStr)
        {
            if (inStr == null || inStr.Trim().Length == 0)
                return "";
            var lowerStr = inStr.ToLower();
            var str = lowerStr.Substring(0, 1).ToUpper();
            if (lowerStr.Length > 1)
                str += lowerStr.Substring(1);

            return str;
        }

        public static string GetUpperCase(string inStr)
        {
            if (inStr == null || inStr.Trim().Length == 0)
                return "";
            return inStr.ToUpper();
        }

        public static string GetLowerCase(string inStr)
        {
            if (inStr == null || inStr.Trim().Length == 0)
                return "";
            return inStr.ToLower();
        }

        public static string CasedString(this string inStr)
        {
            if (inStr == null || inStr.Trim().Length == 0)
                return "";

            var upperCaseStr = inStr.Trim().ToUpper();
            if (inStr.Trim().Length == 1)
                return upperCaseStr;
            return inStr.Trim().Substring(0, 1).ToUpper() + inStr.Trim().Substring(1).ToLower();
        }

        public static string ReplaceWithIgnoreCase(this string str, string oldValue, string newValue)
        {
            return Replace(str, oldValue, newValue, StringComparison.CurrentCultureIgnoreCase);
        }

        public static string Replace(this string str, string oldValue, string newValue, StringComparison comparison)
        {
            StringBuilder sb = new StringBuilder();

            int previousIndex = 0;
            int index = str.IndexOf(oldValue, comparison);
            while (index != -1)
            {
                sb.Append(str.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = str.IndexOf(oldValue, index, comparison);
            }
            sb.Append(str.Substring(previousIndex));

            return sb.ToString();
        }

        public static string ReplaceChar(this string inStr, char CharValue, int Index)
        {
            if (inStr == null || inStr.Trim().Length == 0)
                return "";

            return inStr.Substring(0, Index) + CharValue + inStr.Substring(Index + 1);
        }

        public static int IndexOfNumeric(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return -1;

            for (var index = 0; index < str.Length; index++)
            {
                var b = (byte)str[index];
                if (b >= (byte)'0' && b <= (byte)'9')
                {
                    return index;
                }
            }

            return -1;
        }

        public static bool IsNumeric(this string Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static bool IsVersionNumber(this string Expression)
        {
            var exp = Convert.ToString(Expression);
            var regex = new Regex(
                @"([\d0-9.]*\d)",
                RegexOptions.IgnoreCase
                | RegexOptions.Multiline
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );
            var mat = regex.Match(exp);
            if (mat.Success)
            {
                if (mat.Value.Equals(exp, StringComparison.CurrentCultureIgnoreCase))
                    return true;
                return false;
            }
            return false;
        }

        public static string LastChar(this string str)
        {
            if (str.Length > 0)
                return str[str.Length - 1].ToString();
            return "";
        }

        public static string FirstChar(this string str)
        {
            if (str.Length > 0)
                return str[0].ToString();
            return "";
        }

        public static String StrippedFormatedString(this String str, int len, string defaultPadChar = "", bool appendThreeDots = false)
        {
            if (str == null)
                return "".PadRight(len, '~').Replace("~", defaultPadChar);
            String str2;
            if (str.Length > len)
            {
                if (appendThreeDots && str.Length > 3)
                {
                    str2 = str.Substring(0, len - 3) + "...";
                }
                else
                {
                    str2 = str.Substring(0, len);
                }
            }
            else
                str2 = str.PadRight(len, '~').Replace("~", defaultPadChar);
            return str2;
        }

        public static string ListItem(this string str, string delimeter, int position)
        {
            var split = str.Split(new string[] { delimeter }, StringSplitOptions.None);
            if (split != null && split.Length > 0 && split.Length > position)
                return split[position];

            return String.Empty;
        }


        public static List<string> AsList(this string str, string delimeter, bool ignoreEmptyItems = true)
        {
            var split = str.IsNullOrEmpty() ? new string[] { } : str.Split(new string[] { delimeter }, StringSplitOptions.None);
            var result = new List<string>();
            result.AddRange(ignoreEmptyItems ? TrimStringArray(split) : split);
            return result;
        }

        public static string[] TrimStringArray(this string[] split)
        {
            if (split == null)
            {
                return split;
            }

            for (var i = 0; i < split.Length; ++i)
            {
                if (split[i] == null)
                    continue;
                split[i] = split[i].Trim();
            }
            return split;
        }

        public static List<long> AsLongList(this string str, string delimeter)
        {
            var sl = AsList(str, delimeter);
            var result = new List<long>();
            foreach (var sItem in sl)
            {
                result.Add(SafeDataUtils.SafeLong(sItem));
            }
            return result;
        }

        public static List<int> AsIntList(this string str, string delimeter)
        {
            var sl = AsList(str, delimeter);
            var result = new List<int>();
            foreach (var sItem in sl)
            {
                result.Add(SafeDataUtils.SafeInt(sItem));
            }
            return result;
        }

        public static Hashtable ParseNameValuePairString(this string str, string delimeter)
        {
            return ParseNameValuePairString(str, delimeter, "=");
        }

        public static Hashtable ParseNameValuePairString(this string str, string listDelimeter, string pairDelimeter)
        {
            var ht = new Hashtable();
            var split = str.Split(new string[] { listDelimeter }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in split)
            {
                var splitNameValue = s.Split(new string[] { pairDelimeter }, StringSplitOptions.None);
                if ((splitNameValue != null) || (splitNameValue.Length > 1))
                    ht.Add(splitNameValue[0], splitNameValue[1]);
                else
                    ht.Add(s, "");
            }
            return ht;
        }

        public static string FlattenString(this string Str)
        {
            Str = Str.Replace('\n', ' ');
            Str = Str.Replace('\t', ' ');
            Str = Str.Replace('\r', ' ');
            return Str;
        }

        public static bool IsTrimmedStringNullOrEmpty(this string str)
        {
            if (String.IsNullOrEmpty(str))
                return true;
            return (String.IsNullOrEmpty(str.Trim()));
        }

        public static bool IsTrimmedStringNotNullOrEmpty(this string str)
        {
            return !IsTrimmedStringNullOrEmpty(str);
        }

        public static bool IsSameWithCaseIgnoreTrimmed(this string str, string anotherStr)
        {
            if ((str == null) && (anotherStr == null))
                return true;

            if ((str == null) || (anotherStr == null))
                return false;
            return (str.Trim().ToLower() == anotherStr.Trim().ToLower());
        }

        public static string FormatString(this string fmt, params object[] args)
        {
            return String.Format(fmt, args);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !value.IsNullOrEmpty();
        }

        public static List<string> EmptyStringList(int count, string initValue = "")
        {
            var result = new List<string>();
            for (var i = 0; i < count; ++i)
            {
                result.Add(initValue);
            }
            return result;
        }
        public static bool Matches(this string source, string compare)
        {
            return String.Equals(source, compare, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool MatchesTrimmed(this string source, string compare)
        {
            return String.Equals(source.Trim(), compare.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static List<string> MatchesRegex(this string expression, string pattern)
        {
            var matches = new List<string>();
            var regex = new Regex(
                pattern,
                RegexOptions.IgnoreCase
                | RegexOptions.Multiline
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );

            var matchCollection = regex.Matches(expression);
            if (matchCollection != null && matchCollection.Count > 0)
            {
                foreach (Match m in regex.Matches(expression))
                {
                    if (m.Success)
                    {
                        matches.Add(m.Value);
                    }
                }
            }

            return matches;
        }

        public static string Chop(this string sourceString, int removeFromEnd)
        {
            string result = sourceString;
            if ((removeFromEnd > 0) && (sourceString.Length > removeFromEnd - 1))
                result = result.Remove(sourceString.Length - removeFromEnd, removeFromEnd);
            return result;
        }

        public static string Chop(this string sourceString, string backDownTo)
        {
            int removeDownTo = sourceString.LastIndexOf(backDownTo);
            int removeFromEnd = 0;
            if (removeDownTo > 0)
                removeFromEnd = sourceString.Length - removeDownTo;

            string result = sourceString;

            if (sourceString.Length > removeFromEnd - 1)
                result = result.Remove(removeDownTo, removeFromEnd);

            return result;
        }

        public static string Chop(this string sourceString)
        {
            return Chop(sourceString, 1);
        }

        public static string Clip(this string sourceString, int removeFromBeginning)
        {
            string result = sourceString;
            if (sourceString.Length > removeFromBeginning)
                result = result.Remove(0, removeFromBeginning);
            return result;
        }

        public static string Clip(this string sourceString, string removeUpTo)
        {
            int removeFromBeginning = sourceString.IndexOf(removeUpTo);
            string result = sourceString;

            if (sourceString.Length > removeFromBeginning && removeFromBeginning > 0)
                result = result.Remove(0, removeFromBeginning);

            return result;
        }

        public static string Clip(this string sourceString)
        {
            return Clip(sourceString, 1);
        }

        public static string Crop(this string sourceString, string startText, string endText)
        {
            int startIndex = sourceString.IndexOf(startText, StringComparison.CurrentCultureIgnoreCase);
            if (startIndex == -1)
                return String.Empty;

            startIndex += startText.Length;
            int endIndex = sourceString.IndexOf(endText, startIndex, StringComparison.CurrentCultureIgnoreCase);
            if (endIndex == -1)
                return String.Empty;

            return sourceString.Substring(startIndex, endIndex - startIndex);
        }

        public static string Squeeze(this string sourceString)
        {
            char[] delim = { ' ' };
            string[] lines = sourceString.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string s in lines)
            {
                if (!String.IsNullOrEmpty(s.Trim()))
                    sb.Append(s + " ");
            }
            //remove the last pipe
            string result = Chop(sb.ToString());
            return result.Trim();
        }

        public static string StripHTML(this string htmlString)
        {
            return StripHTML(htmlString, String.Empty);
        }

        public static string AsciiToUnicode(this int asciiCode)
        {
            Encoding ascii = Encoding.UTF32;
            char c = (char)asciiCode;
            Byte[] b = ascii.GetBytes(c.ToString());
            return ascii.GetString((b));
        }

        public static string StripHTML(this string htmlString, string htmlPlaceHolder)
        {
            const string pattern = @"<(.|\n)*?>";
            string sOut = Regex.Replace(htmlString, pattern, htmlPlaceHolder);
            sOut = sOut.Replace("&nbsp;", String.Empty);
            sOut = sOut.Replace("&amp;", "&");
            sOut = sOut.Replace("&gt;", ">");
            sOut = sOut.Replace("&lt;", "<");
            return sOut;
        }

        public static string EncloseInQuotes(this string text, string quote = "\"")
        {
            return quote + text + quote;
        }

        public static string ExtractString(this string input, string startDelim, string endDelim)
        {
            string result;
            var r = new Regex(string.Format(extractTermRegex, startDelim, endDelim),
                RegexOptions.IgnoreCase
                | RegexOptions.Multiline
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );
            if (r.IsMatch(input))
                result = r.Match(input).Value;
            else
                result = string.Empty;
            return result;
        }

        public static string DefaultIfNullOrEmpty(this string input, string defaultValue)
        {
            if (input.IsTrimmedStringNullOrEmpty())
                return defaultValue;
            return input;
        }

        public static string Repeat(this string str, int repeat)
        {
            var sb = new StringBuilder(repeat * str.Length);
            for (var i = 0; i < repeat; i++)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }

        public static string ToSlug(this string value, int? maxLength = null)
        {
            if (value.IsTrimmedStringNullOrEmpty())
                return "";
            return GenerateSlug(value, maxLength);
        }

        private static string RemoveAccent(string value)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }

        private static string GenerateSlug(string value, int? maxLength = null)
        {
            // prepare string, remove accents, lower case and convert hyphens to whitespace
            var result = RemoveAccent(value).Replace("-", " ").ToLowerInvariant();

            result = Regex.Replace(result, @"[^a-z0-9\s-]", string.Empty); // remove invalid characters
            result = Regex.Replace(result, @"\s+", " ").Trim(); // convert multiple spaces into one space

            if (maxLength.HasValue) // cut and trim
                result = result.Substring(0, result.Length <= maxLength ? result.Length : maxLength.Value).Trim();

            return Regex.Replace(result, @"\s", "-"); // replace all spaces with hyphens
        }

        public static string EmptyIfNull(this string str)
        {
            if (str == null)
                return String.Empty;
            return str;
        }

        public static string NullIfEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;
            return str;
        }

        public static string AddLastChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            if (str.LastChar() != citem.ToString())
                str = str + citem.ToString();
            return str;
        }

        public static string RemoveLastChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            if (str.LastChar() == citem.ToString())
                str = str.Substring(0, str.Length - 1);
            return str;
        }

        public static string RemoveFirstChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            if (str.FirstChar() == citem.ToString())
                str = str.Substring(1);
            return str;
        }

        public static string AddFirstChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            if (str.FirstChar() != citem.ToString())
                str = citem.ToString() + str;
            return str;
        }


        public static string RemoveLastCharAndAddFirstChar(this string str, char citem)
        {
            if (str.IsNullOrEmpty())
                return str;
            str = AddFirstChar(str, citem);
            str = RemoveLastChar(str, citem);
            return str;
        }

        public static string AddLastUrlSlash(this string str)
        {
            return AddLastChar(str, '/');
        }

        public static string RemoveLastUrlSlash(this string str)
        {
            return RemoveLastChar(str, '/');
        }

        public static string AddLastSlash(this string str)
        {
            return AddLastChar(str, Path.DirectorySeparatorChar);
        }

        public static string RemoveLastSlash(this string str)
        {
            return RemoveLastChar(str, Path.DirectorySeparatorChar);
        }

        public static string RemoveFirstSlash(this string str)
        {
            return RemoveFirstChar(str, Path.DirectorySeparatorChar);
        }

        public static string AddFirstSlash(this string str)
        {
            return AddFirstChar(str, Path.DirectorySeparatorChar);
        }

        public static string RemoveLastSlashAndAddFirstSlash(this string str)
        {
            return RemoveLastCharAndAddFirstChar(str, Path.DirectorySeparatorChar);
        }

        public static bool IsQuoted(this string text)
        {
            return false;

            #region Earlier Attempt

            #region 1st Attempt

            if (text.IsNullOrEmpty())
            {
                return false;
            }

            text = text.Trim();

            if (text.IsNullOrEmpty())
                return false;

            if (text.First() == '\"' && text.Last() == '\"')
                return true;

            if (text.First() == '\'' && text.Last() == '\'')
                return true;

            if (text.First() == '(' && text.Last() == ')')
                return true;

            return false;
            #endregion

            #region 2nd Attempt

            //string escape = "+-!(){}[]^\"~*?:\\";

            //if (text.IsNullOrEmpty())
            //    return false;
            //text = text.Trim();

            //if (text.IsNullOrEmpty())
            //    return false;

            //if (escape.Contains(text.First()) || escape.Contains(text.Last()))
            //    return true;

            //return false;
            #endregion

            #endregion
        }

        public static List<string> SplitOnSpace(this string text)
        {
            return text.AsList(" ");
        }

        public static string SplitCamelCase(this string input)
        {
            return Regex.Replace(input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        public static string RemoveSpace(this string input)
        {
            return input.Replace(" ", "");
        }

        public static char CharAt(this string input, int index)
        {
            if (input.IsNullOrEmpty() || index < 0 || index > input.Length - 1)
                return '\0';
            return (char)input[index];
        }

        public static string StripNonAlphanumericCharacters(this string trimmedString, bool fromEnd = false)
        {
            if (trimmedString == null)
                return trimmedString;

            var j = 0;
            if (fromEnd)
            {
                var i = trimmedString.Length - 1;

                while (!char.IsLetterOrDigit(trimmedString.CharAt(i)))
                {
                    j++;
                    i--;
                }
                if (j > 0)
                    trimmedString = trimmedString.Substring(0, trimmedString.Length - j);
            }
            else
            {
                var i = 0;

                while (!char.IsLetterOrDigit(trimmedString.CharAt(i)))
                {
                    j++;
                    i++;
                }
                if (j > 0)
                    trimmedString = trimmedString.Substring(j, trimmedString.Length - j);
            }
            return trimmedString;
        }

        public static string GetDigits(this string input)
        {
            var digits = new string(input.Where(char.IsDigit).ToArray());
            return digits;
        }

        public static string GetLetters(this string input)
        {
            var digits = new string(input.Where(char.IsLetter).ToArray());
            return digits;
        }

        public static string TrimIfNotNull(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return input.Trim();
        }

        public static bool IsEnclosedInQuotes(this string text)
        {
            if (text.IsTrimmedStringNullOrEmpty())
                return false;
            text = text.Trim();

            if (text.First() == '\"' && text.Last() == '\"')
                return true;

            return false;
        }

        public static string StripHtml(this string source)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";
            const string stripFormatting = @"<[^>]*(>|$)";
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";

            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            source = System.Net.WebUtility.HtmlDecode(source);
            source = tagWhiteSpaceRegex.Replace(source, "><");
            source = lineBreakRegex.Replace(source, Environment.NewLine);
            source = stripFormattingRegex.Replace(source, string.Empty);

            return source;
        }

        public static string AppendWith(this string value, string appendWith)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return string.Concat(value, appendWith);
        }

        public static string PrependWith(this string value, string prependWith)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return string.Concat(prependWith, value);
        }

        public static int WordCount(this string input)
        {
            var count = 0;
            try
            {
                // Exclude whitespaces, Tabs and line breaks
                var re = new Regex(@"[^\s]+");
                var matches = re.Matches(input);
                count = matches.Count;
            }
            catch
            {
            }
            return count;
        }

        public static void Clear(this StringBuilder sb)
        {
            sb.Length = 0;
        }

        public static string ToSentence(this string variableName)
        {
            var builder = new StringBuilder();

            char[] chars = variableName.ToCharArray();

            foreach (char c in chars)
            {
                if (char.IsLetter(c) && char.IsUpper(c))
                {
                    builder.Append(" ");
                }

                builder.Append(c);
            }

            variableName = builder.ToString().TrimStart();

            return variableName;
        }

        public static string InnerTruncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
            {
                return value;
            }
            int charsInEachHalf = (maxLength - 3) / 2;
            string right = value.Substring(value.Length - charsInEachHalf, charsInEachHalf).TrimStart();

            string left = value.Substring(0, (maxLength - 3) - right.Length).TrimEnd();

            return string.Format("{0}...{1}", left, right);
        }

        public static string Repeat(this string input, int number, string RepeatChar)
        {
            if (!string.IsNullOrEmpty(input))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= number; i++)
                {
                    sb.AppendFormat("{0}{1}", input, RepeatChar);
                }
                return sb.Remove(sb.Length - 1, 1).ToString();
            }
            else
            {
                return null;
            }
        }

        public static string CSVQuoted(this string s)
        {
            if (s.IndexOfAny(" ,\n".ToCharArray()) < 0 && s.Trim() == s)
                return s;

            StringBuilder sb = new StringBuilder();
            sb.Append('"');
            foreach (char c in s)
            {
                sb.Append(c);
                if (c == '"')
                    sb.Append(c);
            }
            sb.Append('"');
            return sb.ToString();
        }

        public static string TakeFrom(this string s, string searchFor)
        {
            if (s.Contains(searchFor))
            {
                int length = Math.Max(s.Length, 0);

                int index = s.IndexOf(searchFor);

                return s.Substring(index, length - index);
            }
            return s;
        }

        public static void AppendLine(this StringBuilder builder, string value, params Object[] parameters)
        {
            builder.AppendLine(string.Format(value, parameters));
        }

        public static StringBuilder AppendLineIf(this StringBuilder sb, bool condition, object value)
        {
            if (condition) sb.AppendLine(value.ToString());
            return sb;
        }

        public static StringBuilder AppendLineIf(this StringBuilder sb, bool condition, string format, params object[] args)
        {
            if (condition) sb.AppendFormat(format, args).AppendLine();
            return sb;
        }

        public static StringBuilder AppendIf(this StringBuilder sb, bool condition, object value)
        {
            if (condition) sb.Append(value.ToString());
            return sb;
        }

        public static StringBuilder AppendFormatIf(this StringBuilder sb, bool condition, string format, params object[] args)
        {
            if (condition) sb.AppendFormat(format, args);
            return sb;
        }

        public static string TrimToMaxLength(this string value, int maxLength)
        {
            return (value == null || value.Length <= maxLength ? value : value.Substring(0, maxLength));
        }

        public static string TrimToMaxLength(this string value, int maxLength, string suffix)
        {
            return (value == null || value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), suffix));
        }

        public static string EnsureStartsWith(this string value, string prefix)
        {
            return value.StartsWith(prefix) ? value : string.Concat(prefix, value);
        }


        public static string EnsureEndsWith(this string value, string suffix)
        {
            return value.EndsWith(suffix) ? value : string.Concat(value, suffix);
        }


        public static string ConcatWith(this string value, params string[] values)
        {
            return string.Concat(value, string.Concat(values));
        }


        public static string GetBetween(this string value, string x, string y)
        {
            var xPos = value.IndexOf(x);
            var yPos = value.LastIndexOf(y);

            if (xPos == -1 || xPos == -1)
                return String.Empty;

            var startIndex = xPos + x.Length;
            return startIndex >= yPos ? String.Empty : value.Substring(startIndex, yPos - startIndex).Trim();
        }

        public static string GetBefore(this string value, string x)
        {
            var xPos = value.IndexOf(x);
            return xPos == -1 ? String.Empty : value.Substring(0, xPos);
        }

        public static string GetAfter(this string value, string x)
        {
            var xPos = value.LastIndexOf(x);

            if (xPos == -1)
                return String.Empty;

            var startIndex = xPos + x.Length;
            return startIndex >= value.Length ? String.Empty : value.Substring(startIndex).Trim();
        }

        public static bool ContainsAny(this string @this, params string[] values)
        {
            return @this.ContainsAny(StringComparison.CurrentCulture, values);
        }

        public static bool ContainsAny(this string @this, StringComparison comparisonType, params string[] values)
        {
            foreach (string value in values)
            {
                if (@this.IndexOf(value, comparisonType) > -1) return true;
            }
            return false;
        }

        public static bool ContainsAll(this string @this, params string[] values)
        {
            return @this.ContainsAll(StringComparison.CurrentCulture, values);
        }

        public static bool ContainsAll(this string @this, StringComparison comparisonType, params string[] values)
        {
            foreach (string value in values)
            {
                if (@this.IndexOf(value, comparisonType) == -1) return false;
            }
            return true;
        }

        public static bool EqualsAny(this string @this, StringComparison comparisonType, params string[] values)
        {
            foreach (string value in values)
            {
                if (@this.Equals(value, comparisonType)) return true;
            }
            return false;
        }

        public static bool IsLikeAny(this string value, params string[] patterns)
        {
            foreach (string pattern in patterns)
            {
                if (value.IsLike(pattern)) return true;
            }
            return false;
        }

        public static bool IsLike(this string value, string pattern)
        {
            if (value == pattern) return true;

            if (pattern[0] == '*' && pattern.Length > 1)
            {
                for (int index = 0; index < value.Length; index++)
                {
                    if (value.Substring(index).IsLike(pattern.Substring(1)))
                        return true;
                }
            }
            else if (pattern[0] == '*')
            {
                return true;
            }
            else if (pattern[0] == value[0])
            {
                return value.Substring(1).IsLike(pattern.Substring(1));
            }
            return false;
        }





    }
}
