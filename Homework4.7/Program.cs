using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace Homework4._7
{
    class Program
    {
                                                                     //Данная программа перемножает 2 случайно сгенерированные матрицы и показывает затраченное время на 1000 итераций цикла умножения.
        static void Main(string[] args)
        {
            Console.WriteLine($"{ "Данное приложение сгенерирует 2 матрицы с числами диапозоном от 0,01 до 1.\n",96}" +
                $"{"каждый последующий результат умножения двух матриц будет умножаться со\n",90}" +
                $"{"следующей сгенерированной матрицей.\n",72}" +
                $"{"Продолжение цикла 1000 итераций.\n",70}" +
                $"{"Нажмите любую клавишу для продолжения.\n",74}");

            Console.ReadKey();

            Stopwatch Time = new Stopwatch(); // Объявление экземпляра класса подсчета времени

            Time.Start(); // Начало отсчета времени выполнения программы

            float min = 0.01f; //  Минимальное число матрицы
            float max = 1f; // Максимальное число матрицы

            Random r = new Random(); // Генерирование случайных чисел для матриц

            void createMas(float[,] TempMas) // Метод создания массивов
            {
                for (int i = 0; i < TempMas.GetLength(0); i++) // Цикл заполнения столбцов
                {
                    TempMas[i, 0] = (float)r.NextDouble() * (max - min) + min; // Заполнения столбцов

                    for (int j = 0; j < TempMas.GetLength(0); j++) // Цикл заполнения строк
                    {
                        TempMas[i, j] = (float)r.NextDouble() * (max - min) + min; // Заполнения строк
                        Console.Write(TempMas[i, j] + "| "); // Вывод массива
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            float[,] mas = new float[4, 4]; // Создание двумерного массива
            float[,] masTwo = new float[4, 4]; // Создание временного двумерного массива        
            

            Console.WriteLine("Первая матрица: \n");
            createMas(mas); // Вызов метода для создания первого массива

            for (int z = 0; z < 1000; z++)
            {
                Console.WriteLine("следующая матрица: \n");
                createMas(masTwo); // Вызов метода для создания второго массива
                calculation(mas, masTwo); // Вызов метода расчета

                void calculation(float[,] tempMas, float[,] tempT) // Метод расчета
                {
                    Console.WriteLine("результат: \n");
                    for (int i = 0; i < tempMas.GetLength(0); i++) // Цикл заполнения результатов столбцов
                    {
                        for (int j = 0; j < tempT.GetLength(1); j++) // Цикл заполнения результатов строк
                        {
                            for (int k = 0; k < tempT.GetLength(0); k++)
                            {
                                tempMas[i, j] += tempMas[i, k] * tempT[k, j]; // Формула умножения массивов     
                            }

                            Console.Write(String.Format("{0,8}", tempMas[i, j] + "| ")); // Вывод и форматирование результата 
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }

            Time.Stop(); // Конец отсчета времени выполнения программы
            Console.WriteLine("Время затраченное на выполнение операций: " + Time.Elapsed.TotalSeconds + "\n"); // Вывод затраченного времени
            Console.WriteLine("Нажмите любую кнопку для выхода.");
            Console.ReadKey();
        }
    }
}
