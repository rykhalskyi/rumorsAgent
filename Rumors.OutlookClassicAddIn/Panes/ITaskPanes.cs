using Microsoft.Office.Tools;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public interface ITaskPanes
    {
        CustomTaskPane TogglePane<T>() where T : UserControl;
    }
}
