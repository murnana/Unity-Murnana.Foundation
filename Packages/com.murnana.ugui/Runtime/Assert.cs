// Copyright 2023 murnana.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace Murnana.UGUI
{
    /// <summary>
    /// <para>The Assert class contains assertion methods for setting invariants in the code.</para>
    /// </summary>
    /// <seealso cref="global::UnityEngine.Assertions.Assert" />
    [DebuggerStepThrough]
    internal static class Assert
    {
        /// <summary>
        /// Check <paramref name="value" /> is not null
        /// </summary>
        /// <param name="value">check value</param>
        /// <param name="nameOfValue"><paramref name="value" />name</param>
        /// <typeparam name="TClass">Any type</typeparam>
        /// <exception cref="AssertionException"></exception>
        [Conditional("UNITY_ASSERTIONS")]
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public static void IsNotNull<TClass>(TClass? value, string? nameOfValue)
        {
            if(typeof(Object).IsAssignableFrom(typeof(TClass)))
            {
                IsNotNull(value: value as Object, nameOfValue: nameOfValue);
                return;
            }

            if(value != null)
            {
                return;
            }

            throw new AssertionException(
                message: $"({nameOfValue} != null) but {value}.",
                userMessage: null
            );
        }

        /// <summary>
        /// Check <paramref name="value" /> is not null
        /// </summary>
        /// <param name="value">check value</param>
        /// <param name="nameOfValue"><paramref name="value" />name</param>
        /// <exception cref="AssertionException"></exception>
        [Conditional("UNITY_ASSERTIONS")]
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        internal static void IsNotNull(Object? value, string? nameOfValue)
        {
            if(value != null)
            {
                return;
            }

            throw new AssertionException(
                message: $"({nameOfValue} != null) but {value}.",
                userMessage: null
            );
        }

        /// <summary>
        /// Check <paramref name="actual" /> is equal to <see cref="expected" />
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="nameOfActual">name of <paramref name="actual" /></param>
        /// <param name="nameOfExpected">name of <paramref name="expected" /></param>
        /// <exception cref="AssertionException"></exception>
        [Conditional("UNITY_ASSERTIONS")]
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        internal static void AreEqual<T>
        (
            T       actual,
            T       expected,
            string? nameOfActual,
            string? nameOfExpected = null
        ) where T : IEquatable<T>
        {
            if(actual.Equals(expected))
            {
                return;
            }

            throw new AssertionException(
                message: $"({expected} == {nameOfActual}) but {actual}."
                       + (nameOfExpected != null ? $"(expected: {nameOfExpected})" : string.Empty),
                userMessage: null
            );
        }

        /// <summary>
        /// Check <paramref name="actual" /> is equal to <see cref="expected" />
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="comparer"></param>
        /// <param name="nameOfActual">name of <paramref name="actual" /></param>
        /// <param name="nameOfExpected">name of <paramref name="expected" /></param>
        /// <exception cref="AssertionException"></exception>
        [Conditional("UNITY_ASSERTIONS")]
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        internal static void AreEqual<T, TEqualityComparer>
        (
            T                 actual,
            T                 expected,
            TEqualityComparer comparer,
            string?           nameOfActual,
            string?           nameOfExpected = null
        ) where TEqualityComparer : IEqualityComparer<T>
        {
            if(comparer.Equals(x: actual, y: expected))
            {
                return;
            }

            throw new AssertionException(
                message: $"({expected} == {nameOfActual}) but {actual}."
                       + (nameOfExpected != null ? $"(expected: {nameOfExpected})" : string.Empty),
                userMessage: null
            );
        }

        /// <summary>
        /// Check <paramref name="actual" /> is greater or equal to <see cref="expected" />
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="nameOfActual">name of <paramref name="actual" /></param>
        /// <param name="nameOfExpected">name of <paramref name="expected" /></param>
        /// <exception cref="AssertionException"></exception>
        [Conditional("UNITY_ASSERTIONS")]
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        internal static void GreaterOrEqual<T>
        (
            T       actual,
            T       expected,
            string? nameOfActual,
            string? nameOfExpected = null
        )
            where T : IComparable<T>
        {
            if(actual.CompareTo(expected) >= 0)
            {
                return;
            }

            throw new AssertionException(
                message: $"({nameOfActual} >= {expected}) but {actual}."
                       + (nameOfExpected != null ? $"(expected: {nameOfExpected})" : string.Empty),
                userMessage: null
            );
        }

        /// <summary>
        /// Check <paramref name="value" /> is defined <typeparamref name="TEnum" />
        /// </summary>
        /// <param name="value">check value</param>
        /// <param name="nameOfValue"><paramref name="value" />name</param>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <exception cref="AssertionException"></exception>
        [Conditional("UNITY_ASSERTIONS")]
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        internal static void IsDefined<TEnum>(TEnum value, string? nameOfValue)
            where TEnum : Enum
        {
            var type = typeof(TEnum);
            if(Enum.IsDefined(enumType: typeof(TEnum), value: value))
            {
                return;
            }

            throw new AssertionException(
                message: $"Enum.IsDefined({type.AssemblyQualifiedName}, {nameOfValue}) but {value}.",
                userMessage: null
            );
        }
    }
}
