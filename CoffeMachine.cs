using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCoffeeMachine
{
    // CoffeeMachine
    class CoffeeMachine
    {
        private IMachineState _state = new WaitingState();
        private List<INotifier> _observers = new();

        public void SetState(IMachineState state)
        {
            _state = state;
        }

        public void AddObserver(INotifier notifier) => _observers.Add(notifier);

        public void NotifyObservers()
        {
            foreach (var obs in _observers)
            {
                obs.Notify("Đồ uống đã được pha xong!");
            }
        }

        public void SelectCoffee() => _state.SelectBeverage(new Coffee(), this);
        public void SelectTea() => _state.SelectBeverage(new Tea(), this);
        public void SelectChocolate() => _state.SelectBeverage(new Chocolate(), this);

        public void Pause() => _state.Pause(this);
        public void Stop() => _state.Stop(this);
    }

}
