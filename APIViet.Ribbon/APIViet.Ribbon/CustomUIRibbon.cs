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
using System.Linq;
#endregion

namespace APIViet.Ribbon
{
    /// <summary>
    /// Create a ribbon tab
    /// </summary>
    public class CustomUIRibbon
    {
        #region Declare variables
        private string assemblyName = Assembly.GetExecutingAssembly().Location;
        private string sourceImageName = "APIViet.Ribbon.ImgSources.";

        public string TabName { get;  } = "APIViet";
        public string PanelName1 { get; } = "First Panel";
        public string PanelName2 { get; } = "Second Panel";
        public string PanelName3 { get;  }  = "Third Panel";
        #endregion

        #region Creat tab and panel
        public CustomUIRibbon() { }
        public void CreateCustomTabAndPanel(UIControlledApplication uiApp)
        {
            // Creat a custom tab
            uiApp.CreateRibbonTab(this.TabName);

            //Add a panel in the custom tab
            RibbonPanel panel1 = uiApp.CreateRibbonPanel(this.TabName, this.PanelName1);
            RibbonPanel panel2 = uiApp.CreateRibbonPanel(this.TabName, this.PanelName2);
            RibbonPanel panel3 = uiApp.CreateRibbonPanel(this.TabName, this.PanelName3);
        }
        #endregion

        #region Add all controls to panels
        public void AddControlsInPanel(RibbonPanel panel)
        {
            //Add push button
            //Change name of method for matching with name of panel to add
        }
        public void AddControlsInPanel_1(RibbonPanel panel)
        {
            //try
            //{
                AddPushButtonInPanel_1(panel);
                AddSplitButtonInPanel_1(panel);
                AddPulldownButtonInPanel_1(panel);
                AddTogleButtonInPanel_1(panel);
                AddComboBoxInPanel_1(panel);
            //}
            //catch { } 
        }
        public void AddControlsInPanel_2(RibbonPanel panel)
        {
            //try
            //{
            AddPushButtonInPanel_2(panel);
            AddSplitButtonInPanel_2(panel);
            //}
            //catch { } 
        }
        public void AddControlsInPanel_3(RibbonPanel panel)
        {
            //try
            //{
            AddPushButtonInPanel_3(panel);
            AddSplitButtonInPanel_3(panel);
            //}
            //catch { } 
        }
        #endregion


        #region Detail of controls in the panel 1
        private void AddPushButtonInPanel_1(RibbonPanel panel)
        {
            PushButton bt11 = CustomPushButton.NewButton(panel, "Buton11", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton bt12 = CustomPushButton.NewButton(panel, "Buton12", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
        }
        private void AddSplitButtonInPanel_1(RibbonPanel panel)
        {
            SplitButtonData splitBtnData = new SplitButtonData("SplitButton11", "Split Button");
            SplitButton splitBtn11 = panel.AddItem(splitBtnData) as SplitButton;
            PushButton btn111 = CustomSplitButton.NewButton(panel, splitBtn11, "SplitButon11", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn112 = CustomSplitButton.NewButton(panel, splitBtn11, "SplitButon12", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn113 = CustomSplitButton.NewButton(panel, splitBtn11, "SplitButon13", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn114 = CustomSplitButton.NewButton(panel, splitBtn11, "SplitButon14", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn115 = CustomSplitButton.NewButton(panel, splitBtn11, "SplitButon15", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
        }
        private void AddPulldownButtonInPanel_1(RibbonPanel panel)
        {
            PulldownButtonData pulldownBtnData = new PulldownButtonData("PulldowButtonData11", "PulldownButton");
            PulldownButton pulldownBtn = panel.AddItem(pulldownBtnData) as PulldownButton;
            pulldownBtn.Image = Image.ImageSource(sourceImageName + "Revit_16x16.png");
            PushButton btn121 = CustomPulldownButton.NewButton(panel, pulldownBtn, "PulldownButon11", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn122 = CustomPulldownButton.NewButton(panel, pulldownBtn, "PulldownButon12", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn123 = CustomPulldownButton.NewButton(panel, pulldownBtn, "PulldownButon13", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn124 = CustomPulldownButton.NewButton(panel, pulldownBtn, "PulldownButon14", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn125 = CustomPulldownButton.NewButton(panel, pulldownBtn, "PulldownButon15", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
        }
        private void AddTogleButtonInPanel_1(RibbonPanel panel)
        {
            RadioButtonGroupData rdoBtnGroupData = new RadioButtonGroupData("RadioButton1");
            RadioButtonGroup rdoBtnGroup = panel.AddItem(rdoBtnGroupData) as RadioButtonGroup;
            ToggleButton btn121 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup, "Op1", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit_16x16.png", "To show a message Hello World!");
            ToggleButton btn122 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup, "Op2", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit_16x16.png", "To show a message Hello World!");
            ToggleButton btn123 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup, "Op3", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit_16x16.png", "To show a message Hello World!");
            ToggleButton btn124 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup, "Op4", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "RRevit_16x16.png", "To show a message Hello World!");
            ToggleButton btn125 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup, "Op5", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit_16x16.png", "To show a message Hello World!");
        }
        private void AddTextBoxInPanel_1(RibbonPanel panel)
        {
            TextBox txBox1 = CustomTextBox.NewTextBox(panel, "TextBox1", sourceImageName + "Revit_16x16.png", sourceImageName + "Revit_16x16.png");
            TextBox txBox2 = CustomTextBox.NewTextBox(panel, "TextBox2", sourceImageName + "Revit_16x16.png", sourceImageName + "Revit_16x16.png");
        }
        private void AddComboBoxInPanel_1(RibbonPanel panel)
        {
            ComboBox comboBox11 = CustomComboBox.NewComboBox(panel, "cbo11");
            ComboBoxMember cboMember11 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "Data11", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName11");
            ComboBoxMember cboMember12 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "Data12", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName11");
            ComboBoxMember cboMember13 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "Data13", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName11");
            ComboBoxMember cboMember14 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "Data14", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName12");
            ComboBoxMember cboMember15 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "Data15", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName12");


            ComboBox comboBox12 = CustomComboBox.NewComboBox(panel, "cbo12");
            ComboBoxMember cboMember21 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "Data21", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName21");
            ComboBoxMember cboMember22 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "Data22", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName21");
            ComboBoxMember cboMember23 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "Data23", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName21");
            ComboBoxMember cboMember24 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "Data24", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName21");
            ComboBoxMember cboMember25 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "Data25", sourceImageName + "Revit_16x16.png", "Cbo" + "\nGroupName21");
        }
        #endregion


        #region Detail of controls in the panel 2
        private void AddPushButtonInPanel_2(RibbonPanel panel)
        {
            PushButton bt21 = CustomPushButton.NewButton(panel, "Buton21", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton bt22 = CustomPushButton.NewButton(panel, "Buton22", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
        }
        private void AddSplitButtonInPanel_2(RibbonPanel panel)
        {
            //Split button
            SplitButtonData splitBtnData = new SplitButtonData("SplitButton12", "Split Button");
            SplitButton splitBtn21 = panel.AddItem(splitBtnData) as SplitButton;
            PushButton btn211 = CustomSplitButton.NewButton(panel, splitBtn21, "PushButton21", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn212 = CustomSplitButton.NewButton(panel, splitBtn21, "PushButton22", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn213 = CustomSplitButton.NewButton(panel, splitBtn21, "PushButton23", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn214 = CustomSplitButton.NewButton(panel, splitBtn21, "PushButton24", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn215 = CustomSplitButton.NewButton(panel, splitBtn21, "PushButton25", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
        }
        #endregion




        #region Detail of controls in the panel 3
        private void AddPushButtonInPanel_3(RibbonPanel panel)
        {
            PushButton bt31 = CustomPushButton.NewButton(panel, "Buton21", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton bt32 = CustomPushButton.NewButton(panel, "Buton22", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
        }
        private void AddSplitButtonInPanel_3(RibbonPanel panel)
        {
            SplitButtonData splitBtnData = new SplitButtonData("SplitButton13", "Split Button");
            SplitButton splitBtn = panel.AddItem(splitBtnData) as SplitButton;
            PushButton btn311 = CustomSplitButton.NewButton(panel, splitBtn, "SplitButon31", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn312 = CustomSplitButton.NewButton(panel, splitBtn, "SplitButon32", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn313 = CustomSplitButton.NewButton(panel, splitBtn, "SplitButon33", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn314 = CustomSplitButton.NewButton(panel, splitBtn, "SplitButon34", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
            PushButton btn315 = CustomSplitButton.NewButton(panel, splitBtn, "SplitButon35", assemblyName, "APIViet.Ribbon.HelloWorld", sourceImageName + "Revit.png", "To show a message Hello World!");
        }
        #endregion

        public RibbonPanel PanelByName(UIControlledApplication uiApp,string _tabName,string _panelName)
        {
            try
            {
                uiApp.CreateRibbonTab(_tabName);   
            }
            catch { }

            RibbonPanel panel = uiApp.GetRibbonPanels(
            _tabName).FirstOrDefault(n => n.Name.Equals(_panelName, StringComparison.InvariantCulture));
            if(panel == null)
            {
                panel = uiApp.CreateRibbonPanel(_tabName, _panelName);
                
            }
            return panel;
        }
    }

 }
