using System;
using System.Runtime.Remoting.Messaging;

namespace DelegateExample
{
    class Program
    {
        public delegate int CalculatorOperation(int x, int y);

        static void Main()
        {
            // Synchronous invocation
            CalculatorOperation sycnOperation =
                new CalculatorOperation((x, y) => { return (x + y); });

            int result = sycnOperation(3, 2);
            Console.WriteLine("The result of the synchronous invocation is {0}.\n", result);                    

            // Asynchronous invocation            
            CalculatorOperation asyncOperation =
                new CalculatorOperation((x, y) => { return (x + y); });            
            
            asyncOperation.BeginInvoke(3, 2, ar => { OnAdded(ar); }, null);
            Console.WriteLine("The client application is doing some other stuff.");
            Console.WriteLine("Press enter to exit when the asynchronous invocation completes.\n");
            Console.ReadLine();
        }

        private static void OnAdded(IAsyncResult itfAsyncResult)
        {
            AsyncResult asyncResult = (AsyncResult)itfAsyncResult;
            CalculatorOperation operation = (CalculatorOperation)asyncResult.AsyncDelegate;
            int result = operation.EndInvoke(itfAsyncResult);
            Console.WriteLine("The result of the asynchronous invocation is also {0}.", result);
        }
    }
}
