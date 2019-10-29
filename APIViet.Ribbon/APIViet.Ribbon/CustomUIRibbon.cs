//#region Namespaces
//using System;
//using System.Collections.Generic;
//using Autodesk.Revit.ApplicationServices;
//using Autodesk.Revit.Attributes;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;
//using System.Reflection;
//using System.IO;
//using System.Diagnostics;
//using System.Windows.Media.Imaging;
//using System.Windows.Media;
//using System.Linq;
//using APIViet.Ribbon.ImageUtils;
//#endregion

//namespace APIViet.Ribbon
//{
//    /// <summary>
//    /// Create a ribbon tab with the traditional solution
//    /// </summary>
//    public class CustomUIRibbon
//    {
//        #region Declare variables
//        private string assemblyName = Assembly.GetExecutingAssembly().Location;
//        private string sourceImageName = "APIViet.Ribbon.ImgSources.";

//        public string TabName { get; } = "APIViet";
//        public string PanelName1 { get; } = "First Panel";
//        public string PanelName2 { get; } = "Second Panel";
//        public string PanelName3 { get; } = "Third Panel";
//        #endregion

//        #region Creat tab and panel
//        public CustomUIRibbon() { }
//        public void CreateCustomTabAndPanel(UIControlledApplication uiApp)
//        {
//            // Creat a custom tab
//            uiApp.CreateRibbonTab(this.TabName);

//            //Add a panel in the custom tab
//            RibbonPanel panel1 = uiApp.CreateRibbonPanel(this.TabName, this.PanelName1);
//            RibbonPanel panel2 = uiApp.CreateRibbonPanel(this.TabName, this.PanelName2);
//            RibbonPanel panel3 = uiApp.CreateRibbonPanel(this.TabName, this.PanelName3);
//        }
//        #endregion

//        #region Add all controls to panels
//        public void AddControlsInPanel(RibbonPanel panel)
//        {
//            //Add push button
//            //Change name of method for matching with name of panel to add
//        }
//        public void AddControlsInPanel_1(RibbonPanel panel)
//        {
//            AddPushButtonInPanel_1(panel);
//            panel.AddSeparator();
//            AddSplitButtonInPanel_1(panel);
//            panel.AddSeparator();
//            AddPulldownButtonInPanel_1(panel);
//            panel.AddSeparator();
//            AddTogleButtonInPanel_1(panel);
//            AddComboBoxInPanel_1(panel);
//            AddTextBoxInPanel_1(panel);

//        }
//        public void AddControlsInPanel_2(RibbonPanel panel)
//        {
//            AddPushButtonInPanel_2(panel);
//            AddSplitButtonInPanel_2(panel);
//        }
//        public void AddControlsInPanel_3(RibbonPanel panel)
//        {
//            AddPushButtonInPanel_3(panel);
//            AddSplitButtonInPanel_3(panel);
//        }
//        #endregion


//        #region Detail of controls in the panel 1
//        private void AddPushButtonInPanel_1(RibbonPanel panel)
//        {
//            //PushButton bt11 = CustomPushButton.NewButton(panel, "btnA11","Button A1", assemblyName, "APIViet.Ribbon.HelloWorld", 
//            //                                             largeImageName: sourceImageName + "arrow_carribean-blue_32x32.png", 
//            //                                             btnTooltip:"To show a message Hello World!");
//            //PushButton bt12 = CustomPushButton.NewButton(panel, "btnA12","Button A2", assemblyName, "APIViet.Ribbon.HelloWorld", 
//            //                                             largeImageName: sourceImageName + "circle_royal-blue_16x16.png", 
//            //                                             btnTooltip: "To show a message Hello World!");
           

//        }
//        private void AddSplitButtonInPanel_1(RibbonPanel panel)
//        {
//            SplitButtonData splitBtnData = new SplitButtonData("SplitButton11", "Split\nButton");
//            SplitButton splitBtn11 = panel.AddItem(splitBtnData) as SplitButton;
//            PushButton btn111 = CustomSplitButton.NewButton(panel, splitBtn11, "btnOpt1","Option 1", assemblyName, "APIViet.Ribbon.HelloWorld", 
//                                                            largeImageName: sourceImageName + "circle_royal-blue_16x16.png", 
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btn112 = CustomSplitButton.NewButton(panel, splitBtn11, "btnOpt2","Option 2", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_royal-blue_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btn113 = CustomSplitButton.NewButton(panel, splitBtn11, "btnOpt3","Option 3", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_royal-blue_16x16.png", 
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btn114 = CustomSplitButton.NewButton(panel, splitBtn11,"btnOpt4", "Option 4", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_royal-blue_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btn115 = CustomSplitButton.NewButton(panel, splitBtn11, "btnOpt5", "Option 5", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_royal-blue_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//        }
//        private void AddPulldownButtonInPanel_1(RibbonPanel panel)
//        {
//            //PulldownButtonData pulldownBtnData = new PulldownButtonData("pulBtn1", "Pulldown\nButton");
//            //PulldownButton pulldownBtn = panel.AddItem(pulldownBtnData) as PulldownButton;
//            //pulldownBtn.Image = IconRibbon.GetBmpImageFromSource(sourceImageName + "circle_orange_16x16.png");
//            //PushButton btnA121 = CustomPulldownButton.NewButton(panel, pulldownBtn, "btnCase1","Case 1", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                                   largeImageName: sourceImageName + "circle_orange_16x16.png", 
//            //                                                   btnTooltip: "To show a message Hello World!");
//            //PushButton btnA122 = CustomPulldownButton.NewButton(panel, pulldownBtn, "btnCase2","Case 2", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                                   largeImageName: sourceImageName + "circle_orange_16x16.png",
//            //                                                   btnTooltip: "To show a message Hello World!");
//            //PushButton btnA123 = CustomPulldownButton.NewButton(panel, pulldownBtn, "btnCase3","Case 3", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                                   largeImageName: sourceImageName + "circle_orange_16x16.png", 
//            //                                                   btnTooltip: "To show a message Hello World!");
//            //PushButton btnA124 = CustomPulldownButton.NewButton(panel, pulldownBtn, "btnCase4","Case 4", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                                   largeImageName: sourceImageName + "circle_orange_16x16.png", 
//            //                                                   btnTooltip: "To show a message Hello World!");
//            //PushButton btnA125 = CustomPulldownButton.NewButton(panel, pulldownBtn, "btnCase5","Case 5", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                                   largeImageName: sourceImageName + "circle_orange_16x16.png", 
//            //                                                   btnTooltip: "To show a message Hello World!");
//        }
//        private void AddTogleButtonInPanel_1(RibbonPanel panel)
//        {
//            RadioButtonGroupData rdoBtnGroupData = new RadioButtonGroupData("RadioButton1");
//            RadioButtonGroup rdoBtnGroup = panel.AddItem(rdoBtnGroupData) as RadioButtonGroup;
//            ToggleButton btn121 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup,"togOpt1", "Op 1", assemblyName, "APIViet.Ribbon.HelloWorld", 
//                                                                     smallImageName: sourceImageName + "square_caribean-blue_16x16.png",
//                                                                     btnTooltip: "First Option");
//            ToggleButton btn122 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup, "togOpt2","Op 2", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                                     smallImageName: sourceImageName + "square_guacamole-green_16x16.png",
//                                                                     btnTooltip: "Second Option");
//            ToggleButton btn123 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup,"togOpt3", "Op 3", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                                     smallImageName: sourceImageName + "square_orage_16x16.png",
//                                                                     btnTooltip: "Third Option");
//            ToggleButton btn124 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup, "togOpt4","Op 4", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                                     smallImageName: sourceImageName + "square_royal-blue_16x16.png", 
//                                                                     btnTooltip: "Fourth Option");
//            ToggleButton btn125 = CustomToggleButton.NewToggleButton(panel, rdoBtnGroup,"togOpt5", "Op 5", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                                     smallImageName: sourceImageName + "square_soylent-red_16x16.png", 
//                                                                     btnTooltip: "Last Option");
//        }
//        private void AddTextBoxInPanel_1(RibbonPanel panel)
//        {
//            //TextBox txBox1 = CustomTextBox.NewTextBox(panel, "TextBox1", sourcelargeImageName + "square_royal blue_16x16.png", sourcelargeImageName + "square_royal blue_16x16.png");
//            //TextBox txBox2 = CustomTextBox.NewTextBox(panel, "TextBox2", sourcelargeImageName + "square_royal blue_16x16.png", sourcelargeImageName + "square_royal blue_16x16.png");
//            TextBox txBox1 = CustomTextBox.NewTextBox(panel, "TxtBox1", sourceImageName + "square_royal-blue_16x16.png");
//            TextBox txBox2 = CustomTextBox.NewTextBox(panel, "TxtBox2", sourceImageName + "square_caribean-blue_16x16.png");

//        }
//        private void AddComboBoxInPanel_1(RibbonPanel panel)
//        {
//            //IList<RibbonItem> stackedItems = panel.AddStackedItems()
//            ComboBox comboBox11 = CustomComboBox.NewComboBox(panel,"cboData1","cbo11");
//            ComboBoxMember cboMember111 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "cboData1","Data 1", "Group 1", sourceImageName + "emoticon-30_royal-blue_16x16.png");
//            ComboBoxMember cboMember112 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "cboData2","Data 2", "Group 1", sourceImageName + "emoticon-30_royal-blue_16x16.png");
//            ComboBoxMember cboMember113 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "cboData3","Data 3", "Group 1", sourceImageName + "emoticon-30_royal-blue_16x16.png");
//            ComboBoxMember cboMember114 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "cboData4","Data 4", "Group 2",sourceImageName + "emoticon-30_royal-blue_16x16.png");
//            ComboBoxMember cboMember115 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox11, "cboData5","Data 5", "Group 2",sourceImageName + "emoticon-30_royal-blue_16x16.png");


//            ComboBox comboBox12 = CustomComboBox.NewComboBox(panel, "cobData2","cbo12");
//            ComboBoxMember cboMember121 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "cboItem1","Item 1", "Group 3", sourceImageName + "emoticon-30_royal-blue_16x16.png");
//            ComboBoxMember cboMember122 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "cboItem2","Item 2", "Group 3", sourceImageName + "emoticon-30_royal-blue_16x16.png");
//            ComboBoxMember cboMember123 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "cboItem3","Item 3", "Group 3", sourceImageName + "emoticon-30_royal-blue_16x16.png");
//            ComboBoxMember cboMember124 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "cboItem4","Item 4", "Group 3", sourceImageName + "emoticon-30_royal-blue_16x16.png");
//            ComboBoxMember cboMember125 = CustomComboBoxMember.NewComboBoxMember(panel, comboBox12, "cboItem5","Item 5", "Group 3", sourceImageName + "emoticon-30_royal-blue_16x16.png");
//        }
//        #endregion


//        #region Detail of controls in the panel 2
//        private void AddPushButtonInPanel_2(RibbonPanel panel)
//        {
//            //PushButton btB11 = CustomPushButton.NewButton(panel, "btnB11", "Button B1", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                            largeImageName: sourceImageName + "arrow_carribean-blue_32x32.png",
//            //                                            btnTooltip: "To show a message Hello World!");
//            //PushButton btB12 = CustomPushButton.NewButton(panel, "btnB12", "Button B2", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                             largeImageName: sourceImageName + "arrow_carribean-blue_32x32.png",
//            //                                             btnTooltip: "To show a message Hello World!");
//        }
    
//        private void AddSplitButtonInPanel_2(RibbonPanel panel)
//        {
//            SplitButtonData splitBtnDataB1 = new SplitButtonData("SplBtnDataC1", "Split\nButton");
//            SplitButton splitBtnB11 = panel.AddItem(splitBtnDataB1) as SplitButton;
//            PushButton btnB11 = CustomSplitButton.NewButton(panel, splitBtnB11, "btnCOpt1", "Option 1", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_guacamole-green_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btnB12 = CustomSplitButton.NewButton(panel, splitBtnB11, "btnCOpt2", "Option 2", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_guacamole-green_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btnB13 = CustomSplitButton.NewButton(panel, splitBtnB11, "btnCOpt3", "Option 3", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_guacamole-green_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btnB14 = CustomSplitButton.NewButton(panel, splitBtnB11, "btnCOpt4", "Option 4", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_guacamole-green_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btnB15 = CustomSplitButton.NewButton(panel, splitBtnB11, "btnCOpt5", "Option 5", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_guacamole-green_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//        }
//        #endregion




//        #region Detail of controls in the panel 3
//        private void AddPushButtonInPanel_3(RibbonPanel panel)
//        {
//            //PushButton btC11 = CustomPushButton.NewButton(panel, "btnC11", "Button C1", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                             largeImageName: sourceImageName + "arrow_carribean-blue_32x32.png",
//            //                                             btnTooltip: "To show a message Hello World!");
//            //PushButton btC12 = CustomPushButton.NewButton(panel, "btnC12", "Button C2", assemblyName, "APIViet.Ribbon.HelloWorld",
//            //                                             largeImageName: sourceImageName + "arrow_carribean-blue_32x32.png",
//            //                                             btnTooltip: "To show a message Hello World!");
//        }
//        private void AddSplitButtonInPanel_3(RibbonPanel panel)
//        {
//            SplitButtonData splitBtnDataC1 = new SplitButtonData("SplBtnDataC1", "Split\nButton");
//            SplitButton splitBtnC11 = panel.AddItem(splitBtnDataC1) as SplitButton;
//            PushButton btnC11 = CustomSplitButton.NewButton(panel, splitBtnC11, "btnCOpt1", "Option 1", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_babie pink_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btnC12 = CustomSplitButton.NewButton(panel, splitBtnC11, "btnCOpt2", "Option 2", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_babie pink_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btnC13 = CustomSplitButton.NewButton(panel, splitBtnC11, "btnCOpt3", "Option 3", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_babie pink_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btnC14 = CustomSplitButton.NewButton(panel, splitBtnC11, "btnCOpt4", "Option 4", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_babie pink_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//            PushButton btnC15 = CustomSplitButton.NewButton(panel, splitBtnC11, "btnCOpt5", "Option 5", assemblyName, "APIViet.Ribbon.HelloWorld",
//                                                            largeImageName: sourceImageName + "circle_babie pink_16x16.png",
//                                                            btnTooltip: "To show a message Hello World!");
//        }
//            #endregion

//            public RibbonPanel PanelByName(UIControlledApplication uiApp, string _tabName, string _panelName)
//        {
//            try
//            {
//                uiApp.CreateRibbonTab(_tabName);
//            }
//            catch { }

//            RibbonPanel panel = uiApp.GetRibbonPanels(
//            _tabName).FirstOrDefault(n => n.Name.Equals(_panelName, StringComparison.InvariantCulture));
//            if (panel == null)
//            {
//                panel = uiApp.CreateRibbonPanel(_tabName, _panelName);

//            }
//            return panel;
//        }
//        private static void AddSeparator()
//        {

//        }
//    }

//}

