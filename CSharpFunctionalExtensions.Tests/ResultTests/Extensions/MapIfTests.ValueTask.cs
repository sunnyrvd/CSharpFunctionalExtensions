using System.Threading.Tasks;
using Metaphor.Csharp.Extensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace Metaphor.Csharp.Extensions.Tests.ResultTests.Extensions
{
    public class MapIfTests_ValueTask : MapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            ValueTask<Result<T>> resultTask = Result.SuccessIf(isSuccess, T.Value, ErrorMessage).AsValueTask();

            Result<T> returned = await resultTask.MapIf(condition, GetValueTaskAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            ValueTask<Result<T, E>> resultTask = Result.SuccessIf(isSuccess, T.Value, E.Value).AsValueTask();

            Result<T, E> returned = await resultTask.MapIf(condition, GetValueTaskAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_computes_predicate_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            ValueTask<Result<T>> resultTask = Result.SuccessIf(isSuccess, T.Value, ErrorMessage).AsValueTask();

            Result<T> returned = await resultTask.MapIf(GetValuePredicate(condition), GetValueTaskAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_computes_predicate_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition)
        {
            ValueTask<Result<T, E>> resultTask = Result.SuccessIf(isSuccess, T.Value, E.Value).AsValueTask();

            Result<T, E> returned = await resultTask.MapIf(GetValuePredicate(condition), GetValueTaskAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }
    }
}
