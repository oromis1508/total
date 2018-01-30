using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class Button : BaseElement
    {
        public Button(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, "Button to " + elementName)
        {
        }
    }
}
