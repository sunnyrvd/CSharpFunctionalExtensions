﻿using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Metaphor.Csharp.Extensions.Tests.MaybeTests.Extensions
{
    public class ExecuteNoValueTests_Task_Right : MaybeTestBase
    {
        [Fact]
        public async Task ExecuteNoValue_Task_Right_executes_action_when_no_value()
        {
            string property = null;

            Maybe<T> maybe = null;

            await maybe.ExecuteNoValue(() =>
            {
                property = "Some value";
                return Task.CompletedTask;
            });

            property.Should().Be("Some value");
        }
    }
}
