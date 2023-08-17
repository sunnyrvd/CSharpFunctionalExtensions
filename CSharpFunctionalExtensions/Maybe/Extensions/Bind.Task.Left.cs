using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<K>> Bind<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Maybe<K>> selector)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.Bind(selector);
        }
    }
}
