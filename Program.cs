using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Console.WriteLine("\nВыбор варианта работы программы:\n " +
                "\nВведите 1 Для расчёта мощности (Р) с трёхфазной, симметричной нагрузкой." +
                "\nВведите 2 Для расчёта силы тока (I) от мощности (Р) с трёхфазной, симметричной нагрузкой." +
                "\nВведите 3 Для расчёта мощности (Р) с трёхфазной, НЕ симметричной нагрузкой.");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Запущен 1-ый вариант работы программы\n");
                        Console.WriteLine(new string('_', 80));
                        ThreePhaseLoadPowerSymmetric();
                        break;
                    case 2:
                        Console.WriteLine("Запущен 2-ой вариант работы программы\n");
                        Console.WriteLine(new string('_', 80));
                        ThreePhaseCurrentFromPowerSymmetric();
                        break;
                    case 3:
                        Console.WriteLine("Запущен 3-ий вариант работы программы\n");
                        Console.WriteLine(new string('_', 80));
                        ThreePhaseLoadPowerAsymmetric();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы неверно выбрали режим работы.\nНажмите ENTER, а затем 1, 2 или 3 для выбора режима работы программы ...");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.WriteLine(new string ('_',80));
                        break;
                }

            }
            
        }

        static void ThreePhaseLoadPowerSymmetric() //Расчёт мощности (Р) с трёхфазной, симметричной нагрузкой.// P = 3*Uф*I* cosF
        {
            #region
            Console.WriteLine("Расчёт мощности (Р) с трёхфазной, симметричной нагрузкой.\n// P = 3*Uф*I* cosF\n");
            Console.Write($"В ведите ТОК в Амперах:  ");
            I = Convert.ToSingle(Console.ReadLine());
            Console.Write($"Введите cosF (от 0.1 до 1):  ");
            CosF = Convert.ToSingle(Console.ReadLine());
            P = U_3 * I * CosF;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nМощьность трёхфазной, симметричной нагрузки равна: {P/1000} кВт \n------------------------------------------------------");
            Console.ResetColor();
            #endregion
        }

        static void ThreePhaseCurrentFromPowerSymmetric() //Расчёт силы тока от мощности (Р) с трёхфазной, симметричной нагрузкой.// I = P/1.73*Uл*cosF
        {
            #region
            Console.WriteLine("Расчёт силы тока от мощности (Р) с трёхфазной, симметричной нагрузкой.\n// I = P/1.73*Uл*cosF\n");
            Console.Write($"Введите мощность в Ваттах:  ");
            P = Convert.ToSingle(Console.ReadLine());
            P /= 1000;
            Console.Write($"Введите cosF (от 0.1 до 1):  ");
            CosF = Convert.ToSingle(Console.ReadLine());
            I = P / (1.73f * Uline) * CosF;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nСила Тока трёхфазной, симметричной нагрузки равна: {I.ToString("F"+2)} Ампер \n-----------------------------------------------");
            Console.ResetColor();
            #endregion
        }

        static void ThreePhaseLoadPowerAsymmetric() //Расчёт мощности (Р) с трёхфазной, НЕ симметричной нагрузкой.// (P)общ = ((Ua*Ia*) + (Ub*Ib*) + (Uc*Ic*)) * cos(φ)
        {
            #region
            Console.WriteLine("Расчёт мощности (Р) с трёхфазной, НЕ симметричной нагрузкой.\n// (P)общ = (((Ua*Ia)+(Ub*Ib)+(Uc*Ic))*cos(φ))/3 \n");
            Console.Write($"В ведите ТОК фазы А :  ");
            I_A = Convert.ToSingle(Console.ReadLine());
            Console.Write($"В ведите ТОК фазы B :  ");
            I_B = Convert.ToSingle(Console.ReadLine());
            Console.Write($"В ведите ТОК фазы C :  ");
            I_C = Convert.ToSingle(Console.ReadLine());
            Console.Write($"Введите cosF (от 0.1 до 1):  ");
            CosF = Convert.ToSingle(Console.ReadLine());
            P = ((U * I_A ) + (U * I_B ) + (U * I_C )) * CosF;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nСуммарная мощьность трёхфазной, НЕ симметричной нагрузки равна: {P / 1000} кВт \n------------------------------------------------------");
            Console.ResetColor();
            #endregion
        }

    }
}
