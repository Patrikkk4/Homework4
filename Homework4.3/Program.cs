using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{ "Поочередно введите высоту, ширину и действие, которые вы хотите совершить с матрицами.\n",100}" +
               $"{"Недопускаются разные значения высоты и ширины.\n",80}" +
               $"{"Ввод производится цифрами.\n",69}");

            
            int tempInt;
            int heightMas = 0; // Переменная ввода количества строк
            int longMas = 0; // Переменная ввода количества столбцов
            int number = 0; // перменная для проверки неверных значений

            Console.Write("Введите высоту матрицы: ");
            control(heightMas); // Вызов метода корректности ввода для количества строк
            heightMas = tempInt; // Присваивание переменной количества строк введенного значения

            Console.Write("\nВведите ширину матрицы: ");
            control(longMas); // Вызов метода корректности ввода для количества столбцов
            longMas = tempInt; // Присваивание переменной количества столбцов введенного значения

            Console.Write("\nВведите число на которое хотите умножить матрицу: ");
            control(number);
            number = tempInt;

            void control(int varCheck) // метод проверки корректности ввода
            {
                if (!int.TryParse(Console.ReadLine(), out tempInt)) //Условие вывода ошибки некорректного ввода
                {
                    Console.WriteLine("вы ввели неправильный параметр. Нажмите любую клавишу для выхода");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            }

            int[,] mas = new int[longMas, heightMas]; // Создание двумерного массива

            Random r = new Random(); // Генерирование случайных чисел для матриц

            createMas(mas); // Вызов метода для создания первого массива
            calculation(mas); // Вызов метода расчета

            void createMas(int[,] TempMas) // Метод создания массивов
            {
                Console.WriteLine("\nПервоначальная матрица: ");
                for (int i = 0; i < longMas; i++) // Цикл заполнения столбцов
                {
                    TempMas[i, 0] = r.Next(1, 10); // Заполнения столбцов

                    for (int j = 0; j < heightMas; j++) // Цикл заполнения строк
                    {
                        TempMas[i, j] = r.Next(1, 10); // Заполнения строк
                        Console.Write(TempMas[i, j] + "| "); // Вывод массива
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            

            void calculation(int[,] tempMas) // Метод расчета
            {
                Console.Write("\nУмножаем на: " + number + "\n");

                Console.WriteLine("\nРезультат: ");

                for (int i = 0; i < longMas; i++) // Цикл заполнения результатов столбцов
                {
                    for (int j = 0; j < heightMas; j++) // Цикл заполнения результатов строк
                    {
                        tempMas[i, j] = number * tempMas[i, j]; // Формула умножения массивов  
                        Console.Write(String.Format("{0,4}", tempMas[i, j] + "| ")); // Вывод и форматирование результата 
                    }
                    
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine("Нажмите любую кнопку для выхода.");
            Console.ReadKey();
        }
    }
}
