using System;
using CGeers.Wcf.Client.ConsoleClient.ServiceReference;

namespace CGeers.Wcf.Client.ConsoleClient
{
    public class MathOperationEventArgs : EventArgs
    {
        public int Result { get; set; }
    }

    public class Calculator
    {
        #region Event(s)

        public event EventHandler<MathOperationEventArgs> Added;        

        #endregion
    
        #region Asynchronous methods

        protected virtual void OnAdded(IAsyncResult asyncResult)
        {
            CalculatorClient proxy = asyncResult.AsyncState as CalculatorClient;
            if (proxy != null)
            {
                if (Added != null)
                {
                    Added(this, new MathOperationEventArgs { Result = proxy.EndAdd(asyncResult) });
                }                
            }
        }

        public void Add(int x, int y)
        {
            CalculatorClient proxy = new CalculatorClient();
            proxy.BeginAdd(x, y, ar => { OnAdded(ar); }, proxy);          
        }

        #endregion    
    }
}
