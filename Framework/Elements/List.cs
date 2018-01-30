using Framework.BaseClasses;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace Framework.Elements
{
    public class List : BaseElement
    {
        public List(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, "List to " + elementName)
        {
        }

        public TestStack.White.UIItems.ListBoxItems.ListItem GetListItem(string itemName)
        {
            return ((ListBox) Get).Items.Item(itemName); 
        }

        public TestStack.White.UIItems.ListBoxItems.ListItem GetListItem(int itemNum)
        {
            return ((ListBox)Get).Items.Item(itemNum);
        }

        public UIItem GetList()
        {
            return Get;
        }
    }
}
