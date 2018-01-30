using Framework.BaseClasses;
using TestStack.White.UIItems.Finders;

namespace Framework.Elements
{
    public class CheckBox : BaseElement
    {
        public CheckBox(SearchCriteria searchCriteria, string elementName) : base(searchCriteria, elementName)
        {
        }

        public void SetCheck() => ((TestStack.White.UIItems.CheckBox)Get).Select();
    }
}
