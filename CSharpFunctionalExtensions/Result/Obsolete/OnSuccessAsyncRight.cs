using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Map() instead.")]
        public static Task<Result<K, E>> OnSuccess<T, K, E>(this Result<T, E> result, Func<T, Task<K>> func)
            => Map(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Map() instead.")]
        public static Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<T, Task<K>> func)
            => Map(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Map() instead.")]
        public static Task<Result<K>> OnSuccess<K>(this Result result, Func<Task<K>> func)
            => Map(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Bind() instead.")]
        public static Task<Result<K, E>> OnSuccess<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func)
            => Bind(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Bind() instead.")]
        public static Task<Result<K>> OnSuccess<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
            => Bind(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Bind() instead.")]
        public static Task<Result<K>> OnSuccess<K>(this Result result, Func<Task<Result<K>>> func)
            => Bind(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Bind() instead.")]
        public static Task<Result> OnSuccess<T>(this Result<T> result, Func<T, Task<Result>> func)
            => Bind(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Bind() instead.")]
        public static Task<Result> OnSuccess(this Result result, Func<Task<Result>> func)
            => Bind(result, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Tap() instead.")]
        public static Task<Result<T, E>> OnSuccess<T, E>(this Result<T, E> result, Func<T, Task> action)
            => Tap(result, action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Tap() instead.")]
        public static Task<Result<T>> OnSuccess<T>(this Result<T> result, Func<T, Task> action)
            => Tap(result, action);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use Tap() instead.")]
        public static Task<Result> OnSuccess(this Result result, Func<Task> action)
            => Tap(result, action);
    }
}
