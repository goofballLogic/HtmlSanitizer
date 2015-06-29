using System;
using Ganss.XSS.Tests.Shared;
using NUnit.Framework;

namespace Ganss.XSS.Tests.ResourceInlining.LinkStylesheet
{
    /// <summary>
    /// Tests to verify that stylesheet font-faces are ??? removed ??? uri-encoded ???
    /// </summary>
    [TestFixture]
    [Category("Inlining")]
    public class FontFaceTests
    {
        [SetUp]
        public void ReadResources()
        {
            Input = Utils.ReadResourceRelative(this, "FontFace.input.html");
            Expected = Utils.ReadResourceRelative(this, "FontFace.expected.html");
        }

        public string Expected { get; set; }

        public string Input { get; set; }

        [Test]
        public void FontFacesShouldBe___TODO___()
        {
            throw new NotImplementedException("To do: decide handling of fontfaces (just get rid of them?)");
            using (TestServer.Start())
            {
                var sanitizer = new HtmlSanitizer();
                var actual = sanitizer.InlineResources(Input);
                Assert.That(actual, Is.EqualTo(Expected));
            }
        }
    }
}