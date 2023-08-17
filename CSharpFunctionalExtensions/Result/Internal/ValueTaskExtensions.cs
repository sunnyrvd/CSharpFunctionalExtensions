#if NET5_0_OR_GREATER
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions.ValueTasks
{
    internal static class ValueTaskExtensions
    {
        public static ValueTask<T> AsCompletedValueTask<T>(this T obj) => ValueTask.FromResult(obj);
    }
}
#endif
