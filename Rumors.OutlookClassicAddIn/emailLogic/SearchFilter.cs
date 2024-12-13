using Rumors.Desktop.Common.Dto;
using System.Reflection;
using System.Text;

namespace Rumors.OutlookClassicAddIn.emailLogic
{
    public static class SearchFilter
    {
        public static string FromString(string query)
        {
            var sql = query.Replace("[subject]", "urn:schemas:httpmail:subject")
                        .Replace("[body]", "urn:schemas:httpmail:textdescription")
                        .Replace("[sender]", "urn:schemas:httpmail:fromemail")
                        .Replace("[received]", "urn:schemas:httpmail:datereceived")
                        .Replace("[status]", "urn:schemas:httpmail:read");

            return $"@SQL=({sql})";
        }

        private static void AddAnd(StringBuilder builder)
        {
            if (builder.Length > 0) 
                builder.Append(" AND ");
        }
    }


}
