using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result> TapIf(this Task<Result> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action<T> action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static Task<UnitResult<E>> TapIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Action action)
        {
            if (condition)
                return resultTask.Tap(action);
            else
                return resultTask;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action action)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action<T> action)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Action action)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Action<T> action)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return result.Tap(action);
            else
                return result;
        }

        /// <summary>
        ///     Executes the given action if the calling result is a success and condition is true. Returns the calling result.
        /// </summary>
        public static async Task<UnitResult<E>> TapIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Action action)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate())
                return result.Tap(action);
            else
                return result;
        }
    }
}
