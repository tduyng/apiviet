#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using ApiViet.Properties;
using ApiViet.Ribbon;
using ApiViet.Learning;

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
            myTab
                .Panel("Learning")
                .CreateButton("btnIdElement",
                    "ID Element",
                    typeof(CmdSelectElement),
                    btn => btn
                        .SetLargeImage(Resources.arrow_royal_blue_32x32)
                        .SetSmallImage(Resources.arrow_royal_blue_16x16)
                        .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"))
                .CreateSeparator()
                .CreateButton("btnCollectWindow",
                    "Collect\nWindow",
                    typeof(CmdCollector),
                    btn => btn
                        .SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                        .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                        .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"))
                .CreateSeparator()
                .CreateStackedItems(si =>
                    si
                        .CreateButton<CmdCollectorWithLINQ>("BtnCreateFamily", "CreateCars",
                            btn => btn.SetSmallImage(Resources.circle_caribbean_blue_16x16))
                        .CreateButton<CmdCreateLineBaseElement>("btnCreateWall", "CreateWall",
                            btn => btn.SetSmallImage(Resources.circle_orange_16x16))
                        .CreateButton<HelloWorld>("siButton3", "Not Assign",
                            btn => btn.SetSmallImage(Resources.circle_orange_16x16)))
                .CreateStackedItems(si =>
                    si
                        .CreateButton<HelloWorld>("siButton4", "Not Assign",
                            btn => btn.SetSmallImage(Resources.circle_guacamole_green_16x16))
                        .CreateButton<HelloWorld>("siButton5", "Not Assign",
                            btn => btn.SetSmallImage(Resources.circle_soylent_red_16x16))
                        .CreateButton<HelloWorld>("siButton6", "Not Assign",
                            btn => btn.SetSmallImage(Resources.emoticon_orange_16x16)))
                .CreateSeparator()
                .CreatePullDownButton("pdbBtn1",
                    "Options",
                    pdb =>
                    {
                        pdb.SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                            .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                            .SetToolTips("This is a test for creating a pulldown button");
                        pdb.CreateButton<HelloWorld>("pdbButtonX", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_caribbean_blue_32x32)
                                    .SetSmallImage(Resources.circle_caribbean_blue_16x16))

                            .CreateButton<HelloWorld>("pdbButtonY", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("pdbButtonZ", "Not Assign",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .SetContextualHelp(ContextualHelpType.Url, "https://github.com/TienDuyNGUYEN")
                            .SetToolTips("This is a awesome button!");
                    })
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
                            .CreateButton<HelloWorld>("splButton", "Not Assign",
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
