using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class MenuItem : BaseElement
    {
        public MenuItem(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, $"MenuItem with name {elementName}")
        {
        }

        private MenuItem(TestStack.White.UIItems.MenuItems.Menu subMenu) : base(null, $"Menu item with name {subMenu.Name}")
        {
            Element = subMenu;
        }

        protected override void FindElement()
        {
            Element = BaseWindow.Window.MenuBar.MenuItemBy(SearchCriteria);
        }

        public MenuItem GetSubMenu(string subMenuName)
        {
            return new MenuItem(((TestStack.White.UIItems.MenuItems.Menu) Get).SubMenu(subMenuName));
        }
    }
}
