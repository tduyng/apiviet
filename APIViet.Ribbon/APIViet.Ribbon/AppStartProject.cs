#region Namespaces

using APIViet.Commands;
using APIViet.Ribbon.Properties;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

#endregion

namespace APIViet.Ribbon
{
    /// <summary>
    /// Create a ribbon tab
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class CmdApp : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication uiApp)
        {
            CustomRibbon ribbon = new CustomRibbon(uiApp);

            ribbon.Tab("MyTab")
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
                            .CreateButton<HelloWorld>("btn3", "1",
                                btn => btn.SetSmallImage(Resources.circle_caribbean_blue_16x16))
                            .CreateButton<HelloWorld>("btn4", "2",
                                btn => btn.SetSmallImage(Resources.circle_orange_16x16))
                            .CreateButton<HelloWorld>("btn5", "3",
                                btn => btn.SetSmallImage(Resources.circle_orange_16x16)))
                    .CreateStackedItems(si =>
                        si
                            .CreateButton<HelloWorld>("btn6", "4",
                                btn => btn.SetSmallImage(Resources.circle_guacamole_green_16x16))
                            .CreateButton<HelloWorld>("btn7", "5",
                                btn => btn.SetSmallImage(Resources.circle_soylent_red_16x16))
                            .CreateButton<HelloWorld>("btn8", "6",
                                btn => btn.SetSmallImage(Resources.emoticon_orange_16x16)));
            ribbon.Tab("MyTab")
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
                .Tab("JOTools")
                .Panel("Panel2")
                .CreateButton<HelloWorld>("btn4_2", "Button 4",
                    btn => btn.SetLargeImage(Resources.square_soylent_red_16x16));


            ribbon
                .Tab(Autodesk.Revit.UI.Tab.AddIns)
                .Panel("VC1")
                .CreateButton<HelloWorld>("btn1_1", "Button1",
                    btn => btn.SetLargeImage(Resources.x_mark_soylent_red_16x16));
            //ribbon
            //    .Tab("JOTools")
            //    .Panel("Rename")
            //    .CreateButton<HelloWorld>("btn1_2", "Button1",
            //        btn => btn.SetLargeImage(Resources.x_mark_soylent_red_16x16));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uiApp)
        {
            return Result.Succeeded;
        }

    }
}
