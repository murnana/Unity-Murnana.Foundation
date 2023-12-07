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
using Murnana.UGUI.Extensions.TMPro;
using TMPro;
using UnityEngine.TextCore.LowLevel;

namespace Murnana.UGUI.Font.OS
{
    /// <summary>
    /// <see cref="global::TMPro.TMP_FontAsset" /> object which lets you render a font installed on the operating system.
    /// </summary>
    public readonly struct TextMeshProOSFontAsset : ITextMeshProFontAsset,
                                                    IDisposable
    {
        /// <summary>
        /// Get all font object which lets you render a font installed on the operating system.
        /// </summary>
        /// <param name="samplingPointSize">The sampling point size.</param>
        /// <param name="atlasPadding">The padding / spread between individual glyphs in the font asset.</param>
        /// <param name="renderMode"></param>
        /// <param name="atlasWidth">The atlas texture width.</param>
        /// <param name="atlasHeight">The atlas texture height.</param>
        /// <returns></returns>
        public static IEnumerable<TextMeshProOSFontAsset> Select
        (
            int             samplingPointSize,
            int             atlasPadding,
            GlyphRenderMode renderMode,
            int             atlasWidth,
            int             atlasHeight
        )
        {
            Assert.IsDefined(value: renderMode, nameOfValue: nameof(renderMode));

            return OSFontAsset.Select()
                              .Select(
                                   osFontAsset => new TextMeshProOSFontAsset(
                                       osFontAsset: in osFontAsset,
                                       samplingPointSize: samplingPointSize,
                                       atlasPadding: atlasPadding,
                                       renderMode: in renderMode,
                                       atlasWidth: in atlasWidth,
                                       atlasHeight: in atlasHeight
                                   )
                               );
        }

        /// <summary>
        /// Get font object which lets you render a font installed on the operating system.
        /// </summary>
        /// <param name="whereByOSFontPath">where by os font path</param>
        /// <param name="samplingPointSize">The sampling point size.</param>
        /// <param name="atlasPadding">The padding / spread between individual glyphs in the font asset.</param>
        /// <param name="renderMode"></param>
        /// <param name="atlasWidth">The atlas texture width.</param>
        /// <param name="atlasHeight">The atlas texture height.</param>
        /// <returns></returns>
        public static IEnumerable<TextMeshProOSFontAsset> Select
        (
            Func<string, bool> whereByOSFontPath,
            int                samplingPointSize,
            int                atlasPadding,
            GlyphRenderMode    renderMode,
            int                atlasWidth,
            int                atlasHeight
        )
        {
            Assert.IsNotNull(value: whereByOSFontPath, nameOfValue: nameof(whereByOSFontPath));
            return OSFontAsset.Select(whereByOSFontPath)
                              .Select(
                                   osFontAsset => new TextMeshProOSFontAsset(
                                       osFontAsset: in osFontAsset,
                                       samplingPointSize: samplingPointSize,
                                       atlasPadding: atlasPadding,
                                       renderMode: in renderMode,
                                       atlasWidth: in atlasWidth,
                                       atlasHeight: in atlasHeight
                                   )
                               );
        }

        #region Implementation of ITextMeshProFontAsset

        /// <inheritdoc />
        public TMP_FontAsset TextMeshProFontAsset
        {
            get
            {
                Assert.IsNotNull(value: m_TextMeshProFontAsset, nameOfValue: nameof(m_TextMeshProFontAsset));
                return m_TextMeshProFontAsset;
            }
        }

        #endregion


        #region IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            Assert.IsNotNull(value: m_TextMeshProFontAsset, nameOfValue: nameof(m_TextMeshProFontAsset));
            m_TextMeshProFontAsset.DestroyDynamic();
            m_OSFontAsset.Dispose();
        }

        #endregion


        #region Private

        #region Private menber values

        [NonSerialized]
        private readonly TMP_FontAsset m_TextMeshProFontAsset;

        private readonly OSFontAsset m_OSFontAsset;

        #endregion

        #region Private menber methods

        /// <param name="osFontAsset"></param>
        /// <param name="samplingPointSize">The sampling point size.</param>
        /// <param name="atlasPadding">The padding / spread between individual glyphs in the font asset.</param>
        /// <param name="renderMode"></param>
        /// <param name="atlasWidth">The atlas texture width.</param>
        /// <param name="atlasHeight">The atlas texture height.</param>
        private TextMeshProOSFontAsset
        (
            in OSFontAsset     osFontAsset,
            in int             samplingPointSize,
            in int             atlasPadding,
            in GlyphRenderMode renderMode,
            in int             atlasWidth,
            in int             atlasHeight
        )
        {
            m_OSFontAsset = osFontAsset;
            m_TextMeshProFontAsset = TMP_FontAsset.CreateFontAsset(
                font: osFontAsset.Font,
                samplingPointSize: samplingPointSize,
                atlasPadding: atlasPadding,
                renderMode: renderMode,
                atlasWidth: atlasWidth,
                atlasHeight: atlasHeight,
                atlasPopulationMode: AtlasPopulationMode.Dynamic,
                enableMultiAtlasSupport: true
            );
        }

        #endregion

        #endregion
    }
}
