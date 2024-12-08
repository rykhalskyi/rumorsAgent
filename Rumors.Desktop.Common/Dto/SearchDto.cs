namespace Rumors.Desktop.Common.Dto
{
    public class SearchDto
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        public string RecievedAfter { get; set; }
        public string RecievedBefore { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public int? Importance { get; set; } = null;
        public bool? ReadStatus { get; set; } = null;
    }
}