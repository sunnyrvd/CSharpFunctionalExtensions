using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static Task<Result<T>> CheckIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Result<T>> CheckIf<T, K>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<K>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> CheckIf<T, K, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Result<K, E>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<Result<T, E>> CheckIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, UnitResult<E>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<UnitResult<E>> func)
        {
            if (condition)
                return resultTask.Check(func);
            else
                return resultTask;
        }

        public static async Task<Result<T>> CheckIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async Task<Result<T>> CheckIf<T, K>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<K>> func)
        {
            Result<T> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async Task<Result<T, E>> CheckIf<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<K, E>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async Task<Result<T, E>> CheckIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, UnitResult<E>> func)
        {
            Result<T, E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate(result.Value))
                return result.Check(func);
            else
                return result;
        }

        public static async Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<UnitResult<E>> func)
        {
            UnitResult<E> result = await resultTask.DefaultAwait();

            if (result.IsSuccess && predicate())
                return result.Check(func);
            else
                return result;
        }
    }
}
