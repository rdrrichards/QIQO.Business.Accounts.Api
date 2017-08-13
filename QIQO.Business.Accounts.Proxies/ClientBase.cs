using QIQO.Business.Core.Logging;
using System;

namespace QIQO.Business.Accounts.Proxies
{
    public class ClientBase
    {
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
