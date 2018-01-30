using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class Tab : BaseElement
    {
        public Tab(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, "Tab to " + elementName)
        {
        }

        public string NameTabItemSelected => ((TestStack.White.UIItems.TabItems.Tab) Get).SelectedTab.Name;
    }
}
