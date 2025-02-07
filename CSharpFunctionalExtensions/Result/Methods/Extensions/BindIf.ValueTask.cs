#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Result> BindIf(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result>> valueTask)
        {
            var result = await resultTask;
            return await result.BindIf(condition, valueTask);
        }

        public static async ValueTask<Result<T>> BindIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<T>>> valueTask)
        {
            var result = await resultTask;
            return await result.BindIf(condition, valueTask);
        }

        public static async ValueTask<UnitResult<E>> BindIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            var result = await resultTask;
            return await result.BindIf(condition, valueTask);
        }

        public static async ValueTask<Result<T, E>> BindIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, ValueTask<Result<T, E>>> valueTask)
        {
            var result = await resultTask;
            return await result.BindIf(condition, valueTask);
        }

        public static async ValueTask<Result> BindIf(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask<Result>> valueTask)
        {
            var result = await resultTask;
            return await result.BindIf(predicate, valueTask);
        }

        public static async ValueTask<Result<T>> BindIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> valueTask)
        {
            var result = await resultTask;
            return await result.BindIf(predicate, valueTask);
        }

        public static async ValueTask<UnitResult<E>> BindIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<ValueTask<UnitResult<E>>> valueTask)
        {
            
            var result = await resultTask;
            return await result.BindIf(predicate, valueTask);
        }

        public static async ValueTask<Result<T, E>> BindIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<T, E>>> valueTask)
        {
            var result = await resultTask;
            return await result.BindIf(predicate, valueTask);
        }
    }
}
#endif
