using System;
using Framework.BaseClasses;
using Framework.Elements;
using Framework.Utils;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;

namespace TotalCommander.Windows
{
    internal class MoveFileDialog : BaseWindow
    {
        internal readonly Button BtnReplace = new Button(SearchCriteria.ByText("Move and Replace"), 
                                            "replace the copying file in the destination folder");
        internal readonly Button BtnSkip = new Button(SearchCriteria.ByText("Don't move"), "don't move file");

        public MoveFileDialog() : base(GetWindow("Move File"))
        {
        }

        public void AcceptReplace(string replacedFile)
        {
            BtnReplace.Click();
            Retry.For(() => !FileUtil.IsFileExist(replacedFile), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(0.2));
        }
    }
}
