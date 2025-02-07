﻿#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Result<T>> ToResult<T>(this ValueTask<Maybe<T>> maybeTask, string errorMessage)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.ToResult(errorMessage);
        }

        public static async ValueTask<Result<T, E>> ToResult<T, E>(this ValueTask<Maybe<T>> maybeTask, E error)
        {
            Maybe<T> maybe = await maybeTask;
            return maybe.ToResult(error);
        }
    }
}
#endif
