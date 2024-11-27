using Microsoft.Office.Tools;
using System;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public class TaskPane
    {
        public Type Type { get; set; }
        public CustomTaskPane Pane { get; set; }
    }
}
