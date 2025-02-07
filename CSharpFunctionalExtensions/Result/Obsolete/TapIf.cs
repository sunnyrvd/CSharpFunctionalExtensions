using System;
using System.ComponentModel;

namespace Metaphor.Csharp.Extensions
{
    public static partial class ResultExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Result<T> TapIf<T>(this Result<T> result, bool condition, Func<T, Result> func) =>
            CheckIf(result, condition, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Result<T> TapIf<T, K>(this Result<T> result, bool condition, Func<T, Result<K>> func) =>
            CheckIf(result, condition, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Result<T, E> TapIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, Result<K, E>> func) =>
            CheckIf(result, condition, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Result<T> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result> func) =>
            CheckIf(result, predicate, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Result<T> TapIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<K>> func) =>
            CheckIf(result, predicate, func);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use CheckIf() instead.")]
        public static Result<T, E> TapIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Result<K, E>> func) =>
            CheckIf(result, predicate, func);
    }
}
