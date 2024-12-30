using Microsoft.Office.Interop.Outlook;
using Rumors.Desktop.Common.Dto;

namespace Rumors.OutlookClassicAddIn.emailLogic
{
    internal static class ToDtoConverter
    {
        public static MailItemDto ToDto(this MailItem mailItem)
        {
            var newItem = new MailItemDto
            {
                EmailId = mailItem.EntryID,
                CreationTime = mailItem.CreationTime,
                From = mailItem.SenderEmailAddress,
                Subject = mailItem.Subject,
                Body = mailItem.Body,
                Person = new PersonDto
                {
                    Email = mailItem.SenderEmailAddress,
                    Name = mailItem.SenderName,
                }

            };

            return newItem;
        }
    }
}
