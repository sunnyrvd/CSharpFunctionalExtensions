﻿#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given async <paramref name="valueTask" /> if the <paramref name="maybe" /> has no value
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="valueTask"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task ExecuteNoValue<T>(this Maybe<T> maybe, Func<ValueTask> valueTask)
        {
            if (maybe.HasValue)
                return;

            await valueTask();
        }
    }
}
#endif
