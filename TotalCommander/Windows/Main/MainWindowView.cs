using System;
using System.Windows.Automation;
using Framework.Elements;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TotalCommander.Windows.Main
{
    internal class MainWindowView
    {
        private readonly int _indexOfElement;

        private List _listFiles;

        internal string PathFolder { get; set; }
        internal string FileName { get; set; }

        public MainWindowView(MainViewTypes type)
        {
            _indexOfElement = (int)type;
            InitElements();
        }

        public void InitElements()
        {
            _listFiles = new List(SearchCriteria.ByClassName("LCLListBox").AndIndex(_indexOfElement), 
                         "view folders " + (_indexOfElement + 1));
            FileName = "..";
        }

        public void ChooseView()
        {
            _listFiles.Click();
        }

        public TestStack.White.UIItems.ListBoxItems.ListItem GetFileItem(string fileName)
        {
            FileName = fileName;
            return _listFiles.GetListItem(FileName);
        }

        public UIItem List => _listFiles.GetList();

        public bool IsFolderOpened
        {
            get
            {
                Console.Write(PathFolder);
                return new Pane($"view path {PathFolder}",
                    new AndCondition(
                        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane),
                        new PropertyCondition(AutomationElement.NameProperty, $"{PathFolder.ToLower()}\\*.*"))).IsExist;
            }
        }
    }
}
