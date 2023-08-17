﻿using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions.Tests.ResultTests.Extensions;

public class EnsureNotNullTests_Base : TestBase
{
    protected bool factoryExecuted;

    protected Func<E> GetErrorFactory<E>(E e)
    {
        return () =>
        {
            factoryExecuted = true;

            return e;
        };
    }

    protected Func<Task<E>> GetTaskErrorFactory<E>(E e) => GetErrorFactory(Task.FromResult(e));

    protected Func<ValueTask<E>> GetValueTaskErrorFactory<E>(E e) => GetErrorFactory(ValueTask.FromResult(e));

    protected struct V
    {
        public static readonly V Value = new V();
    }
}
