using FluentAssertions;
using NSubstitute;
using Project_Goettergaemmerung.Components;
using System;
using System.Diagnostics;
using System.Drawing;
using Xunit;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Linq;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Unittests.Components
{
    public class CreatePictureTests
    {
        private CreatePicture CreateCreatePicture()
        {
            return new CreatePicture();
        }

        [Fact]
        public void BledingMultiply_StateUnderTest_ExpectedBehavior()
        {
            var createPicture = CreateCreatePicture();
            Bitmap bitmap1 = TestResources.TestImage;
            Bitmap bitmap2 = TestResources.TestImage;
            var sw = new Stopwatch();

            sw.Start();
            using var result = createPicture.BlendingMultiply(bitmap1, bitmap2);
            sw.Stop();

            var resultBytes = result.GetArgbBytes();
            var testResultBytes = TestResources.TestResult.GetArgbBytes();
            sw.ElapsedMilliseconds.Should().BeLessThan(500);
            GetHash(resultBytes).Should().Be(GetHash(testResultBytes));
        }

        private static string GetHash(byte[] data)
        {
            using var sha = System.Security.Cryptography.SHA1.Create();
            return string.Concat(sha.ComputeHash(data).Select(d => d.ToString("X2")));
        }
    }
}