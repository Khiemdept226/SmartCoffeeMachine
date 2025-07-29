using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCoffeeMachine
{
    // State Pattern
    interface IMachineState
    {
        void SelectBeverage(Beverage beverage, CoffeeMachine machine);
        void Pause(CoffeeMachine machine);
        void Stop(CoffeeMachine machine);
    }

    class WaitingState : IMachineState
    {
        public void SelectBeverage(Beverage beverage, CoffeeMachine machine)
        {
            Console.WriteLine("Bắt đầu pha đồ uống...");
            machine.SetState(new BrewingState());
            beverage.Make();
            machine.NotifyObservers();
            machine.SetState(new WaitingState());
        }

        public void Pause(CoffeeMachine machine)
        {
            Console.WriteLine("Không thể tạm dừng khi máy đang chờ.");
        }

        public void Stop(CoffeeMachine machine)
        {
            Console.WriteLine("Máy đã ở trạng thái chờ.");
        }
    }

    class BrewingState : IMachineState
    {
        public void SelectBeverage(Beverage beverage, CoffeeMachine machine)
        {
            Console.WriteLine("Đang pha, không thể chọn đồ uống mới.");
        }

        public void Pause(CoffeeMachine machine)
        {
            Console.WriteLine("Tạm dừng pha...");
            machine.SetState(new PausedState());
        }

        public void Stop(CoffeeMachine machine)
        {
            Console.WriteLine("Dừng pha...");
            machine.SetState(new WaitingState());
        }
    }

    class PausedState : IMachineState
    {
        public void SelectBeverage(Beverage beverage, CoffeeMachine machine)
        {
            Console.WriteLine("Máy đang tạm dừng, không thể chọn.");
        }

        public void Pause(CoffeeMachine machine)
        {
            Console.WriteLine("Tiếp tục pha...");
            machine.SetState(new BrewingState());
        }

        public void Stop(CoffeeMachine machine)
        {
            Console.WriteLine("Dừng pha...");
            machine.SetState(new WaitingState());
        }
    }

}
