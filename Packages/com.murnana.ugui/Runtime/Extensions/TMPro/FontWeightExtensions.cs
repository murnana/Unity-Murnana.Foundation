// Copyright 2023 murnana.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#nullable enable
using System;
using TMPro;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Murnana.UGUI.Extensions.TMPro
{
    /// <summary>
    /// Extension methods from <see cref="global::TMPro.FontWeight" />
    /// </summary>
    [BurstCompile]
    [Il2CppSetOption(option: Option.NullChecks, value: false)]
    [Il2CppSetOption(option: Option.ArrayBoundsChecks, value: false)]
    [Il2CppSetOption(option: Option.DivideByZeroChecks, value: false)]
    internal static class FontWeightExtensions
    {
        /// <summary>
        /// Get <see cref="global::TMPro.TMP_FontAsset.fontWeightTable" /> index
        /// from <see cref="global::TMPro.FontWeight" />
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <seealso cref="global::TMPro.TMP_FontAssetUtilities.GetCharacterFromFontAsset_Internal" />
        [return: AssumeRange(min: 1, max: 9)]
        internal static int GetFontWeightTableIndex(this FontWeight self)
        {
            return self switch
            {
                FontWeight.Thin       => 1,
                FontWeight.ExtraLight => 2,
                FontWeight.Light      => 3,
                FontWeight.Regular    => 4,
                FontWeight.Medium     => 5,
                FontWeight.SemiBold   => 6,
                FontWeight.Bold       => 7,
                FontWeight.Heavy      => 8,
                FontWeight.Black      => 9,
                _ => throw new ArgumentOutOfRangeException(
                        paramName: nameof(self),
                        actualValue: self,
                        message: null
                    )
            };
        }
    }
}
