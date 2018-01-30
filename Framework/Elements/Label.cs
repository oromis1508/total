using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class Label : BaseElement
    {
        public Label(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, "Label to " + elementName)
        {
        }
    }
}
