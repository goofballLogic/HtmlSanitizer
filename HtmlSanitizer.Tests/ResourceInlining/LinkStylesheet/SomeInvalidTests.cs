using Ganss.XSS.Tests.Shared;
using NUnit.Framework;

namespace Ganss.XSS.Tests.ResourceInlining.LinkStylesheet
{
    /// <summary>
    /// Tests to verify that if some of the linked stylesheets cannot be found, inlining does not fail.
    /// </summary>
    [TestFixture]
    [Category("Inlining")]
    public class SomeInvalidTests
    {
        [SetUp]
        public void ReadResources()
        {
            Input = Utils.ReadResourceRelative(this, "SomeInvalid.input.html");
            Expected = Utils.ReadResourceRelative(this, "SomeInvalid.expected.html");
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