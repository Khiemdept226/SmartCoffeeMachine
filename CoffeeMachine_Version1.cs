
// -------------------- PHIÊN BẢN 1 --------------------
using System;
using System.Collections.Generic;

// Template Method
abstract class Beverage
{
    public void Make()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    protected virtual void BoilWater()
    {
        Console.WriteLine("Đun nước...");
    }

    protected abstract void Brew();

    protected virtual void PourInCup()
    {
        Console.WriteLine("Rót ra cốc...");
    }

    protected abstract void AddCondiments();
}

class Coffee : Beverage
{
    protected override void Brew() => Console.WriteLine("Pha cà phê...");
    protected override void AddCondiments() => Console.WriteLine("Thêm đường và sữa...");
}

class Tea : Beverage
{
    protected override void Brew() => Console.WriteLine("Ngâm trà...");
    protected override void AddCondiments() => Console.WriteLine("Thêm chanh...");
}

class Chocolate : Beverage
{
    protected override void Brew() => Console.WriteLine("Khuấy bột socola...");
    protected override void AddCondiments() => Console.WriteLine("Thêm marshmallow...");
}

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
