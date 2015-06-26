using NUnit.Framework;
using System.IO;
using System.Net;
using System.Collections.Concurrent;
using System.Reflection;

namespace Ganss.XSS.Tests.ResourceInlining.WithoutBaseTag
{
    [TestFixture]
    [Category("Unit")]
    [Category("Inline")]
    public class InlineCSS
    {
        private ConcurrentDictionary<string, string> expectedResults = new ConcurrentDictionary<string,string>();

        [SetUp]
        public void ReadResources()
        {
            expectedResults.TryAdd("Invalid", ReadResource("invalid.html"));
            expectedResults.TryAdd("InvalidOutput", ReadResource("invalidoutput.html"));
            expectedResults.TryAdd("Basic", ReadResource("basic.html"));
            expectedResults.TryAdd("BasicOutput", ReadResource("basicoutput.html"));
            expectedResults.TryAdd("Basic_Invalid", ReadResource("basic_invalid.html"));
            expectedResults.TryAdd("Basic_InvalidOutput", ReadResource("basic_invalidoutput.html"));
            expectedResults.TryAdd("Import", ReadResource("import.html"));
            expectedResults.TryAdd("ImportOutput", ReadResource("importoutput.html"));
            expectedResults.TryAdd("Fontface", ReadResource("fontface.html"));
            expectedResults.TryAdd("FontfaceOutput", ReadResource("fontfaceoutput.html"));
        }

        private static string ReadResource(string name)
        {
            var resourceName = string.Format("..\\..\\ResourceInlining\\WithoutBaseTag\\{0}", name);
            var stream = File.OpenRead(resourceName);
            return stream == null ? string.Empty : new StreamReader(stream).ReadToEnd();
        }


        [Test]
        public void InlineCSSTestWithoutBase()
        {
            var sanitizer = new HtmlSanitizer();
            var actual = sanitizer.InlineResources(expectedResults["Invalid"]);
            Assert.That(actual, Is.EqualTo(expectedResults["InvalidOutput"]));

            actual = sanitizer.InlineResources(expectedResults["Basic"]);
            Assert.That(actual, Is.EqualTo(expectedResults["BasicOutput"]));

            actual = sanitizer.InlineResources(expectedResults["Basic_Invalid"]);
            Assert.That(actual, Is.EqualTo(expectedResults["Basic_InvalidOutput"]));

            actual = sanitizer.InlineResources(expectedResults["Import"]);
            Assert.That(actual, Is.EqualTo(expectedResults["ImportOutput"]));

            actual = sanitizer.InlineResources(expectedResults["Fontface"]);
            Assert.That(actual, Is.EqualTo(expectedResults["FontfaceOutput"]));
        }
    }
}
