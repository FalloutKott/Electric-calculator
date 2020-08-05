using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electric_calculator
{
    class Program
    {
        static float P = default;
        static float I = default;
        static float U = 220;
        static float Uline = 0.38f;
        static float U_3 = U * 3;
        static float CosF = default;

        static void Main(string[] args)
        {
            ThreePhaseLoadPower();
            ThreePhaseCurrentFromPower();
        }

        static void ThreePhaseLoadPower () //Расчёт мощности (Р) с трёх-фазной, симметричной нагрузкой.
        {
            Console.WriteLine($"В ведите ТОК (А) что бы расчитать мощьность в Вт ");

            I = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine($"Введите cosF (от 0.1 до 1)");

            CosF = Convert.ToSingle(Console.ReadLine());

            P = U_3 * I * CosF;
            Console.WriteLine($"Мощьность = {P/1000} кВт ");

        }

        static void ThreePhaseCurrentFromPower() ////Расчёт силы тока от мощности (Р) с трёх-фазной, симметричной нагрузкой.// I = P/1.73*Uл*cos φ
        {
            Console.WriteLine($"Введите мощность в Ваттах (Р)");

            P = Convert.ToSingle(Console.ReadLine());
            P /= 1000;

            Console.WriteLine($"Введите cosF (от 0.1 до 1)");

            CosF = Convert.ToSingle(Console.ReadLine());

            I = P / (1.73f * Uline) * CosF;

            Console.WriteLine($"Ток = {I} Ампер ");
        }
    }
}
