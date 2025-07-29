using SmartCoffeeMachine;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var machine = new CoffeeMachine();

        // Thêm observer
        machine.AddObserver(new Logger());
        machine.AddObserver(new MobileApp());

        // Chọn cà phê
        machine.SelectCoffee(); // Chuyển sang trạng thái Đang pha, thực hiện công thức cà phê

        // Tạm dừng (không có tác dụng khi ở trạng thái Waiting)
        machine.Pause();

        // Chọn trà
        machine.SelectTea();

        // Trong trạng thái Brewing, thử Pause và Stop
        machine.Pause(); // Tạm dừng
        machine.Pause(); // Tiếp tục
        machine.Stop();  // Dừng hẳn và quay về trạng thái Chờ

        // Chọn socola
        machine.SelectChocolate();
    }
}