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
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Murnana.UGUI.Samples.OSFont
{
    [DisallowMultipleComponent]
    internal sealed class OSFontListItem : MonoBehaviour
    {
        [SerializeField]
        private Button? m_Button;

        [SerializeField]
        private Text? m_Text;

        private void Start()
        {
            Assert.IsNotNull(value: m_Button, message: "m_Button != null");
            m_Button!.onClick.AddListener(
                OnButtonClick
            );
            m_Button.interactable = m_Asset.TextMeshProFontAsset != null;

            Assert.IsNotNull(value: m_Text, message: "m_Text != null");
            m_DynamicFontAsset = DynamicOSFontAsset.Get(m_Text!.fontSize);
            m_Text!.font       = m_DynamicFontAsset.Font;
        }

        private void OnDestroy()
        {
            m_DynamicFontAsset.Dispose();
        }

        internal void Set(TextMeshProOSFontAsset fontAsset, SelectOSFontEvent onSelect)
        {
            Assert.IsNotNull(value: onSelect, message: "onSelect != null");
            Debug.AssertFormat(
                condition: m_Text != null,
                context: this,
                format: "{0} != null",
                m_Text
            );
            Debug.AssertFormat(
                condition: m_Button != null,
                context: this,
                format: "{0} != null",
                m_Button
            );

            m_Asset = fontAsset;

            var faceInfo = m_Asset.TextMeshProFontAsset.faceInfo;
            m_Text!.text = $"familyName: {faceInfo.familyName}\n<size=24>styleName:{faceInfo.styleName}</size>";
            m_Button!.interactable = true;
            m_SelectOSFont = onSelect;
        }

        internal delegate void SelectOSFontEvent(in TextMeshProOSFontAsset fontAsset);

        #region Private

        #region Private menber values

        private TextMeshProOSFontAsset m_Asset;
        private SelectOSFontEvent? m_SelectOSFont;
        private DynamicOSFontAsset m_DynamicFontAsset;

        #endregion

        #region Private menber method

        private void OnButtonClick()
        {
            m_SelectOSFont?.Invoke(in m_Asset);
        }

        #endregion

        #endregion
    }
}
