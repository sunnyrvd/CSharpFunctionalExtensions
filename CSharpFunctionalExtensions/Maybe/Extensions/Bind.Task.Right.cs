using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class MaybeExtensions
    {
        public static Task<Maybe<K>> Bind<T, K>(this Maybe<T> maybe, Func<T, Task<Maybe<K>>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None.AsCompletedTask();

            return selector(maybe.GetValueOrThrow());
        }
    }
}
