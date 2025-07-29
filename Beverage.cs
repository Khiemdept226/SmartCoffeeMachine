using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCoffeeMachine
{
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

}
