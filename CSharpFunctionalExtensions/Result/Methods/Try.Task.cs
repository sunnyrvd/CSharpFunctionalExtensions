﻿using System;
using System.Threading.Tasks;

namespace Metaphor.Csharp.Extensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Attempts to execute the supplied action. Returns a Result indicating whether the action executed successfully.
        /// </summary>
        public static async Task<Result> Try(Func<Task> action, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Configuration.DefaultTryErrorHandler;

            try
            {
                await action().DefaultAwait();
                return Success();
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure(message);
            }
        }
        
        /// <summary>
        ///     Attempts to execute the supplied function. Returns a Result indicating whether the function executed successfully.
        ///     If the function executed successfully, the result contains its return value.
        /// </summary>
        public static async Task<Result<T>> Try<T>(Func<Task<T>> func, Func<Exception, string> errorHandler = null)
        {
            errorHandler ??= Configuration.DefaultTryErrorHandler;

            try
            {
                var result = await func().DefaultAwait();
                return Success(result);
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Failure<T>(message);
            }
        }
        
        /// <summary>
        ///     Attempts to execute the supplied function. Returns a Result indicating whether the function executed successfully.
        ///     If the function executed successfully, the result contains its return value.
        /// </summary>
        public static async Task<Result<T, E>> Try<T, E>(Func<Task<T>> func, Func<Exception, E> errorHandler)
        {
            try
            {
                var result = await func().DefaultAwait();
                return Success<T, E>(result);
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Failure<T, E>(error);
            }
        }
    }
}
