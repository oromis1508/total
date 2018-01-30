using Framework.BaseClasses;
using Framework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TotalCommander.Windows;

namespace TotalCommander.Steps
{
    [Binding]
    public class ValidationSteps : BaseTest
    {
        [When(@"I run app TotalCommander")]
        public void RunTotalCommander()
        {
            ApplicationRunner.RunApplication();
        }

        [Then(@"Validation window opened with buttons (.*), (.*) and (.*)")]
        public void CheckOnValidateWindowOpened(int buttonOneName, int buttonTwoName, int buttonThreeName)
        {
            var checkWindow = new CheckWindow();
            Assert.IsTrue(checkWindow.IsExistButton(buttonOneName.ToString()), $"Button {buttonOneName} exist");
            Assert.IsTrue(checkWindow.IsExistButton(buttonTwoName.ToString()), $"Button {buttonTwoName} exist");
            Assert.IsTrue(checkWindow.IsExistButton(buttonThreeName.ToString()), $"Button {buttonThreeName} exist");
        }

        [When(@"I click on valid button")]
        public void ClickValidButton()
        {
            new CheckWindow().ClickButtonToContinue();
        }
    }
}
