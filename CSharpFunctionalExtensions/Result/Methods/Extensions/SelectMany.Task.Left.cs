using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async Task<Result<TR>> SelectMany<T, TK, TR>(
            this Task<Result<T>> resultTask,
            Func<T, Result<TK>> func,
            Func<T, TK, TR> project)
        {
            Result<T> result = await resultTask.DefaultAwait();
            return result.SelectMany(func, project);
        }

        /// <summary>
        ///     This method should be used in linq queries. We recommend using Bind method.
        /// </summary>
        public static async Task<Result<TR, TE>> SelectMany<T, TK, TE, TR>(
            this Task<Result<T, TE>> resultTask,
            Func<T, Result<TK, TE>> func,
            Func<T, TK, TR> project)
        {
            Result<T, TE> result = await resultTask.DefaultAwait();
            return result.SelectMany(func, project);
        }
    }
}
