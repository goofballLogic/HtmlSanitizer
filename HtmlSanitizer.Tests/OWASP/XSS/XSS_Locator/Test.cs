using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Ganss.XSS.Tests.OWASP.XSS.XSS_Locator
{
    [TestFixture]
    [Category("Unit")]
    public class HtmlSanitizerTests
    {
        private string Input { get; set; }
        private string Expected { get; set; }

        [SetUp]
        public void ReadResources()
        {
            Input = ReadResource("input.html");
            Expected = ReadResource("expected.html");
        }

        private static string ReadResource(string name)
        {
            var resourceName = typeof (HtmlSanitizerTests).Namespace + string.Format(".{0}", name);
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            return stream == null ? string.Empty : new StreamReader(stream).ReadToEnd();
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void XSSLocatorTest()
        {
            var sanitizer = new HtmlSanitizer();
            var actual = sanitizer.Sanitize(Input);
            Assert.That(actual, Is.EqualTo(Expected));
        }
    }
}