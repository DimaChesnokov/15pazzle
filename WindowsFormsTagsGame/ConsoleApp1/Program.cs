using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Profession worker = Profession.Плотник;
            worker = worker | Profession.столяр | (Profession.врач & Profession.учитель);
            Console.WriteLine(worker.ToString());
            //Тест гитхаб
        }


        [Flags]
        public enum Profession
        {
                Плотник = 1, столяр = 2, водитель = 4, учитель = 8, врач = 16
        }

    }
}
