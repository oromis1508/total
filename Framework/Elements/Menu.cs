using System.Windows.Automation;
using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowStripControls;

namespace Framework.Elements
{
    public class Menu : BaseElement
    {
        public Menu(Condition andCondition, string elementName) : base("Menu to " + elementName, andCondition)
        {
        }

        public Menu(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, "Menu to " + elementName)
        {
        }

        public void SelectMenuItem(SearchCriteria menuItemCriteria)
        {
            ((MenuBar) Get).MenuItemBy(menuItemCriteria).Click();
        }
    }
}
