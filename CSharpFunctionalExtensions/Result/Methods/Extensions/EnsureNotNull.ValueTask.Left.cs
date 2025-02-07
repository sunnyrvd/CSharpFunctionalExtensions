#if NET5_0_OR_GREATER
#nullable enable

using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Result<T>> EnsureNotNull<T>(this ValueTask<Result<T?>> resultTask, Func<string> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        public static ValueTask<Result<T>> EnsureNotNull<T>(this ValueTask<Result<T?>> resultTask, Func<string> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }

        public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this ValueTask<Result<T?, E>> resultTask, Func<E> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this ValueTask<Result<T?, E>> resultTask, Func<E> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
#endif
