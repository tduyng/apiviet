#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;
#endregion

namespace APIViet.Ribbon
{
    /// <summary>
    /// Create a ribbon tab
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class UIRibbon : IExternalApplication
    {
        string controlName = "FirstProgram";
        string dllExtension = ".dll";
        
        string imageFolder;
        string addInPath;


        public Result OnStartup(UIControlledApplication application)
        {
            //string dirAddIn = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string pathAddIn = Path.Combine(dirAddIn, controlName + dllExtension);

            //if (!File.Exists(pathAddIn))
            //{
            //    TaskDialog.Show("UIRibbon", "External command assembly not found: " + pathAddIn);
            //    return Result.Failed;
            //}

            //imageFolder = FindFolderParents(dirAddIn, imageFolderName);
            //if(null == imageFolder || Directory.Exists(imageFolder))
            //{
            //    TaskDialog.Show("UIRibbon", $"No image folder named {imageFolderName} found in the parent directories of {dirAddIn}");
            //    return Result.Failed;
            //}

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }



       

       

        public void AddRibbon(UIControlledApplication uiApp)
        {

            // Varibale const
            string imageName = "Revit-logo.png";
            string tabName = "APIViet";
            string panelName1 = "First Panel";
            string panelName2 = "Second Panel";
            string panelName3 = "Third Panel";


            // Creat a custom tab
            Tab tab = new Tab();
            tab.CreateNewTab(uiApp, tabName);

            //Add a panel in the custom tab
            Panel panel = new Panel();
            panel.Add(uiApp, tabName, panelName1);
            panel.Add(uiApp, tabName, panelName2);
            panel.Add(uiApp, tabName, panelName3);


        }
    }



 }
