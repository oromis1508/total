using Framework.Elements;
using TestStack.White.UIItems.Finders;
using TotalCommander.Windows.Main;

namespace TotalCommander.Windows
{
    internal class ErrorDialog : MainWindow
    {
        private readonly Button _btnOk = new Button(SearchCriteria.ByAutomationId("2"), 
                                        "apply and close error message");

        public ErrorDialog()
        {
            GetModalWindow("Total Commander");
        }

        public void PressOk() => _btnOk.Click();

        public bool IsTextErrorMatches(string textError) => new Label(SearchCriteria.ByText(textError),
                                                            $"error message {textError}").IsExist;
    }
}
