using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRab5
{
    class Program
    {
        static void Main(string[] args)
        {
            IntelligentCreature Roman = new Human(1860, " Телесный ");
            IntelligentCreature Bumbulbee = new Transformer(6000, " Желтый ", 10);
            IEngine IBumbulbee = new Transformer(6000, " Желтый ", 10);
            Roman.Display();
            Bumbulbee.Display();
            Console.WriteLine(Bumbulbee.Start());
            Console.WriteLine(IBumbulbee.Start());
            Console.WriteLine();
            Console.WriteLine(Bumbulbee is Transformer);
            Console.WriteLine(Bumbulbee is IntelligentCreature);
            IEngine v8 = Bumbulbee as IEngine;
            IntelligentCreature man = Bumbulbee as Transformer;
            Console.WriteLine(v8);
            Console.WriteLine(man);
            Console.WriteLine();
            Car ford = new Car();
            Console.WriteLine(ford.ToString());
            Console.WriteLine();

            IntelligentCreature Optimus = new Transformer(12000, "red", 100);
            IntelligentCreature Megatron = new Transformer(12000, "black", 200);
            IntelligentCreature Vlados = new Human(1850, "white");
            IntelligentCreature Valik = new Human(1840, "white");
            dynamic[] PrinterArray = { Optimus, Megatron, Vlados, Valik };
            Console.WriteLine("Printer");
            Console.WriteLine(Printer.IAmPrinting(Optimus));
            Console.WriteLine(Printer.IAmPrinting(Vlados));
            Console.WriteLine(Printer.IAmPrinting(Valik));
            Console.WriteLine(Printer.IAmPrinting(Megatron));
            Console.ReadLine();
        }
    }
    interface ICarControl
    {
        int grip { get; set; }
        int braking_distances { get; set; }

    }
    interface IEngine
    {
        int hp { get; set; }
        string type { get; set; }
        string name { get; set; }
        bool Start();
    }
    class Vehicle : ICarControl
    {
        public int wheit { get; set; }
        public string classification_group { get; set; }
        public int grip { get; set; }
        public int braking_distances { get; set; }
        public override string ToString()
        {
            return "ICarControl.Vechicle";

        }
    }
    sealed class Car : Vehicle, IEngine
    {
        public string color { get; set; }
        public int price { get; set; }
        public int hp { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public bool Start()
        {
            return true;
        }
        public override string ToString()
        {
            return "Vechicle.Car IEngine.Car";

        }
    }
    abstract class IntelligentCreature
    {
        public int height { get; set; }
        public string color_skin { get; set; }
        public IntelligentCreature(int Height, string Color_skin)
        {
            height = Height;
            color_skin = Color_skin;
        }
        public virtual void Display()
        {
            Console.WriteLine($"Человек, ростом {height} милиметров с цветом кожи: {color_skin}");
        }
        public abstract bool Start();
        public abstract override string ToString();
    }
    class Human : IntelligentCreature
    {
        public Human(int Height, string Color_skin) : base(Height, Color_skin)
        {
        }
        public override bool Start()
        {
            return true;
        }
        public override string ToString()
        {
            return "IntelligentCreature.Human";

        }
    }
    class Transformer : IntelligentCreature, IEngine
    {
        public int hp { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public int tank = 0;
        public Transformer(int Height, string Color_skin, int Tank) : base(Height, Color_skin)
        {
            tank = Tank;
        }
        public bool Start(int tank = 0)
        {
            if (tank > 0)
            {
                return true;
            }
            return false;
        }
        public override bool Start()
        {
            return true;
        }
        public override void Display()
        {
            Console.WriteLine($"Трансформер, высотой {height} миллиметров с поверхностью цвета: {color_skin}");
        }
        public override string ToString()
        {
            return "IntelligentCreature.Transformer";

        }
    }
    static class Printer
    {
        static internal string IAmPrinting(object someobj)
        {
            if (someobj is IntelligentCreature)
            {
                if (someobj is Transformer)
                {
                    IntelligentCreature tr = someobj as Transformer;
                    return Convert.ToString(tr);
                }
                if (someobj is Human)
                {
                    IntelligentCreature h = someobj as Human;
                    return Convert.ToString(h);
                }
                IntelligentCreature ic = someobj as IntelligentCreature;
                return Convert.ToString(ic);
            }
            return "Все плохо";

        }


    }
}
