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
using System.Linq;
using Murnana.UGUI.Extensions.UnityEngine;

namespace Murnana.UGUI.Font.OS
{
    /// <summary>
    /// Font object which lets you render a font installed on the operating system.
    /// </summary>
    public readonly struct OSFontAsset : IUnityEngineFontAsset,
                                         IDisposable
    {
        /// <summary>
        /// Get all font object which lets you render a font installed on the operating system.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<OSFontAsset> Select()
        {
            return UnityEngine.Font.GetPathsToOSFonts()
                              .Select(path => new UnityEngine.Font(path))
                              .Select(font => new OSFontAsset(font));
        }

        /// <summary>
        /// Get font object which lets you render a font installed on the operating system.
        /// </summary>
        /// <param name="whereByOSFontPath">where by os font path</param>
        /// <returns></returns>
        public static IEnumerable<OSFontAsset> Select(Func<string, bool> whereByOSFontPath)
        {
            Assert.IsNotNull(value: whereByOSFontPath, nameOfValue: nameof(whereByOSFontPath));
            return UnityEngine.Font.GetPathsToOSFonts()
                              .Where(whereByOSFontPath)
                              .Select(path => new UnityEngine.Font(path))
                              .Select(font => new OSFontAsset(font));
        }

        #region IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            Assert.IsNotNull(value: m_Font, nameOfValue: nameof(m_Font));
            m_Font.Destroy();
        }

        #endregion

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

        #region Private

        #region Private menber values

        [NonSerialized]
        private readonly UnityEngine.Font m_Font;

        #endregion

        #region Private menber methods

        private OSFontAsset(UnityEngine.Font font)
        {
            Assert.IsNotNull(value: font, nameOfValue: nameof(font));
            m_Font = font;
        }

        #endregion

        #endregion
    }
}
