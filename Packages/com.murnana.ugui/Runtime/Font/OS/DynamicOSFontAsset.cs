// Copyright 2023 murnana.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#nullable enable
using System;
using Murnana.UGUI.Extensions.UnityEngine;
using Unity.Burst.CompilerServices;
using UnityEngine.Assertions;

namespace Murnana.UGUI.Font.OS
{
    /// <summary>
    /// Dynamic font object which lets you render a font installed on the operating system.
    /// </summary>
    public readonly struct DynamicOSFontAsset : IUnityEngineFontAsset,
                                                IDisposable
    {
        /// <summary>
        /// The default character size of the generated font.
        /// </summary>
        /// <seealso cref="global::UnityEngine.Font.CreateDynamicFontFromOSFont(string[], int)" />
        public readonly int Size;


        /// <summary>
        /// Creates a Font object which lets you render a font installed on the operating system.
        /// </summary>
        /// <seealso cref="global::UnityEngine.Font.GetPathsToOSFonts" />
        /// <seealso cref="global::UnityEngine.Font.CreateDynamicFontFromOSFont(string[], int)" />
        public static DynamicOSFontAsset Get([AssumeRange(0, int.MaxValue)] in int size)
        {
            Assert.GreaterOrEqual(actual: size, expected: 0, nameOfActual: nameof(size));

            var font = UnityEngine.Font.CreateDynamicFontFromOSFont(
                fontnames: UnityEngine.Font.GetPathsToOSFonts(),
                size: size
            );
            return new DynamicOSFontAsset(font: font, size: in size);
        }


        #region Implementation of IUnityEngineFont

        /// <inheritdoc />
        public UnityEngine.Font Font
        {
            get
            {
                Assert.IsNotNull(value: m_Font, nameOfValue: nameof(m_Font));
                return m_Font;
            }
        }

        #endregion


        #region IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            Assert.IsNotNull(value: m_Font, nameOfValue: nameof(m_Font));
            m_Font.Destroy();
        }

        #endregion


        #region Private

        #region Private menber methods

        private DynamicOSFontAsset(UnityEngine.Font font, in int size)
        {
            Assert.IsNotNull(value: font, nameOfValue: nameof(font));
            m_Font = font;
            Size   = size;
        }

        #endregion

        #region Private menber values

        /// <summary>
        /// The generate Font object.
        /// </summary>
        /// <seealso cref="global::UnityEngine.Font.CreateDynamicFontFromOSFont(string[], int)" />
        [NonSerialized]
        private readonly UnityEngine.Font m_Font;

        #endregion

        #endregion
    }
}
