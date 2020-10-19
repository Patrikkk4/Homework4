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
                $"{"Ввод производится цифрами.\n", 69}");

            int tempInt = 0; // перменная для проверки неверных значений
            int heightMas = 0; // Переменная ввода количества строк
            int longMas = 0; // Переменная ввода количества столбцов
            

            Console.Write("Введите высоту матрицы: ");
            control(heightMas); // Вызов метода корректности ввода для количества строк
            heightMas = tempInt; // Присваивание переменной количества строк введенного значения

            Console.Write("\nВведите ширину матрицы: ");
            control(longMas); // Вызов метода корректности ввода для количества столбцов
            longMas = tempInt; // Присваивание переменной количества столбцов введенного значения

            if (heightMas != longMas) // Условие проверки равности размеров матриц
            {
                Console.WriteLine("Длинна и ширина матриц не совпадают. Нажмите любую клавишу для выхода");
                Console.ReadKey();
                Environment.Exit(0);
            }

            void control (int varCheck) // метод проверки корректности ввода
            {
                if (!int.TryParse(Console.ReadLine(), out tempInt)) //Условие вывода ошибки некорректного ввода
                {
                    Console.WriteLine("вы ввели неправильный параметр. Нажмите любую клавишу для выхода");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            }

            Console.Write("\nКакую математическую операци вы желаете совершить (введите + или -): ");
            string option = Console.ReadLine(); // Ввод знака для выполнения действия

            
            if (option == "+" || option == "-") // Условие при корректно введенном знаке
            {
                Console.WriteLine("\nСоздаем матрицы");
                Console.WriteLine();
                
            }
            else // Условие при не корректно введенном знаке
            {
                Console.WriteLine("Вы ввели неправильный параметр. Нажмите любую клавишу для выхода");
                Console.ReadKey();
                Environment.Exit(0);
            }

            int[,] mas = new int[longMas, heightMas]; // Создание двумерного массива
            int[,] masTwo = new int[longMas, heightMas]; // Создание временного двумерного массива

            Random r = new Random(); // Генерирование случайных чисел для матриц
           
            Console.WriteLine("Первая матрица: ");
            createMas(mas); // Вызов метода для создания первого массива
            Console.WriteLine("Вторая матрица: ");
            createMas(masTwo); // Вызов метода для создания второго массива
            calculation(mas, masTwo); // Вызов метода расчета


            void createMas(int[,] TempMas) // Метод создания массивов
            {
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

            void calculation(int[,] tempMas, int[,] tempT) // Метод расчета
            {
                Console.WriteLine("Результат: ");
                int[,] result = new int[longMas, heightMas];

                for (int i = 0; i < tempMas.GetLength(0); i++) // Цикл заполнения результатов столбцов
                {
                    for (int j = 0; j < tempT.GetLength(1); j++) // Цикл заполнения результатов строк
                    {

                        if (option == "+") // Условие для сложения
                        {
                            result[i, j] = tempMas[i, j] + tempT[i, j]; // Формула сложения массивов                           
                        }

                        else if (option == "-") // Условие для вычитания
                        {
                            result[i, j] = tempMas[i, j] - tempT[i, j]; // Формула вычитания массивов                           
                        }
                        Console.Write(String.Format("{0,4}", result[i, j] + "| ")); // Вывод и форматирование результата 
                        
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
