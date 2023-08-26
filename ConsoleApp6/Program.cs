using System;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Enter()
        {
            // ввод

            Console.WriteLine("МЕНЮ:");
            Console.WriteLine("Для ввода вручную нажмите 1");
            Console.WriteLine("Для загрузки из файла нажмите 2");
            int k = Convert.ToInt32(Console.ReadLine());
            switch (k)
            {
                case 1:
                    EnterKey();
                    break;
                case 2:
                    EnterFromFile();
                    break;
                default:
                    Console.WriteLine("Выбран неверный пункт меню!");
                    break;
            }
        }
        static public void EnterKey()
        {
            //ввод вручную 
            try
            {
                Console.WriteLine("Введите кол-во наблюдений в ряду данных");
                n = Convert.ToInt32(Console.ReadLine());
                masy = new double[n];
                masx1 = new double[n];
                masx2 = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите y №{0}", i + 1);
                    masy[i] = Convert.ToDouble(Console.ReadLine());
                }

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите x1 №{0}", i + 1);
                    masx1[i] = Convert.ToDouble(Console.ReadLine());
                }
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите x2 №{0}", i + 1);
                    masx2[i] = Convert.ToDouble(Console.ReadLine());
                }
                Console.Write("   y    x1   x2");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("\n{0,5}{1,5}{2,5}", masy[i], masx1[i], masx2[i]);

                }
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при вводе");
            }
        }
        static public void EnterFromFile()
        {
            //ввод из файла  
            try
            {
                string str;
                Console.WriteLine("Введите имя файла");
                {
                    StreamReader file = new StreamReader(Console.ReadLine());
                    str = file.ReadLine();
                    n = Int32.Parse(str);
                    masy = new double[n];
                    masx1 = new double[n];
                    masx2 = new double[n];
                    Console.WriteLine(n);
                    string[] mas;
                    for (int i = 0; i < n; i++)
                    {
                        str = file.ReadLine();
                        mas = str.Split('|');
                        masy[i] = Convert.ToDouble(mas[0]);
                        masx1[i] = Convert.ToDouble(mas[1]);
                        masx2[i] = Convert.ToDouble(mas[2]);
                    }
                    file.Close();
                    Console.Write("   y    x1   x2");
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("\n{0,5}{1,5}{2,5}", masy[i], masx1[i], masx2[i]);

                    }
                    Console.WriteLine();



                }
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при вводе из файла");
            }
        }

        static void Count()
        {
            // расчет  
            try
            {
                for (int i = 0; i < n; i++)
                {
                    sumy += masy[i];
                    sumx1 += masx1[i];
                    sumx2 += masx2[i];
                    sumyx1 += masy[i] * masx1[i];
                    sumyx2 += masy[i] * masx2[i];
                    sumx1x2 += masx1[i] * masx2[i];
                    sumx1x1 += masx1[i] * masx1[i];
                    sumx2x2 += masx2[i] * masx2[i];
                }

                op = (((n * sumx1x1 * sumx2x2) + (sumx1 * sumx1x2 * sumx2) + (sumx1 * sumx1x2 * sumx2)) - ((sumx2 * sumx1x1 * sumx2) + (n * sumx1x2 * sumx1x2) + (sumx1 * sumx1 * sumx2x2)));
                if (op != 0)
                {
                    op1 = (((sumy * sumx1x1 * sumx2x2) + (sumyx1 * sumx1x2 * sumx2) + (sumx1 * sumx1x2 * sumyx2)) - ((sumyx2 * sumx1x1 * sumx2) + (sumy * sumx1x2 * sumx1x2) + (sumyx1 * sumx1 * sumx2x2)));
                    op2 = (((n * sumyx1 * sumx2x2) + (sumx1 * sumyx2 * sumx2) + (sumy * sumx1x2 * sumx2)) - ((sumx2 * sumyx1 * sumx2) + (n * sumyx2 * sumx1x2) + (sumx1 * sumy * sumx2x2)));
                    op3 = (((n * sumx1x1 * sumyx2) + (sumx1 * sumx1x2 * sumy) + (sumx1 * sumyx1 * sumx2)) - ((sumy * sumx1x1 * sumx2) + (n * sumyx1 * sumx1x2) + (sumx1 * sumx1 * sumyx2)));

                    b0 = op1 / op;
                    b1 = op2 / op;
                    b2 = op3 / op;
                    b0 = Math.Round(b0, 3);
                    b1 = Math.Round(b1, 3);
                    b2 = Math.Round(b2, 3);



                    Console.WriteLine("Система ур-ний:");
                    Console.Write("{0} = {1}*b0 + {2}*b1 + {3}*b2 \n{4} = {2}*b0 + {5}*b1 + {6}*b2 \n{7} = {3}*b0 + {6}*b1 + {8}*b2", sumy, n, sumx1, sumx2, sumyx1, sumx1x1, sumx1x2, sumyx2, sumx2x2);
                    Console.WriteLine("\nКоэф.:");
                    Console.Write("b0 = {0}; b1 = {1}; b2 = {2}", b0, b1, b2);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Определитель равен нулю");
                }

            }
            catch
            {
                Console.WriteLine("Возникла ошибка при расчете");
            }
        }
        static void SaveToFile()
        {
            // сохранение 
            try
            {
                string name;
                Console.WriteLine("Введите имя файла");
                {
                    name = Console.ReadLine();
                    FileStream sfile = new FileStream(name, FileMode.OpenOrCreate);
                    StreamWriter sfl = new StreamWriter(sfile);
                    sfl.WriteLine(n);
                    sfl.Write("   y    x1   x2");
                    for (int i = 0; i < n; i++)
                    {

                        sfl.Write("\n{0,5}{1,5}{2,5}", masy[i], masx1[i], masx2[i]);

                    }
                    sfl.Write("\nkoef.:");
                    sfl.Write("b0 = {0}; b1 = {1}; b2 = {2}", b0, b1, b2);
                    sfl.Close();
                    Console.WriteLine("Сохранено");
                }
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при сохранении");
            }


        }

        //переменные общей видимости  
        static double[] masy;
        static double[] masx1;
        static double[] masx2;
        static int n;
        static double sumy, sumx1, sumx2, sumyx1, sumyx2, sumx1x2, sumx1x1, sumx2x2;
        static double op, op1, op2, op3, b0, b1, b2;

        static void Main()
        {
            // тело программы
            // меню в бесконечном цикле
            int line = 0;

            while (true)
            {
                Console.WriteLine("МЕНЮ:");
                Console.WriteLine("Для ввода данных нажмите 1");
                Console.WriteLine("Для расчета резльтата нажмите 2");
                Console.WriteLine("Для сохранения данных и результата в файл нажмите 3");
                Console.WriteLine("Для выхода нажмите 4");
                int k = Convert.ToInt32(Console.ReadLine());

                switch (k)
                {
                    case 1:
                        Enter();
                        line = 1;
                        break;
                    case 2:
                        if (line != 1) { Console.WriteLine("Не был осуществлен ввод данных!"); }
                        else { Count(); }
                        break;
                    case 3:
                        SaveToFile();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Выбран неверный пункт меню!");
                        break;
                }
            }
        }
    }
}