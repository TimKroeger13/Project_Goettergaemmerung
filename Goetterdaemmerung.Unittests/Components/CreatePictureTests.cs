using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.ExtensionMethods;
using Xunit;

namespace Unittests.Components
{
    public class CreatePictureTests
    {
        private static CreatePicture CreateCreatePicture()
        {
            return new CreatePicture();
        }

        [Fact]
        public void BledingMultiply_StateUnderTest_ExpectedBehavior()
        {
            var createPicture = CreateCreatePicture();
            var bitmap1 = TestResources.TestImage;
            var bitmap2 = TestResources.TestImage;
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
