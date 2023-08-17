using System;

namespace Metaphor.Csharp.Extensions
{
    public static partial class MaybeExtensions
    {
        public static Maybe<K> Map<T, K>(in this Maybe<T> maybe, Func<T, K> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return selector(maybe.GetValueOrThrow());
        }
    }
}
