using Framework.BaseClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TotalCommander.Windows;
using TotalCommander.Windows.Main;

namespace TotalCommander.Steps
{
    [Binding]
    public class TotalCommanderFunctionsSteps : AfterSteps
    {
        [Then(@"Opened (.*) window")]
        public void CheckOnMainWindowOpened(string windowName)
        {
            var window = GetWindow(windowName);
            Assert.IsTrue(window.IsWindowExist, $"{windowName} window exist");
        }

        [When(@"I open '(.*)' in '(.*)' view")]
        public void OpenFolder(string folderPath, string viewSide)
        {
            ScenarioContext.Current.Add(viewSide, folderPath);
            new MainWindow().OpenFolder(folderPath, viewSide);
        }

        [Then(@"Folders opened")]
        public void CheckOnFoldersOpened()
        {
            Assert.IsTrue(MainWindow.PageLeft.IsFolderOpened, $"{MainWindow.PageLeft.PathFolder} is opened");
            Assert.IsTrue(MainWindow.PageRight.IsFolderOpened, $"{MainWindow.PageRight.PathFolder} is opened");
        }

        [When(@"I choose (.*) view")]
        public void ChooseLeftViewAndSearch(string sideOfView)
        {
            ScenarioContext.Current.Add("searchView", sideOfView);
            new MainWindow().SelectView(sideOfView);
        }

        [Then(@"(.*) window closed")]
        public void CheckOnSearchClosed(string windowName)
        {
            var window = GetWindow(windowName);
            Assert.IsFalse(window.IsWindowExist, $"{windowName} window closed");
        }

        [When(@"I deselect all files")]
        public void OpenMenuEditComment()
        {
            new MainWindow().DeselectAllFiles();
        }

        [Then(@"Opened error dialog with message with text '(.*)'")]
        public void CheckOnOpenErrorDialog(string errorText)
        {
            Assert.IsTrue(new ErrorDialog().IsTextErrorMatches(errorText), $"{errorText} is dispayed in the error dialog");
        }

        [When(@"I click Ok in error dialog")]
        public void ConfirmError()
        {
            new ErrorDialog().PressOk();
        }

        public BaseWindow GetWindow(string windowName)
        {
            switch (windowName.ToLower())
            {
                case "main":
                    return new MainWindow();
                case "error":
                    return new ErrorDialog();
                case "search":
                    return new SearchWindow();
                case "copying":
                    return new PerformCopyingWindow();
                default:
                    return null;
            }
        }
    }
}
