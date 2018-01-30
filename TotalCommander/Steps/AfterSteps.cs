using Framework.BaseClasses;
using Framework.Utils;
using TechTalk.SpecFlow;

namespace TotalCommander.Steps
{
    public class AfterSteps : BaseTest
    {
        [AfterScenario]
        public void DeleteFiles()
        {
            FileUtil.DeleteFolder(ScenarioContext.Current.Get<string>("left"));
            FileUtil.DeleteFolder(ScenarioContext.Current.Get<string>("right"));
        }
    }
}
