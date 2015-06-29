using Ganss.XSS.Tests.Shared;
using NUnit.Framework;

namespace Ganss.XSS.Tests.ResourceInlining.LinkStylesheet
{
    /// <summary>
    /// Tests to verify that if stylesheet contains an imported stylesheet, it is inlined
    /// </summary>
    [TestFixture]
    [Category("Inlining")]
    public class ImportTests
    {
        [SetUp]
        public void ReadResources()
        {
            Input = Utils.ReadResourceRelative(this, "Import.input.html");
            Expected = Utils.ReadResourceRelative(this, "Import.expected.html");
        }

        public string Expected { get; set; }

        public string Input { get; set; }

        [Test]
        public void AnImportedStylesheetShouldAlsoBeInlined()
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