using Ganss.XSS.Tests.Shared;
using NUnit.Framework;

namespace Ganss.XSS.Tests.ResourceInlining.ImageTags
{
    /// <summary>
    /// Tests to verify that a basic linked stylesheet can be inlined
    /// </summary>
    [TestFixture]
    [Category("Inlining")]
    public class BasicTests
    {
        [SetUp]
        public void ReadResources()
        {
            Input = Utils.ReplaceTokens(Utils.ReadResourceRelative(this, "Basic.input.html"));
            Expected = Utils.ReplaceTokens(Utils.ReadResourceRelative(this, "Basic.expected.html"));
        }

        public string Expected { get; set; }

        public string Input { get; set; }

        [Test]
        public void ImageTagsShouldBeConvertedToDataURI()
        {
            using (TestServer.Start())
            {
                var sanitizer = new HtmlSanitizer();
                var actual = sanitizer.InlineResources(Input);
                Assert.That(actual, Is.EqualTo(Expected));
            }
        }
    }
}