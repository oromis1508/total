using System.IO;
using Framework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TotalCommander.Windows;
using TotalCommander.Windows.Main;

namespace TotalCommander.Steps
{
    [Binding]
    public class CopyFileSteps
    {
        [When(@"I move file '(.*)' from '(.*)' to right view")]
        public void MoveFile(string copyingFile, string sideViewFrom)
        {
            new MainWindow().CopyFile(copyingFile, sideViewFrom);
        }

        [When(@"I confirm copying file '(.*)' to '(.*)'")]
        public void ConfirmCopying(string copyingFile, string destinationFolder)
        {
            new PerformCopyingWindow().PerformCopying(destinationFolder, copyingFile);
        }

        [Then(@"File '(.*)' copied to '(.*)'")]
        public void CheckOnFileCopied(string copyingFile, string destinationFolder)
        {
            FileUtil.GetDateTimeChange(MainWindow.PageLeft.PathFolder);
            var copiedFile = Path.Combine(destinationFolder, copyingFile);
            Assert.IsTrue(FileUtil.IsFileExist(copiedFile), $"{copiedFile} is exist");
        }
    }
}
