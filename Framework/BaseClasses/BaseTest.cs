using Framework.Utils;
using TechTalk.SpecFlow;

namespace Framework.BaseClasses
{
    public class BaseTest
    {
        [BeforeScenario]
        public void Init()
        {
            ProcessUtil.CloseApplication();
        }
    }
}
