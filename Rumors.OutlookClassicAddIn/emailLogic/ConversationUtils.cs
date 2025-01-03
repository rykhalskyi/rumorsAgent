using Microsoft.Office.Interop.Outlook;
using Rumors.Desktop.Common.Dto;
using System.Collections.Generic;

namespace Rumors.OutlookClassicAddIn.emailLogic
{
    internal class ConversationUtils
    {
        public static ConversationDto GetConversation(MailItem mailItem, bool useImages = false)
        {
            var result = new List<MailItemDto>();
            var conversation = mailItem.GetConversation();
            var items = conversation.GetRootItems();
            foreach (var item in items)
            {
                if (item is MailItem rootMailItem)
                {
                    var newItem = rootMailItem.ToDto();
                    if (useImages)
                        newItem.Attachments = EmailUtils.ExtractImages(rootMailItem);

                    result.Add(newItem);
                    GetChildEntryIds(conversation, rootMailItem, result, useImages);
                }
            }

            return new ConversationDto
            {
                ConversationId = conversation.ConversationID,
                Emails = result.ToArray(),
            };
        }

        private static void GetChildEntryIds(Conversation conversation, MailItem parentMailItem, List<MailItemDto> emailEntryIds, bool useImages = false)
        {
            var children = conversation.GetChildren(parentMailItem);

            foreach (object childItemObj in children)
            {
                if (childItemObj is MailItem childMailItem)
                {
                    var newItem = childMailItem.ToDto();
                    if (useImages)
                        newItem.Attachments = EmailUtils.ExtractImages(childMailItem);

                    emailEntryIds.Add(newItem);

                    GetChildEntryIds(conversation, childMailItem, emailEntryIds, useImages);
                }
            }
        }
    }
}
