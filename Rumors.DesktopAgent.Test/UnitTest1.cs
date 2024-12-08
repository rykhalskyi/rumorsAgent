using Rumors.Desktop.Common.Dto;
using Rumors.OutlookClassicAddIn.emailLogic;

namespace Rumors.DesktopAgent.Test
{
    [TestFixture]
    public class SearchFilterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFilter_Should_Create_Correct_Filter_With_Subject()
        {
            var input = new SearchDto
            {
                Subject = "Find string"
            };

            var result = SearchFilter.FromDto(input);

            Assert.That($"[Subject] LIKE '%{input.Subject}%'", Is.EqualTo(result));
        }

        [Test]
        public void TestFilter_Should_Create_Correct_Filter_With_Body()
        {
            var input = new SearchDto
            {
                Body = "Find string"
            };

            var result = SearchFilter.FromDto(input);

            Assert.That($"urn:schemas:httpmail:textdescription LIKE '%{input.Body}%'", Is.EqualTo(result));
        }

        [Test]
        public void TestFilter_Should_Create_Correct_Filter_With_Sender()
        {
            var input = new SearchDto
            {
                Sender = "sender@email.com"
            };

            var result = SearchFilter.FromDto(input);

            Assert.That($"[SenderEmailAddress] = '{input.Sender}'", Is.EqualTo(result));
        }
    }
}