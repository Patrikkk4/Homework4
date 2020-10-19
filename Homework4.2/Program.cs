using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight; // Установка размера консоли
            Console.WindowWidth = Console.LargestWindowWidth;   //

            int n = 0; // Переменная количества строк

            Console.Write("Введите желаемое колличество строк: ");
            try // Проверка корректности ввода ввода
            {
                n = int.Parse(Console.ReadLine()); // Ввод количества строк
            }
            catch // обработка при некорректном вводе
            {
                Console.WriteLine("некорректный параметр"); // Сообщение при некорректном коде
            }
           


            for(int i = 0; i < n; i++)
            {
                int MinInt = 1; // Минимальное начальное число (Вершина треугольника)

                for(int j = 0; j < n - i; j++) // Цикл создания пробелов между символами
                {
                    Console.Write("     "); // Создание пробелов между символами
                }

                for(int k = 0; k <= i; k++) // Цикл вывода треугольника
                {
                    Console.Write("  {0, 7} ", MinInt); // Форматирование и вывод символов
                    MinInt = MinInt * (i - k) / (k + 1); // формула расчета вывода следующих строк                  
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
