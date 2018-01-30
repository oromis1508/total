using System.Windows.Automation;
using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class Pane : BaseElement
    {
        public Pane(string elementName, Condition andCondition) : base("Pane to " + elementName, andCondition)
        {
        }

        public Pane(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, elementName)
        {
        }
    }
}
