﻿using FluentAssertions;
using System;
using Xunit;


namespace Metaphor.Csharp.Extensions.Tests.ResultTests
{
    public class FailedResultTests
    {
        [Fact]
        public void Can_create_a_non_generic_version()
        {
            Result result = Result.Failure("Error message");

            result.Error.Should().Be("Error message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_generic_version()
        {
            Result<MyClass> result = Result.Failure<MyClass>("Error message");

            result.Error.Should().Be("Error message");
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }

        [Fact]
        public void Can_create_a_unit_version()
        {
            var error = new MyErrorClass();
            
            UnitResult<MyErrorClass> result = UnitResult.Failure(error);

            result.Error.Should().Be(error);
            result.IsFailure.Should().Be(true);
            result.IsSuccess.Should().Be(false);
        }
        
        [Fact]
        public void Cannot_access_Value_property()
        {
            Result<MyClass> result = Result.Failure<MyClass>("Error message");

            Action action = () => { MyClass myClass = result.Value; };

            action.Should().Throw<ResultFailureException>()
                .WithMessage("You attempted to access the Value property for a failed result. " +
                    "A failed result has no Value. The error was: Error message");
        }

        [Fact]
        public void Cannot_access_Value_property_with_a_generic_error()
        {
            Result<MyClass, MyErrorClass> result = Result.Failure<MyClass, MyErrorClass>(new MyErrorClass());

            Action action = () => { MyClass myClass = result.Value; };

            action.Should().Throw<ResultFailureException<MyErrorClass>>();
        }

        [Fact]
        public void Cannot_create_without_error_message()
        {
            Action action1 = () => { Result.Failure(null); };
            Action action2 = () => { Result.Failure(string.Empty); };
            Action action3 = () => { Result.Failure<MyClass>(null); };
            Action action4 = () => { Result.Failure<MyClass>(string.Empty); };
            Action action5 = () => { UnitResult.Failure<MyClass>(null); };

            action1.Should().Throw<ArgumentNullException>();
            action2.Should().Throw<ArgumentNullException>();
            action3.Should().Throw<ArgumentNullException>();
            action4.Should().Throw<ArgumentNullException>();
            action5.Should().Throw<ArgumentNullException>();
        }


        private class MyClass
        {
        }

        private class MyErrorClass
        {
        }
    }
}
