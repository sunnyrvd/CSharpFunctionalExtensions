﻿using System.Threading.Tasks;

#if NET40
using Task = System.Threading.Tasks.TaskEx;
using Microsoft.Runtime.CompilerServices;
#else
using Task = System.Threading.Tasks.Task;
using System.Runtime.CompilerServices;
#endif

namespace Metaphor.Csharp.Extensions
{
    internal static class TaskExtensions
    {
        public static Task<T> AsCompletedTask<T>(this T obj) => Task.FromResult(obj);

        public static ConfiguredTaskAwaitable DefaultAwait(this System.Threading.Tasks.Task task) =>
            task.ConfigureAwait(Result.Configuration.DefaultConfigureAwait);

        public static ConfiguredTaskAwaitable<T> DefaultAwait<T>(this Task<T> task) =>
            task.ConfigureAwait(Result.Configuration.DefaultConfigureAwait);
    }
}
