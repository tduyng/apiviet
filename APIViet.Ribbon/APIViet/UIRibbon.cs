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
using System.Windows.Media;
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

        public Result OnStartup(UIControlledApplication uiApp)
        {
            
            AddControls(uiApp);


            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uiApp)
        {
            return Result.Succeeded;
        }


        private void AddControls(UIControlledApplication uiApp)
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;
            string sourceImageName = "APIViet.ImgSources.";

            // Varibale const
            string tabName = "APIViet";
            string panelName1 = "First Panel";
            string panelName2 = "Second Panel";
            string panelName3 = "Third Panel";


            // Creat a custom tab
            uiApp.CreateRibbonTab(tabName);

            //Add a panel in the custom tab
            RibbonPanel panel1 = uiApp.CreateRibbonPanel(tabName, panelName1);
            RibbonPanel panel2 = uiApp.CreateRibbonPanel(tabName, panelName2);
            RibbonPanel panel3 = uiApp.CreateRibbonPanel(tabName, panelName3);
       

            //Add push button
            AddButton(panel1, "Buton11", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            AddButton(panel1, "Buton12", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            AddButton(panel2, "Buton21", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            AddButton(panel2, "Buton22", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            AddButton(panel3, "Buton31", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            AddButton(panel3, "Buton32", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
        }
        private void AddButton(RibbonPanel panel, string buttonName,string assemblyName, string className, string imageName, string btnTooltip)
        {
            PushButtonData btnData1 = ButtonData.GetButtonData(buttonName, assemblyName, className, imageName, btnTooltip);
            PushButton btn1 = panel.AddItem(btnData1) as PushButton;
        }

    }



 }
