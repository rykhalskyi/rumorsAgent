
using System.Threading.Tasks;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public interface IPaneUserControl
    {
        string Caption { get; }
        void OnPanelAdded();
        void OnPanelOpened();
    }
}
