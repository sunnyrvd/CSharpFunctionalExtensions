using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public static partial class MaybeExtensions
    {
        public static async Task<Maybe<T>> Where<T>(this Task<Maybe<T>> maybeTask, Func<T, Task<bool>> predicate)
        {
            var maybe = await maybeTask.DefaultAwait();
            return await maybe.Where(predicate).DefaultAwait();
        }
    }
}
