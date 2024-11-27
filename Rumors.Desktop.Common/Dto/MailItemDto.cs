using System;

namespace Rumors.Desktop.Common.Dto
{
    public class MailItemDto
    {
        public string EmailId { get; set; }
        public string From { get; set; }
        public DateTime CreationTime { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public AttachmentDto[] Attachments { get; set; }
        public PersonDto Person { get; set; }
    }
}
