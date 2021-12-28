using System;

namespace GaussCSharp
{
    class Program
    {
        public static void Output(int row, double[,] Matrix, double[] RightPart)
        {
            Console.WriteLine("────────────────────────────────────────────────────────");
            Console.WriteLine();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (Matrix[i, j] >= 0 && j != 0)
                        Console.Write("{0, -1} {1, -4}", "+", $"{Math.Round(Matrix[i, j]),3}x");
                    else if (Matrix[i, j] < 0)
                        Console.Write("{0, -1} {1, -4}", "-", $"{Math.Round(Matrix[i, j] * (-1)),3}x");
                    else if (Matrix[i, j] >= 0 && j == 0)
                        Console.Write("{0, -1} {1, -4}", " ", $"{Math.Round(Matrix[i, j]),3}x");
                }
                Console.Write("{0, -1} {1, 3}", "=", $"{Math.Round(RightPart[i]),3}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("────────────────────────────────────────────────────────");
        }
        public static void Input(int row, double[,] Matrix, double[] RightPart)
        {
            Console.WriteLine("Введiть коефiцiєнти и вiльнi члени: ");

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
        }


        public static void Sort(int row, double[,] Matrix, double[] RightPart, int SortIndex, double MaxElement, int MaxElementIndex)
        {

            //Пошук максимального елементу 1 стопчику(його значення та індекс)


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
                Output(row, Matrix, RightPart);
            }

        }
        public static void Answe(int row, double[,] Matrix, double[] RightPart, double[] Answer)
        {
            Console.WriteLine("Кiнцева система рiвнянь");
            Output(row, Matrix, RightPart);

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
                        Console.WriteLine("Рішень нескінчено багато"); 
                    }
                    else
                    {
                        AnswerStr = "1";
                        Console.WriteLine("Немає рiшень"); 
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
        }
        public static void Algorithm(int row, double[,] Matrix, double[] RightPart, double MaxElement, int MaxElementIndex)
        {
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
                            
                            for (int k = i; k < row; k++)
                            {
                                Matrixx[j, i] = Matrix[j, i];
                                double[,] Matrix2 = new double[row, row];
                                Matrix2[j, k] = Matrix[j, k];
                                Matrix[j, k] -= Matrix[i, k] * MultElement;
                                Console.WriteLine($"Step - Matrix[{j}, {k}] = MyNumber - Element[{j-1},{k}] * Element[{j}, {i}] / Element[{i}, {i}] ");
                                Output(row, Matrix, RightPart);
                            }
                            RightPart[j] -= RightPart[i] * MultElement;                       
                        }
                    }
                   
                }                       
            }
        }

        static void Main(string[] args)
        {
            int SortIndex = 0;
            int row;

            Console.Write("Введiть розмiр: ");
            row = int.Parse(Console.ReadLine());

            double[,] Matrix = new double[row, row];
            double[] RightPart = new double[row];
            double[] Answer = new double[row];

            Input(row, Matrix, RightPart);

            Console.Clear();
            Console.WriteLine("Початкова система рiвнянь");

            Output(row, Matrix, RightPart);

            double MaxElement = Matrix[SortIndex, SortIndex];
            int MaxElementIndex = SortIndex;

            Sort(row, Matrix, RightPart, SortIndex, MaxElement, MaxElementIndex);


            Algorithm(row, Matrix, RightPart, MaxElement, MaxElementIndex);



            Answe(row, Matrix, RightPart, Answer);
            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
