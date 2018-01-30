using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TotalCommander.Windows;

namespace TotalCommander.Steps
{
    [Binding]
    public class FindFileSteps
    {

        [Then(@"Opened search dialog")]
        public void ThenOpenedSearchDialog()
        {
            var searchWindow = new SearchWindow();
            Assert.IsTrue(searchWindow.FieldSearchInIsExist(ScenarioContext.Current.Get<string>("searchView")), "Search path is correct");
            Assert.AreEqual("General", searchWindow.SearchTab.NameTabItemSelected, "Tab General is selected");
        }

        [When(@"I input '(.*)' as name of file")]
        public void SearchFile(string fileName)
        {
            new SearchWindow().SetSearchedFile(fileName);
        }

        [When(@"Put the RegEx checkbox")]
        public void Pu()
        {
            new SearchWindow().SetCheckRegEx();
        }

        [When(@"Click Start Search")]
        public void SearchFile()
        {
            new SearchWindow().StartSearch();
        }

        [Then(@"Finded (.*) file and (.*) folders")]
        public void CheckOnFindFile(int numFiles, int numFolders)
        {
            Assert.IsTrue(new SearchWindow().IsFindedFilesAndFolders(numFiles, numFolders), "Finded one file");
        }

        [When(@"I click the cross to close the window")]
        public void CloseSearchWindow()
        {
            new SearchWindow().CloseWindow();
        }
    }
}
