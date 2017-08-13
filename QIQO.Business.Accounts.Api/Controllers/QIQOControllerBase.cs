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
            try
            {
                return Task.Run(() => codetoExecute.Invoke());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Source}:{ex.Message}");
                throw ex;
            }
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
