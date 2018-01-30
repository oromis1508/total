using System;
using System.IO;
using Framework.Elements;
using Framework.Utils;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using TotalCommander.Windows.Main;

namespace TotalCommander.Windows
{
    internal class PerformCopyingWindow : MainWindow
    {
        private readonly Button _btnConfirm = new Button(SearchCriteria.ByText("OK"), "confirm copying");

        public PerformCopyingWindow()
        {
            GetModalWindow("Total Commander");
        }

        public void PerformCopying(string destinationFolder, string copiedFile)
        {
            _btnConfirm.Click();
            Retry.For(() => FileUtil.IsFileExist(Path.Combine(destinationFolder, copiedFile)),
                                                    TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(0.1));
        }
    }
}
