using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{ "Поочередно введите количество строк и столбцов матриц.\n",85}" +
                $"{"Недопускаются разные значения количества столбцов первой матрицы\n", 90}" +
                $"{"и количество строк второй матрицы.\n",75}" +
                $"{"Ввод производится цифрами.\n",70}");

            int tempInt = 0; // перменная для проверки неверных значений
            int heightMas = 0; // Переменная ввода количества строк
            int longMas = 0; // Переменная ввода количества столбцов
            

            Random r = new Random(); // Генерирование случайных чисел для матриц

            void paramMas() // метод параметров массива
            {
                Console.Write("\nВведите количество строк: ");
                control(); // Вызов метода проверки корректности ввода для колличества столбцов 
                longMas = tempInt;

                Console.Write("\nВведите количество столбцов: ");
                control(); // Вызов метода проверки корректности ввода для колличества строк 
                heightMas = tempInt;
            }
            
            

            Console.Write("Введите параметры первой матрицы");
            paramMas(); // Вызов метода ввода параметров первого массива
            int[,] mas = new int[longMas, heightMas]; // Объявление первого двумерного массива

            Console.Write("\nпервая матрица: \n");
            createMas(mas); // Вызов метода создания для первого массива

            Console.Write("\nВведите параметры второй матрицы\n");
            paramMas();// Вызов метода ввода параметров второго массива
            int[,] masTwo = new int[longMas, heightMas]; // Объявление второго двумерного массива


            Console.Write("Вторая матрица: \n");
            createMas(masTwo); // Вызов метода создания для второго массива

            void control() // метод проверки корректности ввода
            {
                try
                {
                    tempInt = int.Parse(Console.ReadLine()); // Ввод данных                
                }
                catch
                {
                    Console.WriteLine("вы ввели неправильный параметр. Нажмите любую клавишу для выхода");
                    Console.ReadKey();
                    Environment.Exit(0);
                }                
            }

            void createMas(int[,] TempMas) // Метод создания массивов
            {
                for (int i = 0; i < longMas; i++) // Цикл заполнения столбцов
                {
                    TempMas[i, 0] = r.Next(1, 10); // Заполнения столбцов

                    for (int j = 0; j < heightMas; j++) // Цикл заполнения строк
                    {
                        TempMas[i, j] = r.Next(1, 10); // Заполнения строк
                        Console.Write(TempMas[i, j] + "| ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }


            if (mas.GetLength(1) != masTwo.GetLength(0))
            {
                Console.WriteLine("Данное действие невозможно. Количество столбцов первой матрицы не соответствует количеству строк второй матрицы.");
                Console.ReadKey();
                Environment.Exit(0);
            }            

            calculation(mas, masTwo);

            void calculation(int[,] tempMas, int[,] tempT) // Метод расчета
            {
                int[,] result = new int[tempMas.GetLength(0), tempT.GetLength(1)]; // Массив результатов число столбцов которого соответствует числу столбцов первого массива и число строк которого соответствует числу строк второго массива
                Console.WriteLine("Результат: ");

                for (int i = 0; i < tempMas.GetLength(0); i++) // Цикл заполнения результатов столбцов
                {
                    for (int j = 0; j < tempT.GetLength(1); j++) // Цикл заполнения результатов строк
                    {
                        for (int k = 0; k < tempT.GetLength(0); k++)
                        {
                            result[i, j] += tempMas[i, k] * tempT[k, j]; // Формула умножения массивов     
                        }

                        Console.Write(String.Format("{0,5}", result[i, j] + "| ")); // Вывод и форматирование результата 
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            Console.WriteLine("Нажмите любую кнопку для выхода.");
            Console.ReadKey();
        }
        
        
    }
}
