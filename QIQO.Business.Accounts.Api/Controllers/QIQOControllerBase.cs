using Microsoft.AspNetCore.Mvc;
using QIQO.Business.Core.Logging;
using System;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Api.Controllers
{
    public class QIQOControllerBase : Controller
    {
        protected Task<T> ExecuteHandledOperationAsync<T>(Func<T> codetoExecute)
        {
            return Task.Run(() => ExecuteHandledOperation(codetoExecute));
        }

        protected T ExecuteHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Source}:{ex.Message}");
                throw ex;
            }
        }

        protected void ExecuteHandledOperationAsync(Action codetoExecute)
        {
            Task.Run(() => ExecuteHandledOperation(codetoExecute));
        }

        protected void ExecuteHandledOperation(Action codetoExecute)
        {
            try
            {
                codetoExecute.Invoke();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Source}:{ex.Message}");
                throw ex;
            }
        }
    }
}
