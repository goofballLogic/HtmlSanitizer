#OWASP XSS Filter evasion cheat sheet tests
Source: https://www.owasp.org/index.php/XSS_Filter_Evasion_Cheat_Sheet

##Layout
For each test:

1. Where possible, the folder name corresponds to the html fragment within the cheat sheet. e.g. "XSS_Locator" refers to https://www.owasp.org/index.php/XSS_Filter_Evasion_Cheat_Sheet#XSS_Locator
2. Each test has XML documentation containing a link to the anchor
2. A sample html input fragment is provided
3. Expected html output fragment is provided
4. Test compares actual with expected output

##Example

```csharp
    /// <summary>
    /// Tests <a href="https://www.owasp.org/index.php/XSS_Filter_Evasion_Cheat_Sheet#XSS_Locator">XSS Locator</a>
    /// </summary>
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
        
        . . .

        [Test]
        public void XSSLocatorTest()
        {
            var sanitizer = new HtmlSanitizer();
            var actual = sanitizer.Sanitize(Input);
            Assert.That(actual, Is.EqualTo(Expected));
        }
    }
```
