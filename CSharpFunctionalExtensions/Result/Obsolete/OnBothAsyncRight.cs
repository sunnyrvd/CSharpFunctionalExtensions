using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<T> OnBoth<T>(this Result result, Func<Result, Task<T>> func)
            => Finally(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<K> OnBoth<T, K>(this Result<T> result, Func<Result<T>, Task<K>> func)
            => Finally(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Finally() instead.")]
        public static Task<K> OnBoth<T, K, E>(this Result<T, E> result, Func<Result<T, E>, Task<K>> func)
            => Finally(result, func);
    }
}
