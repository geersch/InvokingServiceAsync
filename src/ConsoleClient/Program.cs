using System;
using System.Threading;
using CGeers.Wcf.Client.ConsoleClient.ServiceReference;

namespace CGeers.Wcf.Client.ConsoleClient
{
    class Program
    {        
        static void Main()
        {
            bool stop = false;

            Calculator calculator = new Calculator();

            // Add an event handler for the Added event using an anonymous method.
            //calculator.Added += delegate(object sender, MathOperationEventArgs e)
            //{
            //    Console.WriteLine("The result of the addition is {0}.", e.Result);
            //    stop = true;
            //};

            // Add an event handler for the Added event using a Lambda expression.
            calculator.Added +=
                (s, e) =>
                {
                    Console.WriteLine("The result of the addition is {0}.", e.Result);
                    stop = true;
                };

            //Add 2 and 3.
            Console.WriteLine("Invoke the Add method.");
            calculator.Add(2, 3);

            while (!stop)
            {
                Console.WriteLine("The client is doing some stuff...");
                Thread.Sleep(250);
            }

            // The shortcut follows the same asynchronous invocation event pattern 
            // as the Calculator helper class.
            TheShortcut();

            Console.ReadLine();
        }

        private static void TheShortcut()
        {
            CalculatorClient proxy = new CalculatorClient();                
            proxy.AddCompleted +=
                (sender, e) =>
                {                            
                    Console.WriteLine("The result of the addition is {0}.", e.Result);                    
                };
            proxy.AddAsync(4, 2);            
        }        
    }
}
