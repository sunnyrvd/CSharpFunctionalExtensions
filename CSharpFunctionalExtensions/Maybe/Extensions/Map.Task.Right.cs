using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<K>> Map<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await selector(maybe.GetValueOrThrow()).DefaultAwait();
        }
    }
}
