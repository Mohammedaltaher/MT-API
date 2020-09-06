using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace  AggriPortal.API.Extensions
{
    public static class LinqExtension
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
    where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
        public static Task ForEachAsync<T>(this IEnumerable<T> sequence, Func<T, Task> action)
        {
            return Task.WhenAll(sequence.Select(action));
        }

        public static async Task<IList<TResult>> SelectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, int maxDegreesOfParallelism = 4)
        {
            var results = new List<TResult>();
            var activeTasks = new HashSet<Task<TResult>>();
            foreach (var item in source)
            {
                activeTasks.Add(selector(item));
                if (activeTasks.Count >= maxDegreesOfParallelism)
                {
                    var completed = await Task.WhenAny(activeTasks);
                    activeTasks.Remove(completed);
                    results.Add(completed.Result);
                }
            }
            results.AddRange(await Task.WhenAll(activeTasks).ConfigureAwait(false));
            return results;
        }

        public static string DictToString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            string dictionaryString = "{";
            foreach (KeyValuePair<TKey, TValue> keyValues in dictionary)
            {
                dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";
            }
            return dictionaryString.TrimEnd(',', ' ') + "}";

            //var items = from kvp in dictionary
            //            select kvp.Key + ":" + kvp.Value;

            //return "{" + string.Join(",", items) + "}";
        }

        #region Not Used Yet Keep it
        /// <summary>
        /// Splits collection into number of collections of nearly equal size.
        /// </summary>
        public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> src, int slicesCount)
        {
            if (slicesCount <= 0) throw new ArgumentOutOfRangeException(nameof(slicesCount));

            List<T> source = src.ToList();
            var sourceIndex = 0;
            for (var targetIndex = 0; targetIndex < slicesCount; targetIndex++)
            {
                var list = new List<T>();
                int itemsLeft = source.Count - targetIndex;
                while (slicesCount * list.Count < itemsLeft)
                {
                    list.Add(source[sourceIndex++]);
                }

                yield return list;
            }
        }

        /// <summary>
        /// Takes collection of collections, projects those in parallel and merges results.
        /// </summary>
        public static async Task<IEnumerable<TResult>> SelectManyAsync<T, TResult>(
            this IEnumerable<IEnumerable<T>> source,
            Func<T, Task<TResult>> func)
        {
            List<TResult>[] slices = await source
                .Select(async slice => await slice.SelectListAsync(func).ConfigureAwait(false))
                .WhenAll()
                .ConfigureAwait(false);
            return slices.SelectMany(s => s);
        }

        /// <summary>Runs selector and awaits results.</summary>
        public static async Task<List<TResult>> SelectListAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            List<TResult> result = new List<TResult>();
            foreach (TSource source1 in source)
            {
                TResult result1 = await selector(source1).ConfigureAwait(false);
                result.Add(result1);
            }
            return result;
        }

        /// <summary>Wraps tasks with Task.WhenAll.</summary>
        public static Task<TResult[]> WhenAll<TResult>(this IEnumerable<Task<TResult>> source)
        {
            return Task.WhenAll<TResult>(source);
        }


        /// how to use them?
        /// double[] result2 = await Enumerable.Range(0, 1000000)
        ///.Select(async i => await CalculateAsync(i).ConfigureAwait(false))
        ///.WhenAll()
        ///.ConfigureAwait(false);
        #endregion
    }
}
