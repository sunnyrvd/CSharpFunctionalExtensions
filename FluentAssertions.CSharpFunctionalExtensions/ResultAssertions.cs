using Metaphor.Csharp.Extensions;
using FluentAssertions.Execution;
using System;

namespace FluentAssertions.CSharpFunctionalExtensions
{
    public class ResultAssertions : BaseResultAssertions<Result>
    {
        public ResultAssertions(Result subject) : base(subject)
        {
        }

        protected override Func<FailReason> GetErrorMessageFromSubject()
        {
            return () => new FailReason($"Expected {{context:result}} to be Success{{reason}}, but it is failure with error '{Subject.Error}'");
        }
    }
}
