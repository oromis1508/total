using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TotalCommander.Windows.Main;

namespace TotalCommander.Steps
{
    [Binding]
    public class SeparateTreeSteps
    {
        [When(@"I open menu (.*)")]
        public void OpenSeparateTreeView(string menuPath)
        {
            new MainWindow().OpenMenu(menuPath);
        }

        [Then(@"Opened additional view")]
        public void CheckOnTreeViewOpened()
        {
            Assert.IsTrue(new MainWindow().ListTree.IsExist, "Tree view opened");
        }

        [When(@"I click button «(.*)» on button bar (.*) times")]
        public void ChooseLeftViewAndSearch(string buttonName, int numClicks)
        {
            new MainWindow().ClickOnButtonBar(buttonName);
        }

        [Then(@"Additional view closed")]
        public void CheckOnAdditionalViewClosed()
        {
            Assert.IsFalse(new MainWindow().ListTree.IsExist, "Tree view closed");
        }
    }
}
