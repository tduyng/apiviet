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


        static BitmapImage GetIcon( string imageFolder,string imageName)
        {
            try
            {
                return new BitmapImage(new Uri(Path.Combine(imageFolder, imageName)));
            }
            catch
            {
                return null;
            }
        }
       

       

        private void AddControls(UIControlledApplication uiApp)
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;;
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //string dir = Path.GetDirectoryName(assemblyName);
            string imageFolderName = "ImgSource";
            string imageFolder = Path.Combine(projectPath, imageFolderName);
            BitmapImage img = GetIcon(imageFolder, "Fermer 2.PNG");

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
            AddButton(panel1, "Buton11", assemblyName, "APIViet.Ribbon.HelloWorld", img, "To show a message Hello World!");
            AddButton(panel1, "Buton12", assemblyName, "APIViet.Ribbon.HelloWorld", img, "To show a message Hello World!");
            AddButton(panel2, "Buton21", assemblyName, "APIViet.Ribbon.HelloWorld", img, "To show a message Hello World!");
            AddButton(panel2, "Buton22", assemblyName, "APIViet.Ribbon.HelloWorld", img, "To show a message Hello World!");
            AddButton(panel3, "Buton31", assemblyName, "APIViet.Ribbon.HelloWorld", img, "To show a message Hello World!");
            AddButton(panel3, "Buton32", assemblyName, "APIViet.Ribbon.HelloWorld", img, "To show a message Hello World!");
        }
        private void AddButton(RibbonPanel panel, string buttonName,string assemblyName, string className, BitmapImage image, string btnTooltip)
        {
            PushButtonData btnData1 = ButtonData.GetButtonData(buttonName, assemblyName, className, image, btnTooltip);
            PushButton btn1 = panel.AddItem(btnData1) as PushButton;
        }

    }



 }
