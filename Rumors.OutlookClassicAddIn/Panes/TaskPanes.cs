using Microsoft.Office.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public class TaskPanes : ITaskPanes
    {
        private readonly List<TaskPane> _panes = new List<TaskPane> ();
        public CustomTaskPane TogglePane<T>() where T : UserControl
        {
           var paneItem = _panes.FirstOrDefault(i=> i.Type == typeof(T));
            if (paneItem != null) 
            {
                paneItem.Pane.Visible = !paneItem.Pane.Visible;

                FireOnOpen(paneItem.Pane);
                return paneItem.Pane;
            }

            var newPane = CreateAndAddControl<T>();
            _panes.Add(new TaskPane
            {
                Type = typeof(T),
                Pane = newPane
            });

            newPane.Visible = true;

            FireOnOpen(newPane);
            return newPane;
        }

        private CustomTaskPane CreateAndAddControl<T>() where T : UserControl
        {
           var userControl = (T)Activator.CreateInstance (typeof(T));

           var caption = (userControl is IPaneUserControl paneUc) ? paneUc.Caption : null;

           var newPane = Globals.ThisAddIn.CustomTaskPanes.Add(userControl, caption);
           newPane.Width = 330;
                
           if (userControl is IPaneUserControl paneUc1)
           {
               paneUc1.OnPanelAdded();
           }

           return newPane;
        }

        private void FireOnOpen(CustomTaskPane pane)
        {
            if (pane.Control is IPaneUserControl paneUc)
            {
                paneUc.OnPanelOpened();
            }
        }
    }
}
