using Ganss.XSS.Tests.Shared;
using NUnit.Framework;

namespace Ganss.XSS.Tests.ResourceInlining.LinkStylesheet
{
    /// <summary>
    /// Tests to verify that if a linked stylesheet is not found, it is still inlined.
    /// </summary>
    [TestFixture]
    [Category("Inlining")]
    public class InvalidTests
    {
        [SetUp]
        public void ReadResources()
        {
            Input = Utils.ReadResourceRelative(this, "Invalid.input.html");
            Expected = Utils.ReadResourceRelative(this, "Invalid.expected.html");
        }

        public string Expected { get; set; }

        public string Input { get; set; }

        [Test]
        public void MissingStylesheetsShouldNotPreventInlining()
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