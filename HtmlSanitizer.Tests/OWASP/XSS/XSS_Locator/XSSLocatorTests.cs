using Ganss.XSS.Tests.Shared;
using NUnit.Framework;

namespace Ganss.XSS.Tests.OWASP.XSS.XSS_Locator
{
    /// <summary>
    /// Tests <a href="https://www.owasp.org/index.php/XSS_Filter_Evasion_Cheat_Sheet#XSS_Locator">XSS Locator</a>
    /// </summary>
    [TestFixture]
    [Category("OWASP")]
    public class XSSLocatorTests
    {
        private string Input { get; set; }
        private string Expected { get; set; }

        [SetUp]
        public void ReadResources()
        {
            Input = Utils.ReadResourceRelative(this, "input.html");
            Expected = Utils.ReadResourceRelative(this, "expected.html");
        }

        [Test]
        public void XSSLocatorTest()
        {
            var sanitizer = new HtmlSanitizer();
            var actual = sanitizer.Sanitize(Input);
            Assert.That(actual, Is.EqualTo(Expected));
        }
    }
}