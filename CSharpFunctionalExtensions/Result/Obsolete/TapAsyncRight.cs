using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Task<Result<T>> Tap<T>(this Result<T> result, Func<T, Task<Result>> func) => Check(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Task<Result<T>> Tap<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func) =>
            Check(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Check() instead.")]
        public static Task<Result<T, E>> Tap<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func) =>
            Check(result, func);
    }
}
