using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;

namespace Rumors.OutlookClassicAddIn.etc
{
    internal enum EmailTaskPaneStatus
    {
        Unknown = 0,
        Found = 1,
        CheckedIn = 2,
        NotFound = 3
    }
    internal class EmailTaskPaneState
    {
        public EmailTaskPaneStatus Status { get; set; }
        public string Label { get; set; }
        public string Button { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }

    internal static class EmailTaskPanelStates
    {
        private static List<EmailTaskPaneState> _states = new List<EmailTaskPaneState>() {
            new EmailTaskPaneState
            {
                Status = EmailTaskPaneStatus.Unknown,
                Label = "Unknown",
                Button = "Find Project",
                Red = 227,
                Green = 227,
                Blue = 227
            },
            new EmailTaskPaneState
            {
                Status = EmailTaskPaneStatus.Found,
                Label = "Project Found",
                Button = "Check In",
                Red = 192,
                Green = 255,
                Blue = 192
            },
            new EmailTaskPaneState
            {
                Status = EmailTaskPaneStatus.CheckedIn,
                Label = "Checked In",
                Button = "Check In",
                Red = 34,
                Green = 199,
                Blue = 78
            },new EmailTaskPaneState
            {
                Status = EmailTaskPaneStatus.NotFound,
                Label = "Project Not Found",
                Button = "Check In",
                Red = 237,
                Green = 227,
                Blue = 57
            }
        };

        public static List<EmailTaskPaneState> States => _states;

        public static EmailTaskPaneState Get(EmailTaskPaneStatus status) =>
            _states.FirstOrDefault(x => x.Status == status);

    }
}
