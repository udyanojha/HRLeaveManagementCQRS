using Blazored.LocalStorage;
using HR.LeaveManagement.UI.ApiClient;
using System.Net.Http.Headers;

namespace HR.LeaveManagement.UI.Services.Base
{
    public class BaseHttpService
    {
        protected IWebApiExecuter _webApiExecuter;
        //protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IWebApiExecuter webApiExecuter)
        {
            _webApiExecuter = webApiExecuter;
        }
        //protected async Task AddBearerToken()
        //{
        //    if (await _localStorage.ContainKeyAsync("token"))
        //        await _webApiExecuter.AddBearerToken(this._localStorage);
        //}
    }
}
