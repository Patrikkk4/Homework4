using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace Homework4._8
{
    class Program
    {
                                                 // Данная программа создает матрицы при помощи System.Numerics.Matrix4x4, складывает их и выводит затраченное время на выполнение 1000 итераций цикла сложения.
        static void Main(string[] args)
        {
            Console.WriteLine($"{ "Данное приложение сгенерирует 2 матрицы с числами диапозоном от 0,01 до 1.\n",92}" +
                $"{"каждый последующий результат сложения двух матриц будет складываться со\n",90}" +
                $"{"следующей сгенерированной матрицей.\n",72}" +
                $"{"Продолжение цикла 1000 итераций.\n",70}" +
                $"{"Нажмите любую клавишу для продолжения.\n",74}");

            Console.ReadKey();

            Stopwatch Time = new Stopwatch(); // Объявление экземпляра класса подсчета времени

            Time.Start(); // Начало отсчета времени выполнения программы

            float min = 0.01f; //  Минимальное число матрицы
            float max = 1f; // Максимальное число матрицы

            Random r = new Random(); // Генерирование случайных чисел для матриц  
            float randomNumber = (float)r.NextDouble() * (max - min) + min;
            float randomNumberTwo = (float)r.NextDouble() * (max - min) + min;

            void output(Matrix4x4 temp) // метод вывода матрицы в консоль
            {
                Console.Write(temp.M11 + "| " +  temp.M12 + "| " + temp.M13 + "| " + temp.M14 + "| \n" +
                temp.M21 + "| " + temp.M22 + "| " + temp.M23 + "| " + temp.M24 + "| \n" + 
                temp.M31 + "| " + temp.M32 + "| " + temp.M33 + "| " + temp.M34 + "| \n" + 
                temp.M41 + "| " + temp.M42 + "| " + temp.M43 + "| " + temp.M44 + "| \n");
            }

            // создание первой матрицы 
            Matrix4x4 mas = new Matrix4x4(randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber, randomNumber);
            // Создание второй матрицы
            Matrix4x4 masTwo = new Matrix4x4();

            Console.WriteLine("\nПервая матрица\n");

            output(mas); // Вызов метода вывода матрицы в консоль

            void createMatrix() // Метод создания последующих матриц для сложения
            {
                // Создание последующих матриц для сложения
                masTwo = new Matrix4x4(randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo, randomNumberTwo);
            }

            for (int i = 0; i < 1000; i++) // Цикл сложения матриц
            {

                createMatrix(); // Вызов метода создания матрицы

                Console.WriteLine("\nСледующая матрица\n");

                output(masTwo); // Вызов метода вывода матрицы в консоль

                mas = Matrix4x4.Add(mas, masTwo); // Сложение матриц

                Console.WriteLine("\nрезультат\n");

                output(mas); // Вызов метода вывода результата сложения в консоль
            }

            Time.Stop(); // Конец отсчета времени выполнения программы
            Console.WriteLine("Время затраченное на выполнение операций: " + Time.Elapsed.TotalSeconds + "\n"); // Вывод затраченного времени
            Console.WriteLine("Нажмите любую кнопку для выхода.");
            Console.ReadKey();
        }
    }
}
