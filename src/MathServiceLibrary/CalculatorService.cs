using System;
using System.ServiceModel;
using System.Threading;

namespace CGeers.Wcf.Server.MathServiceLibrary
{        
    public class CalculatorService : ICalculator
    {
        #region ICalculator Members

        public int Add(int x, int y)
        {
            // To simulate a lengthy request.
            Thread.Sleep(3000);
            return (x + y);
        }

        #endregion
    }
}
