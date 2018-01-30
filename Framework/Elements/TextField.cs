using Framework.BaseClasses;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class TextField : BaseElement
    {
        public TextField(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, "TextField to " + elementName)
        {
        }

        public void SetText(string text)
        {
            ((TextBox) Get).SetValue(text);
        }
    }
}
