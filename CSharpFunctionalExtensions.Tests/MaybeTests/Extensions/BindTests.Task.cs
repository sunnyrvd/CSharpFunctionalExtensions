﻿using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Metaphor.Csharp.Extensions.Tests.MaybeTests.Extensions
{
    public class BindTests_Task : MaybeTestBase
    {
        [Fact]
        public async Task Bind_Task_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<T> maybe = null;

            var maybe2 = await maybe.AsTask().Bind(ExpectAndReturnMaybe_Task(null, T.Value));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Bind_Task_returns_no_value_if_selector_returns_null()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.AsTask().Bind(ExpectAndReturn_Task(T.Value, Maybe<T>.None));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Bind_Task_returns_value_if_selector_returns_value()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.AsTask().Bind(ExpectAndReturnMaybe_Task<T>(T.Value, T.Value));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value);
        }
    }
}
