﻿using System.Threading.Tasks;
using System;

namespace Metaphor.Csharp.Extensions
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Result<K, E>> BindTry<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Result.Failure<K, E>(result.Error)
                : await Result.Try(() => func(result.Value),errorHandler).Bind(r => r).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>        
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Result<K>> BindTry<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<K>(result.Error)
                : await Result.Try(() => func(result.Value), errorHandler).Bind(r => r).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="K"><paramref name="func" /> Result Type parameter</typeparam>        
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Result<K>> BindTry<K>(this Result result, Func<Task<Result<K>>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure<K>(result.Error)
                : await Result.Try(() => func(), errorHandler).Bind(r => r).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Result> BindTry<T>(this Result<T> result, Func<T, Task<Result>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : await Result.Try(() => func(result.Value), errorHandler).Bind(r => r).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Result> BindTry(this Result result, Func<Task<Result>> func,
            Func<Exception, string> errorHandler = null)
        {
            return result.IsFailure
                ? Result.Failure(result.Error)
                : await Result.Try(() => func(), errorHandler).Bind(r => r).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<UnitResult<E>> BindTry<E>(this UnitResult<E> result, Func<Task<UnitResult<E>>> func,
            Func<Exception, E> errorHandler)
        {            
            return result.IsFailure
                ? UnitResult.Failure(result.Error)
                : await Result.Try(() => func(), errorHandler).Bind(r => r).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<Result<T, E>> BindTry<T, E>(this UnitResult<E> result, Func<Task<Result<T, E>>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? Result.Failure<T,E>(result.Error)
                : await Result.Try(() => func(), errorHandler).Bind(r => r).DefaultAwait();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        ///     If a given function throws an exception, an error is returned from the given error handler
        /// </summary>
        /// <typeparam name="T">Result Type parameter</typeparam>        
        /// <typeparam name="E">Error Type parameter</typeparam>
        /// <param name="result">Extended result</param>
        /// <param name="func">Function returning result to bind</param>
        /// <param name="errorHandler">Error handling function</param>        
        /// <returns>Binding result</returns>
        public static async Task<UnitResult<E>> BindTry<T, E>(this Result<T, E> result, Func<T, Task<UnitResult<E>>> func,
            Func<Exception, E> errorHandler)
        {
            return result.IsFailure
                ? UnitResult.Failure(result.Error)
                : await Result.Try(() => func(result.Value), errorHandler).Bind(r => r).DefaultAwait();           
        }
    }
}
