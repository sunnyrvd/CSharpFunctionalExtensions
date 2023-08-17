using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<K>> Map<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.Map(selector).DefaultAwait();
        }
    }
}
