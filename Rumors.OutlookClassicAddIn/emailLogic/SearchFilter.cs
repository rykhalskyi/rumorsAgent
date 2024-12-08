using Rumors.Desktop.Common.Dto;
using System.Text;

namespace Rumors.OutlookClassicAddIn.emailLogic
{
    public static class SearchFilter
    {
        public static string FromDto(SearchDto search)
        { 
            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(search.Subject))
            {
                builder.Append($"urn:schemas:httpmail:subject LIKE '%{search.Subject}%'");
            }

            if (!string.IsNullOrEmpty(search.Body))
            {
                AddAnd(builder);
                builder.Append($"urn:schemas:httpmail:textdescription LIKE '%{search.Body}%'");
            }

            if (!string.IsNullOrEmpty(search.Sender)) 
            {
                AddAnd(builder);
                builder.Append($"urn:schemas:httpmail:fromemail LIKE '%{search.Sender}%'");
            }

            if (!string.IsNullOrEmpty(search.RecievedAfter))
            {
                AddAnd(builder);
                builder.Append($"urn:schemas:httpmail:datereceived >= '{search.RecievedAfter}'");
            }

            if (!string.IsNullOrEmpty(search.RecievedBefore))
            {
                AddAnd(builder);
                builder.Append($"urn:schemas:httpmail:datereceived <= '{search.RecievedBefore}'");
            }

            if (!string.IsNullOrEmpty(search.To))
            {
                AddAnd(builder);
                builder.Append($"urn:schemas:httpmail:to LIKE '%{search.To}%'");
            }

            if (!string.IsNullOrEmpty(search.Cc))
            {
                AddAnd(builder);
                builder.Append($"urn:schemas:httpmail:cc LIKE '%{search.Cc}%'");
            }

            if (search.Importance != null)
            {
                AddAnd(builder);
                builder.Append($"urn:schemas:httpmail:importance = {search.Importance}");
            }

            if (search.ReadStatus != null)
            {
                AddAnd(builder);
                builder.Append($"urn:schemas:httpmail:read = {search.ReadStatus}");
            }

            return $"@SQL=({builder.ToString()})";
        }

        private static void AddAnd(StringBuilder builder)
        {
            if (builder.Length > 0) 
                builder.Append(" AND ");
        }
    }


}
