using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Web.SolrClient.Helpers
{
    public static class LinqUtils
    {
        public static bool IsNotNullAndEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (!((source == null) || (!source.Any())))
                return true;
            return false;
        }

        public static bool IsNullAndEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return !IsNotNullAndEmpty(source);
        }

        public static List<TSource> ToListEx<TSource>(this IEnumerable<TSource> source)
        {
            if (source.IsNullAndEmpty())
                return new List<TSource>();
            return source.ToList();
        }

        public static TSource[] ToArrayEx<TSource>(this IEnumerable<TSource> source)
        {
            if (source.IsNullAndEmpty())
                return new List<TSource>().ToArray();
            return source.ToList().ToArray();
        }

        public static void SwapValues<T>(this IList<T> source, int indexA, int indexB)
        {
            if ((indexA < 0) || (indexA >= source.Count))
            {
                throw new IndexOutOfRangeException("indexA is out of range");
            }
            if ((indexB < 0) || (indexB >= source.Count))
            {
                throw new IndexOutOfRangeException("indexB is out of range");
            }

            if (indexA == indexB)
            {
                return;
            }

            T tempValue = source[indexA];
            source[indexA] = source[indexB];
            source[indexB] = tempValue;
        }

        public static void AddRange<T>(this IList<T> container, IEnumerable<T> rangeToAdd)
        {
            if ((container == null) || (rangeToAdd == null))
            {
                return;
            }
            foreach (T toAdd in rangeToAdd)
            {
                container.Add(toAdd);
            }
        }

        public static void ForEachWithIndex<T>(this IEnumerable<T> enumerable, Action<T, int> handler)
        {
            if (enumerable == null)
                return;
            var idx = 0;
            foreach (var item in enumerable)
                handler(item, idx++);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
                return;
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var knownKeys = new HashSet<TKey>();
            return source.Where(element => knownKeys.Add(keySelector(element)));
        }

        public static bool Matches<T>(this T[] array1, T[] array2)
        {
            if ((array1 == null) && (array2 == null))
                return true;

            if ((array1 == null) || (array2 == null))
                return false;

            return array1.Length == array2.Length && array1.OrderBy(s => s).SequenceEqual(array2.OrderBy(s => s));
        }

        public static bool Matches<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if ((list1 == null) && (list2 == null))
                return true;

            if ((list1 == null) || (list2 == null))
                return false;

            var array1 = list1.ToArrayEx();
            var array2 = list2.ToArrayEx();
            return Matches(array1, array2);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool ascending)
        {
            if (ascending)
            {
                return source.OrderBy(keySelector);
            }
            else
            {
                return source.OrderByDescending(keySelector);
            }
        }

        public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool ascending)
        {
            if (ascending)
            {
                return source.ThenBy(keySelector);
            }
            else
            {
                return source.ThenByDescending(keySelector);
            }
        }

        /*
         * Example Usage

            FlatData[] elements = new FlatData[]
            {
               new FlatData {Id = 1, Text = "A"},
               new FlatData {Id = 2, Text = "B"},
               new FlatData {Id = 3, ParentId = 1, Text = "C"},
               new FlatData {Id = 4, ParentId = 1, Text = "D"},
               new FlatData {Id = 5, ParentId = 2, Text = "E"}
            };

            IEnumerable<NodeData> nodes = elements.RecursiveJoin(element => element.Id,
               element => element.ParentId,
               (FlatData element, IEnumerable<NodeData> children) => new NodeData()
               {
                  Text = element.Text,
                  Children = children
               });

            FlatData[] elements = new FlatData[]
            {
               new FlatData {Id = 1, Text = "A"},
               new FlatData {Id = 2, Text = "B"},
               new FlatData {Id = 3, ParentId = 1, Text = "C"},
               new FlatData {Id = 4, ParentId = 1, Text = "D"},
               new FlatData {Id = 5, ParentId = 2, Text = "E"}
            };

            IEnumerable<DeepNodeData> nodes = elements.RecursiveJoin(element => element.Id,
               element => element.ParentId,
               (FlatData element, int index, int depth, IEnumerable<DeepNodeData> children) =>
               {
                  return new DeepNodeData()
                  {
                     Text = element.Text,
                     Children = children,
                     Depth = depth
                  };
               }); 

         */

        public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
           Func<TSource, TKey> parentKeySelector,
           Func<TSource, TKey> childKeySelector,
           Func<TSource, IEnumerable<TResult>, TResult> resultSelector)
        {
            return RecursiveJoin(source, parentKeySelector, childKeySelector,
               resultSelector, Comparer<TKey>.Default);
        }

        public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
           Func<TSource, TKey> parentKeySelector,
           Func<TSource, TKey> childKeySelector,
           Func<TSource, int, IEnumerable<TResult>, TResult> resultSelector)
        {
            return RecursiveJoin(source, parentKeySelector, childKeySelector,
               (TSource element, int depth, int index, IEnumerable<TResult> children)
                  => resultSelector(element, index, children));
        }

        public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
           Func<TSource, TKey> parentKeySelector,
           Func<TSource, TKey> childKeySelector,
           Func<TSource, IEnumerable<TResult>, TResult> resultSelector,
           IComparer<TKey> comparer)
        {
            return RecursiveJoin(source, parentKeySelector, childKeySelector,
               (TSource element, int depth, int index, IEnumerable<TResult> children)
                  => resultSelector(element, children), comparer);
        }

        public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
           Func<TSource, TKey> parentKeySelector,
           Func<TSource, TKey> childKeySelector,
           Func<TSource, int, IEnumerable<TResult>, TResult> resultSelector,
           IComparer<TKey> comparer)
        {
            return RecursiveJoin(source, parentKeySelector, childKeySelector,
               (TSource element, int depth, int index, IEnumerable<TResult> children)
                  => resultSelector(element, index, children), comparer);
        }

        public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
           Func<TSource, TKey> parentKeySelector,
           Func<TSource, TKey> childKeySelector,
           Func<TSource, int, int, IEnumerable<TResult>, TResult> resultSelector)
        {
            return RecursiveJoin(source, parentKeySelector, childKeySelector,
               resultSelector, Comparer<TKey>.Default);
        }

        public static IEnumerable<TResult> RecursiveJoin<TSource, TKey, TResult>(this IEnumerable<TSource> source,
           Func<TSource, TKey> parentKeySelector,
           Func<TSource, TKey> childKeySelector,
           Func<TSource, int, int, IEnumerable<TResult>, TResult> resultSelector,
           IComparer<TKey> comparer)
        {
            source = new LinkedList<TSource>(source);
            SortedDictionary<TKey, TSource> parents = new SortedDictionary<TKey, TSource>(comparer);
            SortedDictionary<TKey, LinkedList<TSource>> children = new SortedDictionary<TKey, LinkedList<TSource>>(comparer);

            foreach (TSource element in source)
            {
                parents[parentKeySelector(element)] = element;
                LinkedList<TSource> list;
                TKey childKey = childKeySelector(element);
                if (!children.TryGetValue(childKey, out list))
                {
                    children[childKey] = list = new LinkedList<TSource>();
                }
                list.AddLast(element);
            }

            Func<TSource, int, IEnumerable<TResult>> childSelector = null;
            childSelector = (TSource parent, int depth) =>
            {
                LinkedList<TSource> innerChildren = null;
                if (children.TryGetValue(parentKeySelector(parent), out innerChildren))
                {
                    return innerChildren.Select((child, index)
                       => resultSelector(child, index, depth, childSelector(child, depth + 1)));
                }
                return Enumerable.Empty<TResult>();
            };
            return source.Where(element => !parents.ContainsKey(childKeySelector(element)))
               .Select((element, index) => resultSelector(element, index, 0, childSelector(element, 1)));
        }

        /*
         *NodeData[] nodes = new NodeData[]
     {
        new NodeData
        {
           Text = "A",
           Children = new NodeData[]
           {
              new NodeData { Text = "C" },
              new NodeData { Text = "D" },
           }
        },
        new NodeData
        {
           Text = "B",
           Children = new NodeData[]
           {
              new NodeData
              {
                 Text = "E",
                 Children = new NodeData[]
                 {
                    new NodeData { Text = "F" },
                 }
              }
           }
        }
     };
         public class NodeData
     {
        public string Text { get; set; }

        public NodeData[] Children { get; set; }
     }

    foreach (NodeData node in nodes.RecursiveSelect(node => node.Children))
    {
       Console.WriteLine(node.Text);
    }
         */
        public static IEnumerable<TSource> RecursiveSelect<TSource>(this IEnumerable<TSource> source,
   Func<TSource, IEnumerable<TSource>> childSelector)
        {
            return RecursiveSelect(source, childSelector, element => element);
        }

        public static IEnumerable<TResult> RecursiveSelect<TSource, TResult>(this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TSource>> childSelector, Func<TSource, TResult> selector)
        {
            return RecursiveSelect(source, childSelector, (element, index, depth) => selector(element));
        }

        public static IEnumerable<TResult> RecursiveSelect<TSource, TResult>(this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TSource>> childSelector, Func<TSource, int, TResult> selector)
        {
            return RecursiveSelect(source, childSelector, (element, index, depth) => selector(element, index));
        }

        public static IEnumerable<TResult> RecursiveSelect<TSource, TResult>(this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TSource>> childSelector, Func<TSource, int, int, TResult> selector)
        {
            return RecursiveSelect(source, childSelector, selector, 0);
        }

        private static IEnumerable<TResult> RecursiveSelect<TSource, TResult>(this IEnumerable<TSource> source,
           Func<TSource, IEnumerable<TSource>> childSelector, Func<TSource, int, int, TResult> selector, int depth)
        {
            return source.SelectMany((element, index) => Enumerable.Repeat(selector(element, index, depth), 1)
               .Concat(RecursiveSelect(childSelector(element) ?? Enumerable.Empty<TSource>(),
                  childSelector, selector, depth + 1)));
        }
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(s => Guid.NewGuid());
        }

        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> obj, T value)
        {
            return (from i in Enumerable.Range(0, obj.Count())
                    where obj.ElementAt(i).Equals(value)
                    select i);
        }

        public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> obj, IEnumerable<T> value)
        {
            return (from i in Enumerable.Range(0, obj.Count())
                    where value.Contains(obj.ElementAt(i))
                    select i);
        }

        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> source)
        {
            while (true)
            {
                foreach (var item in source)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> collection, Predicate<T> endCondition)
        {
            return collection.TakeWhile(item => !endCondition(item));
        }

        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> @this, Func<T, TKey> keySelector)
        {
            return @this.GroupBy(keySelector).Select(grps => grps).Select(e => e.First());
        }

        public static bool Between<T>(this T value, T from, T to) where T : IComparable<T>
        {
            return value.CompareTo(from) >= 0 && value.CompareTo(to) <= 0;
        }

        public static IEnumerable<T> RemoveDuplicates<T>(this ICollection<T> list, Func<T, int> Predicate)
        {
            var dict = new Dictionary<int, T>();

            foreach (var item in list)
            {
                if (!dict.ContainsKey(Predicate(item)))
                {
                    dict.Add(Predicate(item), item);
                }
            }

            return dict.Values.AsEnumerable();
        }

        public static T Limit<T>(this T value, T maximum) where T : IComparable<T>
        {
            return value.CompareTo(maximum) < 1 ? value : maximum;
        }


        /*var folderStatus = 5.TimesOrUntil(
                         imap.SelectInbox,
                         state => state.Recent > 0,
                         () => Thread.Sleep(500));
         */
        public static T TimesOrUntil<T>(this int times, Func<T> retrieve, Func<T, bool> validate, Action inbetween = null)
        {
            T state;
            var count = 0;

            while (true)
            {
                state = retrieve();

                if (validate(state) || ++count >= times)
                    break;

                if (inbetween != null) inbetween();
            }

            return state;
        }

        public static void Times(this int ndx, Action<int> action)
        {
            for (int i = 0; i < ndx; i++)
            {
                action(i);
            }
        }

        public static void Upto(this int start, int end, Action<int> action)
        {
            for (int i = start; i <= end; i++)
            {
                action(i);
            }
        }


        public static void UptoIncluding(this int start, int end, Action<int> action)
        {
            for (int i = start; i <= end; i++)
            {
                action(i);
            }
        }

        public static void Downto(this int end, int start, Action<int> action)
        {
            for (int i = end; i > start; i--)
            {
                action(i);
            }
        }

        public static void DowntoIncluding(this int end, int start, Action<int> action)
        {
            for (int i = end; i >= start; i--)
            {
                action(i);
            }
        }


        public static bool WithinIndex<T>(this List<T> source, int index)
        {
            return source != null && index >= 0 && index < source.Count;
        }

        public static bool WithinIndex(this Array source, int index)
        {
            return source != null && index >= 0 && index < source.Length;
        }

        public static T[] CombineArray<T>(this T[] combineWith, T[] arrayToCombine)
        {
            if (combineWith != default(T[]) && arrayToCombine != default(T[]))
            {
                int initialSize = combineWith.Length;
                Array.Resize<T>(ref combineWith, initialSize + arrayToCombine.Length);
                Array.Copy(arrayToCombine, arrayToCombine.GetLowerBound(0), combineWith, initialSize, arrayToCombine.Length);
            }
            return combineWith;
        }

        public static bool AddUnique<T>(this ICollection<T> collection, T value)
        {
            var alreadyHas = collection.Contains(value);
            if (!alreadyHas)
            {
                collection.Add(value);
            }
            return alreadyHas;
        }

        public static int AddRangeUnique<T>(this ICollection<T> collection, IEnumerable<T> values)
        {
            var count = 0;
            foreach (var value in values)
            {
                if (collection.AddUnique(value))
                    count++;
            }
            return count;
        }

        public static void RemoveWhere<T>(this ICollection<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");
            var deleteList = collection.Where(child => predicate(child)).ToList();
            deleteList.ForEach(t => collection.Remove(t));
        }

        public static bool IsBetween<T>(this T value, T minValue, T maxValue) where T : IComparable<T>
        {
            return IsBetween(value, minValue, maxValue, Comparer<T>.Default);
        }

        public static bool IsBetween<T>(this T value, T minValue, T maxValue, IComparer<T> comparer) where T : IComparable<T>
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer");

            var minMaxCompare = comparer.Compare(minValue, maxValue);
            if (minMaxCompare < 0)
                return ((comparer.Compare(value, minValue) >= 0) && (comparer.Compare(value, maxValue) <= 0));
            //else if (minMaxCompare == 0)				// unnecessary  'else' below handles this case.
            //    return (comparer.Compare(value, minValue) == 0);
            else
                return ((comparer.Compare(value, maxValue) >= 0) && (comparer.Compare(value, minValue) <= 0));
        }

        public class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return y.CompareTo(x);
            }
        }

        public class AscendingComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return x.CompareTo(y);
            }
        }

        public static IEnumerable<T> IgnoreNulls<T>(this IEnumerable<T> target)
        {
            if (ReferenceEquals(target, null))
                yield break;

            foreach (var item in target.Where(item => !ReferenceEquals(item, null)))
                yield return item;
        }


        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
        {
            foreach (var i in source)
                yield return i;

            yield return item;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
        {
            yield return item;

            foreach (var i in source)
                yield return i;
        }

        public static uint Sum(this IEnumerable<uint> source)
        {
            return source.Aggregate(0U, (current, number) => current + number);
        }

        public static ulong Sum(this IEnumerable<ulong> source)
        {
            return source.Aggregate(0UL, (current, number) => current + number);
        }

        public static bool InsertUnique<T>(this IList<T> list, int index, T item)
        {
            if (list.Contains(item) == false)
            {
                list.Insert(index, item);
                return true;
            }
            return false;
        }

        public static int InsertRangeUnique<T>(this IList<T> list, int startIndex, IEnumerable<T> items)
        {
            var index = startIndex + items.Reverse().Count(item => list.InsertUnique(startIndex, item));
            return (index - startIndex);
        }

        public static int IndexOf<T>(this IList<T> list, Func<T, bool> comparison)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (comparison(list[i]))
                    return i;
            }
            return -1;
        }

        public static T GetRandomItem<T>(this IList<T> source, Random random)
        {
            if (source.Count > 0)
                // The maxValue for the upper-bound in the Next() method is exclusive, see: http://stackoverflow.com/q/5063269/375958
                return source[random.Next(0, source.Count)];
            else
                throw new InvalidOperationException("Could not get item from empty list.");
        }

        public static T GetRandomItem<T>(this IList<T> source, int seed)
        {
            var random = new Random(seed);
            return source.GetRandomItem(random);
        }

        public static T GetRandomItem<T>(this IList<T> source)
        {
            var random = new Random(DateTime.Now.Millisecond);
            return source.GetRandomItem(random);
        }

        public static List<T> Merge<T>(params List<T>[] lists)
        {
            var merged = new List<T>();
            foreach (var list in lists) merged.Merge(list);
            return merged;
        }

        public static List<T> Merge<T>(Expression<Func<T, object>> match, params List<T>[] lists)
        {
            var merged = new List<T>();
            foreach (var list in lists) merged.Merge(list, match);
            return merged;
        }


        public static List<T> Merge<T>(this List<T> list1, List<T> list2, Expression<Func<T, object>> match)
        {
            if (list1 != null && list2 != null && match != null)
            {
                var matchFunc = match.Compile();
                foreach (var item in list2)
                {
                    var key = matchFunc(item);
                    if (!list1.Exists(i => matchFunc(i).Equals(key))) list1.Add(item);
                }
            }

            return list1;
        }


        public static List<T> Merge<T>(this List<T> list1, List<T> list2)
        {
            if (list1 != null && list2 != null) foreach (var item in list2.Where(item => !list1.Contains(item))) list1.Add(item);
            return list1;
        }

        public static bool IsEven(this long value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(this long value)
        {
            return value % 2 != 0;
        }

        public static bool InRange(this long value, long minValue, long maxValue)
        {
            return (value >= minValue && value <= maxValue);
        }

        public static long InRange(this long value, long minValue, long maxValue, long defaultValue)
        {
            return value.InRange(minValue, maxValue) ? value : defaultValue;
        }

        public static bool IsPrime(this long candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (long i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        }

        public static string ToOrdinal(this long i)
        {
            string suffix = "th";
            switch (i % 100)
            {
                case 11:
                case 12:
                case 13:
                    break;
                default:
                    switch (i % 10)
                    {
                        case 1:
                            suffix = "st";
                            break;
                        case 2:
                            suffix = "nd";
                            break;
                        case 3:
                            suffix = "rd";
                            break;
                    }
                    break;
            }

            return string.Format("{0}{1}", i, suffix);
        }

        public static string ToOrdinal(this long i, string format)
        {
            return string.Format(format, i.ToOrdinal());
        }
    }
}
