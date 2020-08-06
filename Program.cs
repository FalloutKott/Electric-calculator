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
        static float U_3 = U * 3; // 660 v
        static float CosF = default;
        static float I_A, I_B, I_C = default;
        
        

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выбор варианта работы программы: " +
                "\nвведите 1 Для расчёта мощности (Р) с трёхфазной, симметричной нагрузкой. // P = 3*Uф*I* cosF" +
                "\nвведите 2 Для расчёта силы тока (I) от мощности (Р) с трёхфазной, симметричной нагрузкой. // I = P/1.73*Uл*cosF" +
                "\nвведите 3 Для расчёта мощности (Р) с трёхфазной, НЕ симметричной нагрузкой. // (P)общ = ((Ua*Ia*) + (Ub*Ib*) + (Uc*Ic*)) * cos(φ)");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Start 1");
                        ThreePhaseLoadPowerSymmetric();
                        break;
                    case 2:
                        Console.WriteLine("Start 2");
                        ThreePhaseCurrentFromPowerSymmetric();
                        break;
                    case 3:
                        Console.WriteLine("Start 3");
                        ThreePhaseLoadPowerAsymmetric();
                        break;

                    default:
                        Console.WriteLine("default...");
                        Console.ReadLine();
                        break;
                }

                Console.ReadLine();
            }
            
            
        }

        static void ThreePhaseLoadPowerSymmetric() //Расчёт мощности (Р) с трёхфазной, симметричной нагрузкой.// P = 3*Uф*I* cosF
        {
            #region
            Console.WriteLine("Расчёт мощности (Р) с трёхфазной, симметричной нагрузкой.// P = 3*Uф*I* cosF\n");
            Console.Write($"В ведите ТОК в Амперах:  ");
            I = Convert.ToSingle(Console.ReadLine());
            Console.Write($"Введите cosF (от 0.1 до 1):  ");
            CosF = Convert.ToSingle(Console.ReadLine());
            P = U_3 * I * CosF;
            Console.WriteLine($"\nМощьность трёхфазной, симметричной нагрузки равна: {P/1000} кВт \n------------------------------------------------------");
            #endregion
        }

        static void ThreePhaseCurrentFromPowerSymmetric() //Расчёт силы тока от мощности (Р) с трёхфазной, симметричной нагрузкой.// I = P/1.73*Uл*cosF
        {
            #region
            Console.WriteLine("Расчёт силы тока от мощности (Р) с трёхфазной, симметричной нагрузкой.// I = P/1.73*Uл*cosF\n");
            Console.Write($"Введите мощность в Ваттах:  ");
            P = Convert.ToSingle(Console.ReadLine());
            P /= 1000;
            Console.Write($"Введите cosF (от 0.1 до 1):  ");
            CosF = Convert.ToSingle(Console.ReadLine());
            I = P / (1.73f * Uline) * CosF;
            Console.WriteLine($"\nСила Тока трёхфазной, симметричной нагрузки равна: {I.ToString("F"+2)} Ампер \n-----------------------------------------------");
            #endregion
        }

        static void ThreePhaseLoadPowerAsymmetric() //Расчёт мощности (Р) с трёхфазной, НЕ симметричной нагрузкой.// (P)общ = ((Ua*Ia*) + (Ub*Ib*) + (Uc*Ic*)) * cos(φ)
        {
            #region
            Console.WriteLine("Расчёт мощности (Р) с трёхфазной, НЕ симметричной нагрузкой.// (P)общ = (((Ua*Ia*) + (Ub*Ib*) + (Uc*Ic*)) * cos(φ)) / 3 \n");
            Console.Write($"В ведите ТОК фазы А :  ");
            I_A = Convert.ToSingle(Console.ReadLine());
            Console.Write($"В ведите ТОК фазы B :  ");
            I_B = Convert.ToSingle(Console.ReadLine());
            Console.Write($"В ведите ТОК фазы C :  ");
            I_C = Convert.ToSingle(Console.ReadLine());
            Console.Write($"Введите cosF (от 0.1 до 1):  ");
            CosF = Convert.ToSingle(Console.ReadLine());
            P = ((U * I_A ) + (U * I_B ) + (U * I_C )) * CosF;
            Console.WriteLine($"\nСуммарная мощьность трёхфазной, НЕ симметричной нагрузки равна: {P / 1000} кВт \n------------------------------------------------------");
            #endregion
        }

    }
}
