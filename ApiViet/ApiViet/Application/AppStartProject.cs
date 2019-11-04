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
                        .ConvertToPushButton;

            panelLearning
                .CreateSeparator()
                .CreateButton("btnCollectWindow",
                    "Collect\nWindow",
                    typeof(CmdCollector),
                    btn => btn
                        .SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                        .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                        .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"));
            panelLearning
                .CreateSeparator()
                .CreateStackedItems(si =>
                    si
                        .CreateButton<CmdCollectorWithLINQ>("btnCreateFamily", "CreateCars",
                            btn => btn.SetSmallImage(Resources.circle_caribbean_blue_16x16))
                        .CreateButton<CmdCreateLineBaseElement>("btnCreateWall", "CreateWall",
                            btn => btn.SetSmallImage(Resources.circle_orange_16x16))
                        .CreateButton<CmdGetParameter>("btnGetParameter", "Get Parameter",
                            btn => btn.SetSmallImage(Resources.circle_orange_16x16)))
                .CreateStackedItems(si =>
                    si
                        .CreateButton<CmdSetParameter>("btnSetParameter", "Set Parameter",
                            btn => btn.SetSmallImage(Resources.circle_guacamole_green_16x16))
                        .CreateButton<CmdChangeLocation>("btnChangeLoc", "Change Location",
                            btn => btn.SetSmallImage(Resources.circle_soylent_red_16x16))
                        .CreateButton<CmdEditElement>("btnEditElement", "EditElement",
                            btn => btn.SetSmallImage(Resources.emoticon_orange_16x16)))
                .CreateSeparator();

            panelLearning
                .CreatePullDownButton("pdbBtn1",
                   "Options",
                   pdb =>
                   {
                       pdb.SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                           .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                           .SetToolTips("This is a test for creating a pulldown button");
                       pdb.CreateButton<CmdSelectGeometry>("cmdSelectGeometry", "Select Geometry",
                               btn => btn
                                   .SetLargeImage(Resources.circle_caribbean_blue_32x32)
                                   .SetSmallImage(Resources.circle_caribbean_blue_16x16))
                          .CreateButton<HelloWorld>("pdbY", "Not Assign",
                               btn => btn
                                   .SetLargeImage(Resources.circle_orange_32x32)
                                   .SetSmallImage(Resources.circle_orange_16x16)
                                   .SetToolTips("Turn On Event"))
                           .CreateButton<HelloWorld>("pdbButtonZ", "Not Assign",
                               btn => btn
                                   .SetLargeImage(Resources.circle_orange_32x32)
                                   .SetSmallImage(Resources.circle_orange_16x16))
                           .SetContextualHelp(ContextualHelpType.Url, "https://github.com/TienDuyNGUYEN")
                           .SetToolTips("This is a awesome button!");
                   });

            var pdbEvent = panelLearning
                .CreatePullDownButton("pdbBtn2",
                    "Options",
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
                            .CreateButton<HelloWorld>("pdbY", "Not Assign 1",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("pdbButtonZ", "Not Assign 2",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16));
                    }).ConvertToPulldownButton;
            var btnData1 = new CustomPushButton("pdbButton2Z", "Not Assign", typeof(HelloWorld));
            btnData1.SetLargeImage(Resources.circle_caribbean_blue_32x32);
            btnData1.SetSmallImage(Resources.circle_caribbean_blue_32x32);
            btnData1.SetToolTips("Turn on Event");
            var btnSpecial1 = pdbEvent.AddPushButton((PushButtonData)btnData1.GetButtonData()) ;
            var btnData2 = new CustomPushButton("pdbButton2Z2", "Not Assign", typeof(HelloWorld));
            btnData1.SetLargeImage(Resources.circle_caribbean_blue_32x32);
            btnData1.SetSmallImage(Resources.circle_caribbean_blue_32x32);
            var btnSpecial2 = pdbEvent.AddPushButton((PushButtonData)btnData1.GetButtonData());

            panelLearning
                .CreateSplitButton("splBtn1",
                    "Selection",
                    spl =>
                    {
                        spl.SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                            .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                            .SetToolTips("This is a test for creating a pulldown button");
                        spl.CreateButton<HelloWorld>("splButton1", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_caribbean_blue_32x32)
                                    .SetSmallImage(Resources.circle_caribbean_blue_16x16))

                            .CreateButton<HelloWorld>("splButton2", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("splButton3", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("splButton4", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("splButton5", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("splButton6", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("splButton7", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .SetContextualHelp(ContextualHelpType.Url, "https://github.com/TienDuyNGUYEN")
                            .SetToolTips("This is a awesome button!");
                    });


            myTab
                .Panel("Panel2")
                    .CreateButton("pl2_btn1",
                        "Not Assign",
                        typeof(CmdCommand),
                        btn => btn
                            .SetLargeImage(Resources.arrow_royal_blue_32x32)
                            .SetSmallImage(Resources.arrow_royal_blue_16x16)
                            .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"))
                .CreateSeparator()
                    .CreateButton("pl2_btn2",
                        "Not Assign",
                        typeof(CmdCommand),
                        btn => btn
                            .SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                            .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                            .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"));

            //Create the ribbon on the systemtab
            //ribbon
            //    .Tab(Autodesk.Revit.UI.Tab.AddIns)
            //    .Panel("VC1")
            //    .CreateButton<HelloWorld>("btn1_1", "Button1",
            //        btn => btn.SetLargeImage(Resources.x_mark_soylent_red_16x16));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uiApp)
        {
            return Result.Succeeded;
        }

    }
}
