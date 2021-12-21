using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;

namespace GaussCSharp
{
    class Program
    {

        static void Main(string[] args)
        {
            int SortIndex = 0;
            int row; //Розмір матриці
            Console.Write("Введiть розмiр: ");
            row = int.Parse(Console.ReadLine());

            double[,] Matrix = new double[row, row];
            double[] RightPart = new double[row];
            double[] Answer = new double[row];

           //Ввод

            Console.WriteLine("Введiть коефiцiєнти и свободнi членi: ");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Console.Write($"A[{i + 1}][{j + 1}]= ");
                    Matrix[i, j] = double.Parse(Console.ReadLine());
                    
                }
                Console.Write($"B[{i + 1}]= ");
                RightPart[i] = double.Parse(Console.ReadLine());
                
            }

            //Вивод початкового виду 
            Console.Clear();
            Console.WriteLine("Початкова система рiвнянь");
            Console.WriteLine("────────────────────────────────────────────────────────");
            Console.WriteLine();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (Matrix[i, j] >= 0 && j != 0)
                        Console.Write("{0, -1} {1, -4}", "+", $"{Matrix[i, j]}x");
                    else if (Matrix[i, j] < 0)
                        Console.Write("{0, -1} {1, -4}", "-", $"{Matrix[i, j] * (-1)}x");
                    else if (Matrix[i, j] >= 0 && j == 0)
                        Console.Write("{0, -1} {1, -4}", " ", $"{Matrix[i, j]}x");
                }
                Console.Write("{0, -1} {1, 3}", "=", $"{RightPart[i]}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("────────────────────────────────────────────────────────");

            //Кінець виводу 

            //Пошук максимального елементу 1 стопчику(його значення та індекс)

            double MaxElement = Matrix[SortIndex, SortIndex];
            int MaxElementIndex = SortIndex;
            for (int i = SortIndex + 1; i < row; i++)
            {
                if (Matrix[i, SortIndex] > MaxElement)
                {
                    MaxElement = Matrix[i, SortIndex];
                    MaxElementIndex = i;
                }
            }

            //Тепер переносимо рядок з максимальним елементом 1 стопчика на гору
            
            if (MaxElementIndex > SortIndex)// Якщо це не 1 елемент
            {
                double Temp;

                Temp = RightPart[MaxElementIndex];
                RightPart[MaxElementIndex] = RightPart[SortIndex];
                RightPart[SortIndex] = Temp;

                for (int i = 0; i < row; i++)
                {
                    Temp = Matrix[MaxElementIndex, i];
                    Matrix[MaxElementIndex, i] = Matrix[SortIndex, i];
                    Matrix[SortIndex, i] = Temp;
                }
                Console.WriteLine($"Вибираємо рядок з максимальним коефiцiєнтом, a саме з a[0,{MaxElementIndex}]");
                Console.WriteLine($"Та мiняєм його з першим рядком.");
                Console.WriteLine("────────────────────────────────────────────────────────");
                Console.WriteLine();

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        if (Matrix[i, j] >= 0 && j != 0)
                            Console.Write("{0, -1} {1, -4}", "+", $"{Matrix[i, j]}x");
                        else if (Matrix[i, j] < 0)
                            Console.Write("{0, -1} {1, -4}", "-", $"{Matrix[i, j] * (-1)}x");
                        else if (Matrix[i, j] >= 0 && j == 0)
                            Console.Write("{0, -1} {1, -4}", " ", $"{Matrix[i, j]}x");
                    }
                    Console.Write("{0, -1} {1, 3}", "=", $"{RightPart[i]}");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("────────────────────────────────────────────────────────");

            }

            for (int i = 0; i < row - 1; i++)
            {

                MaxElement = Matrix[i, i];
                MaxElementIndex = i;
                for (int n = i + 1; n < row; n++)
                {
                    if (Matrix[n, i] > MaxElement)
                    {
                        MaxElement = Matrix[n, i];
                        MaxElementIndex = n;
                    }

                    for (int j = i + 1; j < row; j++)
                    {
                        if (Matrix[i, i] != 0) //якщо головний елемент не 0, то рахуємо
                        {
                            double MultElement = Matrix[j, i] / Matrix[i, i];
                            double[,] Matrixx = new double[row, row];
                            Matrixx[j, i] = Matrix[j, i];
                            for (int k = i; k < row; k++)
                            {
                                double[,] Matrix2 = new double[row, row];
                                Matrix2[j, k] = Matrix[j, k];
                                Matrix[j, k] -= Matrix[i, k] * MultElement;
                                RightPart[j] -= RightPart[i] * MultElement;
                                Console.WriteLine($"step- Matrix[{j}, {k}] = {Math.Round(Matrix2[j, k]),3} - {Math.Round(Matrix[i, k]),3} * {Math.Round(Matrixx[j, i]),3} / {Math.Round(Matrix[i, i]),3} ");
                                Console.WriteLine("────────────────────────────────────────────────────────");
                                Console.WriteLine();

                for (int l = 0; l < row; l++)
                {
                    for (int m = 0; m < row; m++)
                    {
                        if (Matrix[l, m] >= 0 && m != 0)
                            Console.Write("{0, -1} {1, -4}", "+", $"{Math.Round(Matrix[l, m]),3}x");
                        else if (Matrix[l, m] < 0)
                            Console.Write("{0, -1} {1, -4}", "-", $"{Math.Round(Matrix[l, m] * (-1)),3}x");
                        else if (Matrix[l, m] >= 0 && m == 0)
                            Console.Write("{0, -1} {1, -4}", " ", $"{Math.Round(Matrix[l, m]),3}x");
                    }
                    Console.Write("{0, -1} {1, 3}", "=", $"{Math.Round(RightPart[l]),3}");
                    Console.WriteLine();
                }
                Console.WriteLine("────────────────────────────────────────────────────────");
            }
                            }
                            
                            
                        }
                        
                        //для нульового головного елемента пропускаємо цей крок
                        
                    }
                    
                }
                
            
            Console.WriteLine("Кiнцева система рiвнянь");
            Console.WriteLine("────────────────────────────────────────────────────────");
            Console.WriteLine();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (Matrix[i, j] >= 0 && j != 0)
                        Console.Write("{0, -1} {1, -4}", "+", $"{Math.Round(Matrix[i, j]),4}x");
                    else if (Matrix[i, j] < 0)
                        Console.Write("{0, -1} {1, -4}", "-", $"{Math.Round(Matrix[i, j] * (-1)),4}x");
                    else if (Matrix[i, j] >= 0 && j == 0)
                        Console.Write("{0, -1} {1, -4}", " ", $"{Math.Round(Matrix[i, j]),4}x");
                }
                Console.Write("{0, -1} {1, 3}", "=", $"{Math.Round(RightPart[i]),4}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("────────────────────────────────────────────────────────");

            string AnswerStr = "";
            for (int i = (int)(row - 1); i >= 0; i--)
            {
                Answer[i] = RightPart[i];

                for (int j = (int)(row - 1); j > i; j--)
                    Answer[i] -= Matrix[i, j] * Answer[j];

                if (Matrix[i, i] == 0)
                {
                    if (RightPart[i] == 0)
                    {
                        AnswerStr = "1";
                        Console.WriteLine("Ріщень нескінчено багато"); //множество решений
                    }
                    else
                    {
                        AnswerStr = "1";
                        Console.WriteLine("Немає рiшень"); //нет решения
                    }
                }
                    Answer[i] /= Matrix[i, i];

                
            }


            if (AnswerStr != "1")
            {
                Console.WriteLine("Корнi системи: ");
                Console.WriteLine();

                for (int i = 0; i < row; i++)
                {
                    Console.WriteLine($"x[{i}]= {Math.Round(Answer[i], 3)}");
                }
            }
            Console.WriteLine();
            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
