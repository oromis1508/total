using System.Windows.Automation;
using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class ListItem : BaseElement
    {
        public ListItem(Condition andCondition, string elementName) : base(elementName, andCondition)
        {
        }

        public ListItem(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, elementName)
        {   
        }
    }
}
