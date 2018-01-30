using System.Windows.Automation;
using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class ComboBox : BaseElement
    {
        public ComboBox(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, elementName)
        {
        }

        protected override void FindElement()
        {
            SearchCriteria = SearchCriteria.AndControlType(ControlType.ComboBox);
            base.FindElement();
        }

        public void SelectItem(string itemText)
        {
            ((TestStack.White.UIItems.ListBoxItems.ComboBox) Get).Select(itemText);
        }
    }
}
