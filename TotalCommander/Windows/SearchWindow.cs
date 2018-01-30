using System.Windows.Automation;
using Framework.Elements;
using TestStack.White.UIItems.Finders;
using TotalCommander.Windows.Main;

namespace TotalCommander.Windows
{
    internal class SearchWindow : MainWindow
    {
        private readonly TextField _fieldSearchFor = new TextField(SearchCriteria.ByAutomationId("1001")
                                                .AndByText("")
                                                .AndNativeProperty(AutomationElement.IsEnabledProperty, true), 
                                                "input file name to search");
        private readonly Button _btnStartSearch = new Button(SearchCriteria.ByText("Start search"), 
                                                "start search");
        private readonly List _findResults = new List(SearchCriteria.ByControlType(ControlType.List)
                                                .AndByClassName("LCLListBox"), 
                                                "view the results of search");
        private readonly Button _btnCloseWindow = new Button(SearchCriteria.ByText("Close"), 
                                                "close search window");
        private readonly CheckBox _cbxRegEx = new CheckBox(SearchCriteria.ByText("RegEx"), "use regular exp");
        internal readonly Tab SearchTab = new Tab(SearchCriteria.ByControlType(ControlType.Tab),
            "properties of search");

        public SearchWindow()
        {
            GetModalWindow("Find Files");
        }

        public void SetSearchedFile(string fileName)
        {
            _fieldSearchFor.SetText(fileName);
        }

        public void SetCheckRegEx()
        {
            _cbxRegEx.SetCheck();
        }

        public void StartSearch()
        {
            _btnStartSearch.Click();
            WaitWhileWindowBusy();
        }

        public bool IsFindedFilesAndFolders(int numFiles, int numFolders) => 
            _findResults.GetListItem(0).Text.Contains($"{numFiles} files and {numFolders} directories");

        public void CloseWindow() => _btnCloseWindow.Click();

        public bool FieldSearchInIsExist(string searchSide)
        {
            var searchView = searchSide.Equals("left") ? PageLeft : PageRight;

            var fieldSearchIn = new TextField(SearchCriteria.ByAutomationId("1001")
                    .AndByText(searchView.PathFolder)
                    .AndNativeProperty(AutomationElement.IsEnabledProperty, true),
                "input folder to search");
            return fieldSearchIn.IsExist;
        }
    }
}
