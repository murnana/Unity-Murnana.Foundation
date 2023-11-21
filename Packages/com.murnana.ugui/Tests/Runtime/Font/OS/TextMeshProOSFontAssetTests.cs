// Copyright 2023 murnana.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#nullable enable
using System;
using System.Collections;
using Murnana.UGUI.Font.OS;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TextCore.LowLevel;

namespace Murnana.UGUI.Tests.Font.OS
{
    [TestOf(typeof(TextMeshProOSFontAsset))]
    internal sealed class TextMeshProOSFontAssetTests
    {
        [UnityTearDown]
        public IEnumerator UnityTearDown()
        {
            yield return Resources.UnloadUnusedAssets();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        [Test]
        public void Select
        (
            [Values(90)]   int             samplingPointSize,
            [Values(9)]    int             atlasPadding,
            [Values]       GlyphRenderMode renderMode,
            [Values(1024)] int             atlasWidth,
            [Values(1024)] int             atlasHeight
        )
        {
            foreach(var osFontAsset in TextMeshProOSFontAsset.Select(
                        samplingPointSize: samplingPointSize,
                        atlasPadding: atlasPadding,
                        renderMode: renderMode,
                        atlasWidth: atlasWidth,
                        atlasHeight: atlasHeight
                    ))
            {
                var textMeshProFontAsset = osFontAsset.TextMeshProFontAsset;
                Assert.That(actual: textMeshProFontAsset, expression: Is.Not.Null);
                var sourceFontFile = textMeshProFontAsset.sourceFontFile;
                Assert.That(actual: sourceFontFile, expression: Is.Not.Null);

                var faceInfo = textMeshProFontAsset.faceInfo;

                TestContext.WriteLine(
                    format: "name: {0}, familyName: {1}, styleName: {2}",
                    arg1: sourceFontFile.name,
                    arg2: faceInfo.familyName,
                    arg3: faceInfo.styleName
                );
                osFontAsset.Dispose();
            }
        }
    }
}
