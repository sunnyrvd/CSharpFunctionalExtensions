using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Metaphor.Csharp.Extensions.Tests.ResultTests.Extensions
{
    public class BindIfTests_Task_Right : BindIfTestsBase
    {
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public async Task BindIf_Task_Right_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition, bool isSuccessAction)
        {
            Task<Result> resultTask = Result.SuccessIf(isSuccess, ErrorMessage).AsTask();

            Result returned = await resultTask.BindIf(condition, GetAction(isSuccessAction));

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedResult(isSuccess, condition, isSuccessAction));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public async Task BindIf_Task_Right_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition, bool isSuccessAction)
        {
            Task<Result<T>> resultTask = Result.SuccessIf(isSuccess, T.Value, ErrorMessage).AsTask();

            Result<T> returned = await resultTask.BindIf(condition, GetValueAction(isSuccessAction));

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition, isSuccessAction));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public async Task BindIf_Task_Right_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition, bool isSuccessAction)
        {
            Task<UnitResult<E>> resultTask = UnitResult.SuccessIf(isSuccess, E.Value).AsTask();

            UnitResult<E> returned = await resultTask.BindIf(condition, GetErrorAction(isSuccessAction));

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedErrorResult(isSuccess, condition, isSuccessAction));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public async Task BindIf_Task_Right_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition, bool isSuccessAction)
        {
            Task<Result<T, E>> resultTask = Result.SuccessIf(isSuccess, T.Value, E.Value).AsTask();

            Result<T, E> returned = await resultTask.BindIf(condition, GetValueErrorAction(isSuccessAction));

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition, isSuccessAction));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public async Task BindIf_Task_Right_computes_predicate_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition, bool isSuccessAction)
        {
            Task<Result> resultTask = Result.SuccessIf(isSuccess, ErrorMessage).AsTask();

            Result returned = await resultTask.BindIf(GetPredicate(condition), GetAction(isSuccessAction));

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedResult(isSuccess, condition, isSuccessAction));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public async Task BindIf_Task_Right_computes_predicate_T_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition, bool isSuccessAction)
        {
            Task<Result<T>> resultTask = Result.SuccessIf(isSuccess, T.Value, ErrorMessage).AsTask();

            Result<T> returned = await resultTask.BindIf(GetValuePredicate(condition), GetValueAction(isSuccessAction));

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition, isSuccessAction));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public async Task BindIf_Task_Right_computes_predicate_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition, bool isSuccessAction)
        {
            Task<UnitResult<E>> resultTask = UnitResult.SuccessIf(isSuccess, E.Value).AsTask();

            UnitResult<E> returned = await resultTask.BindIf(GetPredicate(condition), GetErrorAction(isSuccessAction));

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedErrorResult(isSuccess, condition, isSuccessAction));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, false, false)]
        public async Task BindIf_Task_Right_computes_predicate_T_E_executes_func_conditionally_and_returns_new_result(bool isSuccess, bool condition, bool isSuccessAction)
        {
            Task<Result<T, E>> resultTask = Result.SuccessIf(isSuccess, T.Value, E.Value).AsTask();

            Result<T, E> returned = await resultTask.BindIf(GetValuePredicate(condition), GetValueErrorAction(isSuccessAction));

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition, isSuccessAction));
        }
    }
}
