// Copyright 2023 murnana.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#nullable enable
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Murnana.UGUI.Extensions.TMPro
{
    /// <summary>
    /// Extension Methods for <see cref="global::TMPro.TMP_FontAsset" />
    /// </summary>
    [Il2CppSetOption(option: Option.NullChecks, value: false)]
    [Il2CppSetOption(option: Option.ArrayBoundsChecks, value: false)]
    [Il2CppSetOption(option: Option.DivideByZeroChecks, value: false)]
    internal static class TMP_FontAssetExtensions
    {
        /// <summary>
        /// call <see cref="global::UnityEngine.Object.Destroy(global::UnityEngine.Object)" /> if <paramref name="self" /> is
        /// Playing,
        /// or <see cref="global::UnityEngine.Object.DestroyImmediate(global::UnityEngine.Object, bool)" /> if
        /// <paramref name="self" /> is Not Playing
        /// </summary>
        /// <param name="self"></param>
        [MethodImpl(methodImplOptions: MethodImplOptions.AggressiveInlining)]
        internal static void DestroyDynamic(this TMP_FontAsset self)
        {
            Assert.IsNotNull(
                value: self,
                nameOfValue: nameof(self)
            );
            Assert.AreEqual(
                actual: self.atlasPopulationMode,
                expected: AtlasPopulationMode.Dynamic,
                comparer: EqualityComparer<AtlasPopulationMode>.Default,
                nameOfActual: $"{nameof(self)}.{nameof(self.atlasPopulationMode)}"
            );

            self.ClearFontAssetData(
                setAtlasSizeToZero: true
            );

            #if UNITY_EDITOR
            if(!Application.IsPlaying(obj: self))
            {
                Object.DestroyImmediate(
                    obj: self,
                    allowDestroyingAssets: true
                );
                return;
            }
            #endif

            Object.Destroy(obj: self);
        }
    }
}
