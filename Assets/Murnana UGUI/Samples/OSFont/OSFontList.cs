// Copyright 2023 murnana.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#nullable enable
using Murnana.UGUI.Font.OS;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;

namespace Murnana.UGUI.Samples.OSFont
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ScrollRect))]
    internal sealed class OSFontList : MonoBehaviour
    {
        [SerializeField]
        private PreviewText?[]? m_Previews;

        [SerializeField]
        private OSFontListItem? m_ListItemPrefab;

        #region MonoBehaviour

        private void Start()
        {
            Debug.AssertFormat(
                condition: m_Previews != null,
                context: this,
                format: "{0} != null",
                nameof(m_Previews)
            );
            Debug.AssertFormat(
                condition: m_ListItemPrefab != null,
                context: this,
                format: "{0} != null",
                m_ListItemPrefab
            );

            if(!TryGetScrollRect(out var scrollRect))
            {
                return;
            }

            var content = scrollRect.content;
            if(content == null)
            {
                return;
            }

            var osFontAsset = TextMeshProOSFontAsset.Select(
                samplingPointSize: 90,
                atlasPadding: 9,
                renderMode: GlyphRenderMode.SDFAA,
                atlasWidth: 512,
                atlasHeight: 512
            );
            foreach(var fontAsset in osFontAsset)
            {
                var instance = Instantiate(original: m_ListItemPrefab!, parent: content);
                instance.Set(fontAsset: fontAsset, onSelect: OnSelect);
            }
        }

        #endregion

        #region Private

        #region Private menber values

        private ScrollRect? m_ScrollRect;

        #endregion

        #region Private menber method

        private bool TryGetScrollRect(out ScrollRect scrollRect)
        {
            if(m_ScrollRect != null)
            {
                scrollRect = m_ScrollRect;
                return scrollRect != null;
            }

            m_ScrollRect
                = scrollRect
                      = GetComponent<ScrollRect>();
            return scrollRect != null;
        }


        private void OnSelect(in TextMeshProOSFontAsset fontAsset)
        {
            if(m_Previews == null)
            {
                return;
            }

            foreach(var previewText in m_Previews)
            {
                if(previewText == null)
                {
                    continue;
                }

                previewText.Set(fontAsset);
            }
        }

        #endregion

        #endregion
    }
}
