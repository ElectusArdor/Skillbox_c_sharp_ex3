using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool toExit = false;
            Console.WriteLine("Поиграем? y/n");
            string letsGo = Console.ReadLine();

            if ("YyНн".Contains(letsGo))
                Console.WriteLine("Поехали!");
            else
                Console.WriteLine("Я настаиваю :)");

            
            #region Задание 1 --------------------------------------------------------------------------
            bool flag1 = true;
            int a1 = 0;

            while (flag1)
            {
                IntInput(ref a1, ref flag1, "Введите целое число");

                if (flag1)
                {
                    if (a1 % 2 == 0 & flag1)
                        Console.WriteLine("Число чётное");
                    else
                        Console.WriteLine("Число не чётное");
                }

                flag1 = ExitCheck();
            }
            #endregion ---------------------------------------------------------------------------------
            
            #region Задание 2 --------------------------------------------------------------------------
            bool flag2 = true;

            string[] cards = new string[] { "J", "j", "Q", "q", "K", "k", "T", "t" };

            while (flag2)
            {
                int i = 1;
                int a2 = 0;
                int sum = 0;

                IntInput(ref a2, ref flag2, "Дратути. Сколько у вас карт?");

                if (flag2 & a2 >= 0 & a2 <= 11)
                {
                    Console.WriteLine("Валет = J  Дама = Q  Король = K  Туз = T");

                    while (i <= a2)
                    {
                        Console.Write($"{i}-я карта: ");
                        string card = Console.ReadLine();
                        if (cards.Contains(card))
                        {
                            sum += 10;
                            i++;
                        }
                        else if (int.TryParse(card, out int outInt) & outInt <= 10 & outInt >= 2)
                        {
                            sum += outInt;
                            i++;
                        }
                        else
                            Console.WriteLine("Нет такой карты");
                    }

                    Console.WriteLine($"Сумма карт равна {sum}");
                }
                else if (a2 < 0)
                    Console.WriteLine("Число карт не может быть меньше 0");
                else
                    Console.WriteLine("У вас явно перебор");

                flag2 = ExitCheck();
            }
            #endregion ---------------------------------------------------------------------------------

            #region Задание 3 --------------------------------------------------------------------------
            bool flag3 = true;
            int a3 = 0;

            while (flag3)
            {
                bool isPrime = false;
                int i = 2;

                IntInput(ref a3, ref flag3, "Введите целое число");

                if (flag3)
                {
                    while (i < a3 / 2)
                    {
                        if (a3 % i == 0)
                        {
                            isPrime = true;
                            break;
                        }
                        i++;
                    }
                    if (isPrime)
                        Console.WriteLine("Не простое");
                    else
                        Console.WriteLine("Простое");
                }

                flag3 = ExitCheck();
            }
            #endregion ---------------------------------------------------------------------------------

            #region Задание 4 --------------------------------------------------------------------------
            bool flag4 = true;
            int a4 = 0;

            while (flag4)
            {
                int i = 0;
                int inputValue = 0;
                int minNum = int.MaxValue;
                bool checkEnterNum = true;

                IntInput(ref a4, ref flag4, "Сколько чисел в последовательности?");

                if (flag4 & a4 > 0)
                {
                    Console.WriteLine("Введите числа через ENTER. Если надоест, введите пустую строку.");
                    while (i < a4)
                    {
                        IntInput(ref inputValue, ref checkEnterNum, "");

                        if (toExit)
                        {
                            Console.WriteLine($"Выполнение программы было прервано");
                            toExit = false;
                            break;
                        }

                        if (checkEnterNum)
                        {
                            if (minNum > inputValue) minNum = inputValue;
                            i++;
                        }
                    }

                    Console.WriteLine($"Наименьшее число {minNum}");
                }
                else
                    Console.WriteLine("Размер последовательности не может быть меньше 1");

                flag4 = ExitCheck();
            }
            #endregion ---------------------------------------------------------------------------------

            #region Задание 5 --------------------------------------------------------------------------
            bool flag5 = true;
            int a5 = 0;
            int answer = 0;
            int randValue = 0;
            Random rnd = new Random();

            while (flag5)
            {
                bool checkEnterNum = true;

                IntInput(ref a5, ref flag5, "Какое максимальное число использовать?");
                randValue = rnd.Next(0, a5 + 1);

                if (flag5 & a5 > 0)
                {
                    Console.WriteLine("Загадал, можете отгадывать. Если надоест, оставьте строку пустой и нажмите ENTER");
                    while (true)
                    {
                        IntInput(ref answer, ref checkEnterNum, "");

                        if (toExit)
                        {
                            Console.WriteLine($"Было загадано число {randValue}");
                            toExit = false;
                            break;
                        }

                        if (checkEnterNum)
                        {
                            if (randValue > answer)
                                Console.WriteLine("Загаданное число больше");
                            else if (randValue < answer)
                                Console.WriteLine("Загаданное число меньше");
                            else
                            {
                                Console.WriteLine("Вы угадали!");
                                break;
                            }
                        }
                    }
                }
                else
                    Console.WriteLine("Диапазон не может быть меньше 1");

                flag5 = ExitCheck();
            }
            #endregion ---------------------------------------------------------------------------------

            void IntInput(ref int a, ref bool flag, string title)
            {
                Console.WriteLine(title);
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int outInt))
                    a = outInt;
                else if (inputString == "")
                    toExit = true;
                else
                {
                    Console.WriteLine("Число введено некорректно");
                    flag = false;
                }
            }

            bool ExitCheck()
            {
                Console.WriteLine("Для перехода к следующему заданию нажмите Esc, для повтора любую другую клавишу");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    return false;
                else
                    return true;
            }
        }
    }
}
