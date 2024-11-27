using Rumors.OutlookClassicAddIn.Panes;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Office = Microsoft.Office.Core;

namespace Rumors.OutlookClassicAddIn
{
    [ComVisible(true)]
    public class RumorsRibbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public RumorsRibbon()
        {
        }

        public void OnButtonClick(Office.IRibbonControl control)
        {
            if (control.Id.Equals("btnProjects"))
            {
                ThisAddIn.TaskPanes.TogglePane<ProjectsPane>();
            }

            if (control.Id.Equals("btnShowInfo"))
            {
                ThisAddIn.TaskPanes.TogglePane<InfoTaskPane>();
            }

            if (control.Id.Equals("btnShowLog"))
            {
                ThisAddIn.TaskPanes.TogglePane<LogListTaskPane>();
            }

            if (control.Id.Equals("btnGetStatus"))
            {
                ThisAddIn.TaskPanes.TogglePane<GetStatusPane>();
            }

            switch (control.Id)
            {
                case "btnAuto":
                    ThisAddIn.TaskPanes.TogglePane<AutoRecognizePane>();
                break;
            }
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("Rumors.OutlookClassicAddIn.RumorsRibbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
