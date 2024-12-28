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
        public void SearchFilterShourReplaceAllConstantsCorrectly()
        {
            var query = "[subject] LIKE '%google%' OR [body] LIKE '%google%' AND [sender] Like '%email%' AND [received] < 2022-02-01 AND [status] = true";

            var search = SearchFilter.FromString(query);

            Assert.That(search, Is.EqualTo("@SQL=(urn:schemas:httpmail:subject LIKE '%google%' OR urn:schemas:httpmail:textdescription LIKE '%google%' AND urn:schemas:httpmail:fromemail Like '%email%' AND urn:schemas:httpmail:datereceived < 2022-02-01 AND urn:schemas:httpmail:read = true)"));
        }
    }
}