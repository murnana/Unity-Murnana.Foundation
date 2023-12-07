// Copyright 2023 murnana.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#nullable enable
using Murnana.UGUI.Font.OS;
using TMPro;
using UnityEngine;

namespace Murnana.UGUI.Samples.OSFont
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshProUGUI))]
    internal sealed class PreviewText : MonoBehaviour
    {
        internal void Set(in TextMeshProOSFontAsset fontAsset)
        {
            if(!TryGetTextMeshProUGUI(out var textMeshProUGUI))
            {
                return;
            }

            textMeshProUGUI.font = fontAsset.TextMeshProFontAsset;
        }

        #region Private

        #region Private menber values

        private TextMeshProUGUI? m_TextMeshProUGUI;

        #endregion

        #region Private menber methods

        /// <summary>
        /// Get <see cref="global::TMPro.TextMeshProUGUI" />
        /// </summary>
        /// <param name="textMeshProUGUI"></param>
        /// <returns></returns>
        private bool TryGetTextMeshProUGUI(out TextMeshProUGUI textMeshProUGUI)
        {
            if(m_TextMeshProUGUI != null)
            {
                textMeshProUGUI = m_TextMeshProUGUI;
                return textMeshProUGUI != null;
            }

            m_TextMeshProUGUI
                = textMeshProUGUI
                      = GetComponent<TextMeshProUGUI>();
            return textMeshProUGUI != null;
        }

        #endregion

        #endregion
    }
}
