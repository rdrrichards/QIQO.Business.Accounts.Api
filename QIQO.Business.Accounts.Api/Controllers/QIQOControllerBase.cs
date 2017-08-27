using Microsoft.AspNetCore.Mvc;
using QIQO.Business.Core.Logging;
using System;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Api.Controllers
{
    public class QIQOControllerBase : Controller
    {
        //protected Task<T> ExecuteHandledOperationAsync<T>(Func<T> codetoExecute)
        //{
        //    return Task.Run(() => ExecuteHandledOperation(codetoExecute));
        //}

        //protected T ExecuteHandledOperation<T>(Func<T> codetoExecute)
        //{
        //    try
        //    {
        //        return codetoExecute.Invoke();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error($"{ex.Source}:{ex.Message}");
        //        throw ex;
        //    }
        //}

        protected Task ExecuteHandledOperationAsync(Action codetoExecute)
        {
            return Task.Run(() => ExecuteHandledOperation(codetoExecute));
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

        protected Task<IActionResult> ExecuteHandledOperationAsync<T>(Func<T> codetoExecute)
        {
            return Task.Run(() => ExecuteHandledOperation(codetoExecute));
        }

        protected IActionResult ExecuteHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return Json(codetoExecute.Invoke());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Source}:{ex.Message}");
                return Json(ex);
            }
        }
    }
}
