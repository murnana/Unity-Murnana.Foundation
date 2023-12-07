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

namespace Murnana.UGUI.Tests.Font.OS
{
    [TestOf(typeof(DynamicOSFontAsset))]
    internal sealed class DynamicOSFontAssetTests
    {
        [UnityTearDown]
        public IEnumerator UnityTearDown()
        {
            yield return Resources.UnloadUnusedAssets();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        [Test]
        public void Get([Values(0, 1, 32, 256)] int size)
        {
            using var asset = DynamicOSFontAsset.Get(in size);

            Assert.That(actual: asset.Size, expression: Is.EqualTo(size));

            var font = asset.Font;
            Assert.That(actual: font, expression: Is.Not.Null);
            Assert.That(actual: font.fontSize, expression: Is.EqualTo(size));
        }
    }
}
