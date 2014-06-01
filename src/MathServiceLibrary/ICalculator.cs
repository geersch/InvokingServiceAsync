using System;
using System.ServiceModel;

namespace CGeers.Wcf.Server.MathServiceLibrary
{
    // The Namespace property is provided for illustrative purposes    
    [ServiceContract(Namespace = "cgeers.wordpress.com")]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int x, int y);
    }        
}