using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T>> Check<T>(this Result<T> result, Func<T, Task<Result>> func)
        {
            return await result.Bind(func).Map(() => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T>> Check<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
        {
            return await result.Bind(func).Map(_ => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T, E>> Check<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func)
        {
            return await result.Bind(func).Map(_ => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T, E>> Check<T, E>(this Result<T, E> result, Func<T, Task<UnitResult<E>>> func)
        {
            return await result.Bind(func).Map(() => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<UnitResult<E>> Check<E>(this UnitResult<E> result, Func<Task<UnitResult<E>>> func)
        {
            return await result.Bind(func).Map(() => result).DefaultAwait();
        }
    }
}
