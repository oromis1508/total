using System.Windows.Automation;
using Framework.BaseClasses;
using Framework.Elements;
using TestStack.White.UIItems.Finders;

namespace TotalCommander.Windows
{
    internal class CheckWindow : BaseWindow
    {

        public CheckWindow() : base(GetWindow("Total Commander"))
        {
        }

        public void ClickButtonToContinue()
        {
            for (var i = 1; i <= 3; i++)
            {
                if (new Pane($"press button {i} to start program", 
                    new AndCondition(
                        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane),
                        new PropertyCondition(AutomationElement.NameProperty, i.ToString())))
                        .IsExist)
                {
                    new Button(SearchCriteria.ByText(i.ToString())
                        .AndControlType(ControlType.Button), 
                        $"start program with number {i}").Click();
                }
            }
        }

        public bool IsExistButton(string buttonName) => new Button(SearchCriteria.ByText(buttonName), 
                                                    $"choose digit {buttonName}").IsExist;
    }
}
