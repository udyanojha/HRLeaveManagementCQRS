using HR.LeaveManagement.UI.ApiClient;

namespace HR.LeaveManagement.UI.Services.Base
{
    public class BaseHttpService
    {
        protected IWebApiExecuter _webApiExecuter;

        public BaseHttpService(IWebApiExecuter webApiExecuter)
        {
            _webApiExecuter = webApiExecuter;
        }
    }
}
