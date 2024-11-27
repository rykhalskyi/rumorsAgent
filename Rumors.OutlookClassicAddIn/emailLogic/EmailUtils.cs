using Microsoft.Office.Interop.Outlook;
using System.Text.RegularExpressions;
using System.IO;
using Rumors.Desktop.Common.Dto;
using System.Collections.Generic;

namespace Rumors.OutlookClassicAddIn.emailLogic
{
    internal static class EmailUtils
    {
        public static string CleanEmailText(string emailText)
        {
            // 1. Remove everything after common reply/forward headers (including foreign-language ones)
            string replyHeaderPattern = @"(?i)(пише:|From:|Sent:|To:|Subject:|Від:)[\s\S]*";
            emailText = Regex.Replace(emailText, replyHeaderPattern, "", RegexOptions.Multiline);

            // 2. Remove email addresses (both in angle brackets and standalone)
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";
            emailText = Regex.Replace(emailText, emailPattern, "");

            // 3. Remove any "mailto:" or content inside angle brackets "<>"
            string mailtoPattern = @"<.*?>";
            emailText = Regex.Replace(emailText, mailtoPattern, "");

            // 4. Remove signatures like "Best regards", "Regards", etc.
            string signaturePattern = @"(?i)(Best regards|Regards)[\s\S]*";
            emailText = Regex.Replace(emailText, signaturePattern, "", RegexOptions.Multiline);

            // 5. Remove excessive new lines or extra spaces
            string excessNewLinePattern = @"(\r\n|\n){2,}";
            emailText = Regex.Replace(emailText, excessNewLinePattern, "\r\n");

            return emailText.Trim(); // Trim any remaining leading/trailing spaces or newlines // Trim any remaining leading/trailing spaces or newlines
        }

        public static AttachmentDto[] ExtractImages(MailItem mailItem)
        {
            var result = new List<AttachmentDto>();
            foreach (Attachment attachment in mailItem.Attachments)
            {
                //if (attachment.PropertyAccessor != null)
                //{
                //    try
                //    {
                //        // Check if it's an inline image by checking if it has a ContentID
                //        string contentId = attachment.PropertyAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F") as string;

                //        if (!string.IsNullOrEmpty(contentId))
                //        {
                //            result.Add(new AttachmentDto
                //            {
                //                Name = "Inline image",
                //                File = ReadAttachmentContent(attachment)
                //            });
                //        }
                //    }
                //    catch (COMException)
                //    {
                //        // Handle any issues accessing PropertyAccessor
                //    }
                //}

                // Check if the attachment is an image file (by file extension)
                if (attachment.FileName.EndsWith(".jpg") || attachment.FileName.EndsWith(".jpeg") ||
                    attachment.FileName.EndsWith(".png") || attachment.FileName.EndsWith(".gif"))
                {
                    result.Add(new AttachmentDto
                    {
                        Name = attachment.FileName,
                        File = ReadAttachmentContent(attachment)
                    });
                }
            }

            return result.ToArray();
        }

        private static byte[] ReadAttachmentContent(Attachment attachment)
        {
            // Save the attachment to a temporary file, then read it as byte[]
            string tempFilePath = Path.GetTempFileName();
            attachment.SaveAsFile(tempFilePath);

            byte[] fileBytes = File.ReadAllBytes(tempFilePath);

            // Clean up the temporary file
            File.Delete(tempFilePath);

            return fileBytes;
        }
    }
}
