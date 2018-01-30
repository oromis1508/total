using System.IO;
using Framework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TotalCommander.Windows;
using TotalCommander.Windows.Main;

namespace TotalCommander.Steps
{
    [Binding]
    public class CutAndPasteFileSteps
    {
        [When(@"I cut '(.*)' from '(.*)' view and paste it to left view")]
        public void CutAndPasteCopiedFile(string cutingFile, string sideViewFrom)
        {
            new MainWindow().CutAndPaste(cutingFile, sideViewFrom);
        }

        [Then(@"Opened the move file dialog")]
        public void CheckOnTheMoveFileDialogOpened()
        {
            var moveFileDialog = new MoveFileDialog();
            Assert.IsTrue(moveFileDialog.IsWindowExist, $"The move file window exist");
            Assert.IsTrue(moveFileDialog.BtnReplace.IsExist, "Button Replace is exist");
            Assert.IsTrue(moveFileDialog.BtnSkip.IsExist, "Button Skip is exist");
        }

        [When(@"Click Replace in dialog and replace '(.*)' in '(.*)' view")]
        public void ClickReplaceInDialog(string replacedFile, string sideReplaceable)
        {
            var viewReplaceable = sideReplaceable.Equals("left") ? MainWindow.PageLeft : MainWindow.PageRight;
            new MoveFileDialog().AcceptReplace(Path.Combine(viewReplaceable.PathFolder, replacedFile));
        }

        [Then(@"File '(.*)' moved from '(.*)' and replaced in '(.*)'")]
        public void ThenFileMoved(string replacedFile, string sourceFolder, string destinationFolder)
        {
            var copiedFile = Path.Combine(sourceFolder, replacedFile);
            Assert.IsFalse(FileUtil.IsFileExist(copiedFile), $"{copiedFile} is not exist");
            Assert.AreNotEqual(FileUtil.GetDateTimeChange(),
                FileUtil.GetDateTimeChange(destinationFolder),
                "File replaced. Time of file writing changed");
        }
    }
}
