using System.Windows.Automation;
using Framework.Logger;
using TestStack.White.UIItems.Finders;

namespace Framework.BaseClasses
{
    public class BaseElement
    {
        protected SearchCriteria SearchCriteria;
        protected readonly string ElementName;
        protected dynamic Element;
        private readonly Condition _andCondition;

        public BaseElement(SearchCriteria searchCriteria, string elementName)
        {
            SearchCriteria = searchCriteria;
            ElementName = elementName;
        }

        public BaseElement(string elementName, Condition andCondition)
        {
            _andCondition = andCondition;
            ElementName = elementName;
        }

        protected dynamic Get
        {
            get
            {
                try
                {
                    if (_andCondition == null)
                    {
                        FindElement();
                    }
                    else
                    {
                        FindAutomationElement();
                    }
                    LogWriter.AddLog($"{ElementName} founded");
                } catch
                {
                    LogWriter.AddLog($"{ElementName} not found", LogType.Error);
                }
                return Element;
            }
        }

        private void FindAutomationElement() => Element = BaseWindow.Window.AutomationElement
                                            .FindFirst(TreeScope.Subtree, _andCondition);

        protected virtual void FindElement()
        {
            try
            {
                if (SearchCriteria != null)
                {
                    Element = BaseWindow.Window.Get(SearchCriteria);
                }
            }
            catch
            {
                Element = null;
            }
        }

        public bool IsExist => Get != null;

        public virtual void Click()
        {
            if (_andCondition == null)
            {
                Get.Click();
            }
            else
            {
                var automationElement = Get;
                var invokePattern = automationElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                invokePattern?.Invoke();
            }
        }
    }
}
