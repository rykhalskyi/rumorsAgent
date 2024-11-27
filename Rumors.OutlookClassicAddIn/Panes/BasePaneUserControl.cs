using System;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public abstract class BasePaneUserControl : UserControl, IPaneUserControl
    {
        public abstract string Caption { get; }

        public virtual void OnPanelAdded()
        {
        }

        public virtual void OnPanelOpened()
        {
        }

        protected void RunSafe(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(action));
            }
            else
            {
                action();
            }
        }
    }
}
