using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        static float resultBlock_1;
        static float resultBlock_2;
        static float resultBlock_3;
        static float resultBlock_4;
        static float resultBlock_5;


        static void Main(string[] args)
        {
            //WriteDateTimeNowEndResultToFileLog();


            while (true)
            {
                Console.WriteLine("\nВыбор варианта работы программы:\n " +
                "\nВведите 1 Для расчёта мощности (Р) с трёхфазной, симметричной нагрузкой." +
                "\nВведите 2 Для расчёта силы тока (I) от мощности (Р) с трёхфазной, симметричной нагрузкой." +
                "\nВведите 3 Для расчёта мощности (Р) с трёхфазной, НЕ симметричной нагрузкой." +
                "\nВведите 4 Для расчёта мощности (Р) в однофазной цепи." +
                "\nВведите 5 Для расчёта силы тока (I) в однофазной цепи.");

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
                    case 4:
                        Console.WriteLine("Запущен 4-ий вариант работы программы\n");
                        Console.WriteLine(new string('_', 80));
                        OnePhaseLoadPower();
                        break;
                    case 5:
                        Console.WriteLine("Запущен 5-ий вариант работы программы\n");
                        Console.WriteLine(new string('_', 80));
                        OnePhaseCurrentFromPower();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы неверно выбрали режим работы.\nНажмите ENTER, а затем 1, 2 или 3 для выбора режима работы программы ...");
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.WriteLine(new string('_', 80));
                        break;
                } // Вызовы методов в программе через 1,2,3 .. .. 

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
            Console.WriteLine($"\nМощьность трёхфазной, симметричной нагрузки равна: {P / 1000} кВт \n------------------------------------------------------");
            
            resultBlock_1 = P;
            string Msg = "Дата и время запуска программы: ";
            string MsgResult = "Результат выполнения програмы №1 (Мощьность трёхфазной, симметричной нагрузки): ";
            string pathFile = @"C:\Users\kaand\Desktop\El_Log.txt"; //путь к файлу в который пишем текущую дату и время
            DateTime dateTimeNow = DateTime.Now; // переменная dateTimeNow текущая дата и время
            File.AppendAllText(pathFile, $"\n{Msg}{dateTimeNow}\n{MsgResult} {resultBlock_1/1000} кВт"); // читать описание метода (записываем текущую дату и время в файл)
            
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
            Console.WriteLine($"\nСила Тока трёхфазной, симметричной нагрузки равна: {I.ToString("F" + 2)} Ампер \n-----------------------------------------------");
            
            resultBlock_2 = I;
            string Msg = "Дата и время запуска программы: ";
            string MsgResult = "Результат выполнения програмы №2 (Сила Тока трёхфазной, симметричной нагрузки): ";
            string pathFile = @"C:\Users\kaand\Desktop\El_Log.txt"; //путь к файлу в который пишем текущую дату и время
            DateTime dateTimeNow = DateTime.Now; // переменная dateTimeNow текущая дата и время
            File.AppendAllText(pathFile, $"\n{Msg}{dateTimeNow}\n{MsgResult} {resultBlock_2.ToString("F" + 2)} Ампер"); // читать описание метода (записываем текущую дату и время в файл)
            
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
            P = ((U * I_A) + (U * I_B) + (U * I_C)) * CosF;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nСуммарная мощьность трёхфазной, НЕ симметричной нагрузки равна: {P / 1000} кВт \n------------------------------------------------------");
            
            resultBlock_3 = P;
            string Msg = "Дата и время запуска программы: ";
            string MsgResult = "Результат выполнения програмы №3 (Суммарная мощьность трёхфазной, НЕ симметричной нагрузки): ";
            string pathFile = @"C:\Users\kaand\Desktop\El_Log.txt"; //путь к файлу в который пишем текущую дату и время
            DateTime dateTimeNow = DateTime.Now; // переменная dateTimeNow текущая дата и время
            File.AppendAllText(pathFile, $"\n{Msg}{dateTimeNow}\n{MsgResult} {resultBlock_3/1000} кВт"); // читать описание метода (записываем текущую дату и время в файл)

            Console.ResetColor();
            #endregion
        }


        static void OnePhaseLoadPower() //Расчёт мощьности P = U * I
        {
            #region
            Console.WriteLine("Расчёт мощности (Р) в однофазной цепи.\n// P = U * I\n");
            Console.Write($"В ведите ТОК в Амперах:  ");
            I = Convert.ToSingle(Console.ReadLine());
            P = U * I;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nМощьность равна: {P / 1000} кВт \n------------------------------------------------------");
            
            resultBlock_4 = P;
            string Msg = "Дата и время запуска программы: ";
            string MsgResult = "Результат выполнения програмы №4 (Мощьность): ";
            string pathFile = @"C:\Users\kaand\Desktop\El_Log.txt"; //путь к файлу в который пишем текущую дату и время
            DateTime dateTimeNow = DateTime.Now; // переменная dateTimeNow текущая дата и время
            File.AppendAllText(pathFile, $"\n{Msg}{dateTimeNow}\n{MsgResult} {resultBlock_4 / 1000} кВт"); // читать описание метода (записываем текущую дату и время в файл)

            Console.ResetColor();
            #endregion
        }

        static void OnePhaseCurrentFromPower() //Расчёт силы тока I = P / U
        {
            #region
            Console.WriteLine("Расчёт силы тока.\n// I = P / U\n");
            Console.Write($"Введите мощность в Ваттах:  ");
            P = Convert.ToSingle(Console.ReadLine());
            I = P / U;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nСила Тока равна: {I.ToString("F" + 2)} Ампер \n-----------------------------------------------");
            
            resultBlock_5 = I;
            string Msg = "Дата и время запуска программы: ";
            string MsgResult = "Результат выполнения програмы №5 (Сила Тока): ";
            string pathFile = @"C:\Users\kaand\Desktop\El_Log.txt"; //путь к файлу в который пишем текущую дату и время
            DateTime dateTimeNow = DateTime.Now; // переменная dateTimeNow текущая дата и время
            File.AppendAllText(pathFile, $"\n{Msg}{dateTimeNow}\n{MsgResult} {resultBlock_5.ToString("F" + 2)} Ампер"); // читать описание метода (записываем текущую дату и время в файл)

            Console.ResetColor();
            #endregion
        }

        //static void WriteDateTimeNowEndResultToFileLog()
        //{
        //    string Msg = "Дата и время запуска программы: ";
        //    string MsgResult = "Результат выполнения: ";
        //    string pathFile = @"C:\Users\kaand\Desktop\El_Log.txt"; //путь к файлу в который пишем текущую дату и время
        //    DateTime dateTimeNow = DateTime.Now; // переменная dateTimeNow текущая дата и время
        //    File.AppendAllText(pathFile, $"{Msg}{dateTimeNow}\n{MsgResult} {resultBlock_1}"); // читать описание метода (записываем текущую дату и время в файл)
        //}
    }
}
