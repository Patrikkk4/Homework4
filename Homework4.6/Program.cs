using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Homework4._6
{
    class Program
    {

                                                                       //Данная программа складывает 2 случайно сгенерированные матрицы и показывает затраченное время на 1000 итераций цикла сложения.
        static void Main(string[] args)
        {
            Console.WriteLine($"{ "Данное приложение сгенерирует 2 матрицы с числами диапозоном от 0,01 до 1.\n",92}" +
                $"{"каждый последующий результат сложения двух матриц будет складываться со\n",90}" +
                $"{"следующей сгенерированной матрицей.\n",72}" + 
                $"{"Продолжение цикла 1000 итераций.\n", 70}" +
                $"{"Нажмите любую клавишу для продолжения.\n", 74}");

            Console.ReadKey();

            Stopwatch Time = new Stopwatch(); // Объявление экземпляра класса подсчета времени

            Time.Start(); // Начало отсчета времени выполнения программы

            float min = 0.01f; //  Минимальное число матрицы
            float max = 1f; // Максимальное число матрицы

            Random r = new Random(); // Генерирование случайных чисел для матриц

            void createMas(float[,] TempMas) // Метод создания массивов
            {
                for (int i = 0; i < 4; i++) // Цикл заполнения столбцов
                {
                    TempMas[i, 0] = (float)r.NextDouble() * (max - min) + min; // Заполнения столбцов

                    for (int j = 0; j < 4; j++) // Цикл заполнения строк
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

            Console.WriteLine("Вторая матрица: \n");
            createMas(masTwo); // Вызов метода для создания второго массива

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
                            tempMas[i, j] = tempMas[i, j] + tempT[i, j]; // Формула сложения массивов                           

                            
                            Console.Write(String.Format("{0,11}", tempMas[i, j] + "| ")); // Вывод и форматирование результата 
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
