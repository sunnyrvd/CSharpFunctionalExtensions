using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class AsyncResultExtensionsBothOperands
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T>> Check<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return await result.Bind(func).Map(() => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T>> Check<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return await result.Bind(func).Map(_ => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T, E>> Check<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).Map(_ => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<Result<T, E>> Check<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<UnitResult<E>>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).Map(() => result.Value).DefaultAwait();
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async Task<UnitResult<E>> Check<E>(this Task<UnitResult<E>> resultTask, Func<Task<UnitResult<E>>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();
            return await result.Bind(func).Map(() => result).DefaultAwait();
        }
    }
}
