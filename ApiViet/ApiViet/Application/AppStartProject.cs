#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using ApiViet.Properties;
using ApiViet.Ribbon;

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
            string nameTab = "TD";
            ribbon.Tab(nameTab)
                .Panel("Panel1")
                .CreateButton("btn1",
                    "Button1",
                    typeof(CmdCommand),
                    btn => btn
                        .SetLargeImage(Resources.arrow_royal_blue_32x32)
                        .SetSmallImage(Resources.arrow_royal_blue_16x16)
                        .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"))
                .CreateSeparator()
                .CreateButton("btn2",
                    "Button2",
                    typeof(CmdCommand),
                    btn => btn
                        .SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                        .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                        .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"))
                .CreateSeparator()
                .CreateStackedItems(si =>
                    si
                        .CreateButton<HelloWorld>("siButton1", "1",
                            btn => btn.SetSmallImage(Resources.circle_caribbean_blue_16x16))
                        .CreateButton<HelloWorld>("siButton2", "2",
                            btn => btn.SetSmallImage(Resources.circle_orange_16x16))
                        .CreateButton<HelloWorld>("siButton3", "3",
                            btn => btn.SetSmallImage(Resources.circle_orange_16x16)))
                .CreateStackedItems(si =>
                    si
                        .CreateButton<HelloWorld>("siButton4", "4",
                            btn => btn.SetSmallImage(Resources.circle_guacamole_green_16x16))
                        .CreateButton<HelloWorld>("siButton5", "5",
                            btn => btn.SetSmallImage(Resources.circle_soylent_red_16x16))
                        .CreateButton<HelloWorld>("siButton6", "6",
                            btn => btn.SetSmallImage(Resources.emoticon_orange_16x16)))
                .CreatePullDownButton("pdbBtn1",
                    "Options",
                    pdb =>
                    {
                        pdb.SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                            .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                            .SetToolTips("This is a test for creating a pulldown button");
                        pdb.CreateButton<HelloWorld>("pdbButtonX", "Button x",
                                btn => btn
                                    .SetLargeImage(Resources.circle_caribbean_blue_32x32)
                                    .SetSmallImage(Resources.circle_caribbean_blue_16x16))

                            .CreateButton<HelloWorld>("pdbButtonY", "Button y",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("pdbButtonZ", "Button z",
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
                        spl.CreateButton<HelloWorld>("splButton1", "Button 1",
                                btn => btn
                                    .SetLargeImage(Resources.circle_caribbean_blue_32x32)
                                    .SetSmallImage(Resources.circle_caribbean_blue_16x16))

                            .CreateButton<HelloWorld>("splButton2", "Button 2",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("splButton", "Button 3",
                                btn => btn
                                    .SetLargeImage(Resources.circle_orange_32x32)
                                    .SetSmallImage(Resources.circle_orange_16x16))
                            .SetContextualHelp(ContextualHelpType.Url, "https://github.com/TienDuyNGUYEN")
                            .SetToolTips("This is a awesome button!");
                    });


            ribbon.Tab(nameTab)
                .Panel("Panel2")
                    .CreateButton("pl2_btn1",
                        "Button1",
                        typeof(CmdCommand),
                        btn => btn
                            .SetLargeImage(Resources.arrow_royal_blue_32x32)
                            .SetSmallImage(Resources.arrow_royal_blue_16x16)
                            .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"))
                    .CreateSeparator()
                    .CreateButton("pl2_btn2",
                        "Button2",
                        typeof(CmdCommand),
                        btn => btn
                            .SetLargeImage(Resources.video_play_caribbean_blue_32x32)
                            .SetSmallImage(Resources.video_play_caribbean_blue_16x16)
                            .SetContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com"));

            ribbon
                .Tab(Autodesk.Revit.UI.Tab.AddIns)
                .Panel("VC1")
                .CreateButton<HelloWorld>("btn1_1", "Button1",
                    btn => btn.SetLargeImage(Resources.x_mark_soylent_red_16x16));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uiApp)
        {
            return Result.Succeeded;
        }

    }
}
