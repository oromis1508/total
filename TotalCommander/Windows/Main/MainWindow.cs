using System;
using System.IO;
using System.Windows;
using System.Windows.Automation;
using Framework.BaseClasses;
using Framework.Elements;
using Framework.Utils;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using MenuItem = Framework.Elements.MenuItem;

namespace TotalCommander.Windows.Main
{
    internal class MainWindow : BaseWindow
    {
        internal static MainWindowView PageLeft = new MainWindowView(MainViewTypes.Left);
        internal static MainWindowView PageRight = new MainWindowView(MainViewTypes.Right);

        private readonly TextField _fieldToSetPath = new TextField(SearchCriteria.ByAutomationId("1001"),
                                            "set path");
        internal readonly List ListTree = new List(SearchCriteria.ByControlType(ControlType.List)
                                        .AndByClassName("LCLListBox").AndIndex(2), 
                                        "view tree");

        private readonly Point _findBtnPoint = new Point(460, 65);
        private readonly Point _separateTreeBtnPoint = new Point(150, 65);
        private const string WindowName = "Total Commander (x64) 9.12 - NOT REGISTERED";

        public MainWindow() : base(GetWindow(WindowName))
        {
        }

        public void OpenFolder(string folderPath, string viewSide)
        {
            FileUtil.CreateFolder(folderPath);
            OpenFolderInView(GetView(viewSide), folderPath);
        }

        public void CopyFile(string copyingFile, string sideViewFrom)
        {
            MainWindowView viewFrom = null;
            MainWindowView viewTo = null;
            if (sideViewFrom.Equals("left"))
            {
                viewFrom = PageLeft;
                viewTo = PageRight;
            } else if (sideViewFrom.Equals("right"))
            {
                viewFrom = PageRight;
                viewTo = PageLeft;
            }

            FileUtil.CreateFile(Path.Combine(viewFrom.PathFolder, copyingFile));
            OpenFolderInView(viewFrom, viewFrom.PathFolder);
            InputActions.DragAndDrop(viewFrom.GetFileItem(copyingFile), viewTo.List);
        }

        public void CutAndPaste(string cutingFile, string sideViewFrom)
        {
            var viewFrom = GetView(sideViewFrom);
            var viewTo = sideViewFrom.Equals("left") ? PageRight : PageLeft;
            WaitWhileWindowBusy();
            InputActions.MouseRightClickAndWait(Window.PopupMenu("Cut"), viewFrom.GetFileItem(cutingFile));
            GetWindow(WindowName).PopupMenu("Cut").Click();
            viewTo.ChooseView();
            InputActions.MouseRightClickAndWait(Window.PopupMenu("Paste"));
            GetWindow(WindowName).PopupMenu("Paste").Click();
        }

        public void OpenMenu(string menuPath)
        {
            WaitWhileWindowBusy();

            var menuItems = menuPath.Split(new[] { " -> " }, StringSplitOptions.None);
            var item = new MenuItem(SearchCriteria.ByText(menuItems[0]), menuItems[0]);
            MenuItem subitem = null;
            for (var i = 1; i < menuItems.Length; i++)
            {
                
                subitem = item.GetSubMenu(menuItems[i]);
                item = subitem;
            }
            subitem.Click();
            WaitWhileWindowBusy();
        }

        public void ClickOnButtonBar(string buttonName)
        {
            switch (buttonName)
            {
                case "Switch through tree panel options":
                    Retry.For(() =>
                    {
                        if (ListTree.IsExist)
                            InputActions.MouseClick(_separateTreeBtnPoint);
                        return !ListTree.IsExist;
                    }, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(0.1));
                    break;
                case "Search":
                    InputActions.MouseClick(_findBtnPoint);
                    break;
            }
        }

        public void SelectView(string viewSide)
        {
            GetView(viewSide).ChooseView();
        }

        public void DeselectAllFiles()
        {
            WaitWhileWindowBusy();
            PageLeft.ChooseView();
            PageLeft.GetFileItem("..").Click();
        }

        private void OpenFolderInView(MainWindowView mainWindowView, string folderPath)
        {
            mainWindowView.PathFolder = folderPath;
            mainWindowView.ChooseView();
            _fieldToSetPath.SetText($"cd {folderPath}");
            InputActions.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
        }

        private static MainWindowView GetView(string side) => side.Equals("left") ? PageLeft : PageRight;
    }
}
