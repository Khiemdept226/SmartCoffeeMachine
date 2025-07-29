using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCoffeeMachine
{
    // Observer Pattern
    interface INotifier
    {
        void Notify(string message);
    }

    class Logger : INotifier
    {
        public void Notify(string message) => Console.WriteLine($"[LOG] {message}");
    }

    class MobileApp : INotifier
    {
        public void Notify(string message) => Console.WriteLine($"[APP] {message}");
    }
}
