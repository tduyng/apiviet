#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using ApiViet.Properties;
using ApiViet.Ribbon;
using ApiViet.Learning;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;

#endregion

namespace ApiViet
{
    /// <summary>
    /// Create a ribbon tab
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class AppStartProject : IExternalApplication
    {

        public Result OnStartup(UIControlledApplication uiApp)
        {
            CustomRibbon ribbon = new CustomRibbon(uiApp);
            var myTab = ribbon.Tab("TD");
            var panelLearning = myTab.Panel("Learning");
            var btn1 = panelLearning
                .CreateButton("btnInfoElement",
                    "Info\nElement",
                    typeof(CmdPickMultiObjects),
                    btn => btn
                        .SetLargeImage(Resources.arrow_royal_blue_32x32)
                        .SetSmallImage(Resources.arrow_royal_blue_16x16)
                        .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"))
                        .RvtPushButton;//Get the defaut autodesk pushbutton to use in other class
            panelLearning
                .CreateStackedItems(si =>
                    si
                        .CreateButton<CmdCollectorWithLINQ>("btnCreateFamily", "CreateCars",
                            btn => btn.SetSmallImage(Resources.circle_caribbean_blue_16x16))
                        .CreateButton<CmdCreateLineBaseElement>("btnCreateWall", "CreateWall",
                            btn => btn.SetSmallImage(Resources.circle_orange_16x16))
                        .CreateButton<CmdGetParameter>("btnGetParameter", "Get Parameter",
                            btn => btn.SetSmallImage(Resources.circle_orange_16x16)))
                .CreatePullDownButton("pdbBtn1","Options",
                   pdb =>
                   {
                       pdb.SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                           .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                           .SetToolTips("This is a test for creating a pulldown button");
                       pdb.CreateButton<CmdSelectGeometry>("cmdSelectGeometry", "Select Geometry",
                               btn => btn
                                   .SetLargeImage(Resources.circle_caribbean_blue_32x32)
                                   .SetSmallImage(Resources.circle_caribbean_blue_16x16))
                          .CreateButton<CmdHelloWorld>("pdbY", "Not Assign",
                               btn => btn
                                   .SetLargeImage(Resources.circle_orange_32x32)
                                   .SetSmallImage(Resources.circle_orange_16x16)
                                   .SetToolTips("Turn On Event"))
                           .CreateButton<CmdHelloWorld>("pdbButtonZ", "Not Assign",
                               btn => btn
                                   .SetLargeImage(Resources.circle_orange_32x32)
                                   .SetSmallImage(Resources.circle_orange_16x16))
                           .SetContextualHelp(ContextualHelpType.Url, "https://github.com/TienDuyNGUYEN")
                           .SetToolTips("This is a awesome button!");
                   });

            var pdbEvent = panelLearning
                .CreatePullDownButton("pdbBtn2","Options",
                    pdb =>
                    {
                        pdb.SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                            .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                            .SetToolTips("This is a test for creating a pulldown button");
                        pdb.CreateButton<UIEvent>("btnEvent", "Event",
                                btn => btn
                                    .SetLargeImage(Resources.circle_caribbean_blue_32x32)
                                    .SetSmallImage(Resources.circle_caribbean_blue_16x16)
                                    .SetToolTips("Turn On Event"))
                            .CreateButton<CmdHelloWorld>("pdbY", "Not Assign 1",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<CmdHelloWorld>("pdbButtonZ", "Not Assign 2",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16));
                    }).RvtPulldownButton;
            panelLearning
                .CreateSplitButton("splBtn1","Selection",
                    spl =>spl.CreateButton<CmdHelloWorld>("splButton1", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_caribbean_blue_32x32)
                                    .SetSmallImage(Resources.circle_caribbean_blue_16x16))

                            .CreateButton<CmdHelloWorld>("splButton2", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<CmdHelloWorld>("splButton3", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<CmdHelloWorld>("splButton4", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<CmdHelloWorld>("splButton5", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<CmdHelloWorld>("splButton6", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<CmdHelloWorld>("splButton7", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16)));


            myTab
                .Panel("Panel2")
                    .CreateButton("pl2_btn1",
                        "Not Assign",
                        typeof(CmdHelloWorld),
                        btn => btn
                            .SetLargeImage(Resources.arrow_royal_blue_32x32)
                            .SetSmallImage(Resources.arrow_royal_blue_16x16)
                            .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"))
                .CreateSeparator()
                    .CreateButton("pl2_btn2",
                        "Not Assign",
                        typeof(CmdHelloWorld),
                        btn => btn
                            .SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                            .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                            .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"));

            //Create the ribbon on the systemtab
            ribbon
                .Tab(Autodesk.Revit.UI.Tab.AddIns)
                .Panel("VC1")
                .CreateButton<CmdHelloWorld>("btn1_1", "Button1",
                    btn => btn.SetLargeImage(Resources.x_mark_soylent_red_16x16));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uiApp)
        {
            return Result.Succeeded;
        }

    }
}
