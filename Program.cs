using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.Task_1();
            //p.Task_2();
            p.Task_4();

        }

        private void Task_1()
        {
            /*
             * Объявить одномерный (5 элементов) массив с именем A и 
             * двумерный массив (3 строки, 4 столбца) дробных чисел с 
             * именем B. Заполнить одномерный массив А числами, введенными 
             * с клавиатуры пользователем, а двумерный массив В случайными 
             * числами с помощью циклов. Вывести на экран значения массивов: 
             * массива А в одну строку, массива В — в виде матрицы. Найти в
             * данных массивах общий максимальный элемент, минимальный 
             * элемент, общую сумму всех элементов, общее произведение всех 
             * элементов, сумму четных элементов массива А, сумму нечетных 
             * столбцов массива В.
             * */
            Console.WriteLine("Задача 1.");
            int SummEvenOfArrayA = 0;
            int[] arrA = new int[5];
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.Write("Введите " + i + " элемент массива -> ");
                arrA[i] = Convert.ToInt32(Console.ReadLine());
                if ((arrA[i]&1) == 0)
                {
                    SummEvenOfArrayA += arrA[i];        // Сумма чётных элементов одномерного массива
                }
            }
            Console.WriteLine();
            foreach (int i in arrA)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            
            
            
            int rows = 3;
            int cols = 4;
            int[,] arrB = new int[rows, cols];
            int SummOddColumns = 0;
            Random rnd = new Random();
            for (int i = 0;i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arrB[i, j] = rnd.Next(1, 20);
                    if ((j&1) == 1)
                    {
                        SummOddColumns += arrB[i, j];      // Сумма нечётных стобцов (если номера стобцов соответствуют индексам массива, т.е. начинаются с 0)
                    }
                    Console.Write(arrB[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            
           
            int CountOfCommonElements = 0;
            int SummaOfCommonElements = 0;
            int MultOfCommonElements = 1;
                        
            Console.WriteLine("Общие элементы:");
            for(int i = 0; i < arrA.Length; i++)
            {
                
                for (int k = 0; k < rows; k++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        
                        if (arrA[i] == arrB[k, j])
                        {
                            SummaOfCommonElements+=arrA[i];     // Сумма общих элементов массивов
                            MultOfCommonElements*=arrA[i];      // Произведение общих элементов
                            CountOfCommonElements++;            // Подсчёт количество общих элементов
                            Console.Write(arrA[i] + " ");
                        }
                    }
                }
            }
            Console.WriteLine();
            int countIndex = 0;
            int[] arrOfCommonElements = new int[CountOfCommonElements];     // создание массива для общих элементов
            if (CountOfCommonElements > 0)
            {
                for (int i = 0; i < arrA.Length; i++)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            if (arrA[i] == arrB[k, j])
                            {
                                arrOfCommonElements[countIndex] = arrA[i];      // Заполнение массива общими элементами
                                countIndex++;
                            }
                        }
                    }
                }

                int CommonMaxElement = arrOfCommonElements[0];

                int CommonMinElement = arrOfCommonElements[0];

                for (int i = 0; i < arrOfCommonElements.Length; i++)
                {
                    if(CommonMaxElement < arrOfCommonElements[i])
                    {
                        CommonMaxElement = arrOfCommonElements[i];
                    }
                    if(CommonMinElement > arrOfCommonElements[i])
                    {
                        CommonMinElement = arrOfCommonElements[i];
                    }
                }
                Console.WriteLine("Общий максимальный элемент - " + CommonMaxElement);
                Console.WriteLine("Общий минимальный элемент - " + CommonMinElement);
            }
            else
            {
                Console.WriteLine("Общих элементов нет.");
            }
           
           
            
            Console.WriteLine("Cумма общих элементов - " + SummaOfCommonElements);
            Console.WriteLine("Произведение общих элементов - " + MultOfCommonElements);
            Console.WriteLine("Сумма чётных элементов одномерного массива - " + SummEvenOfArrayA);
            Console.WriteLine("Сумма нечётных стобцов двумерного массива - " + SummOddColumns);

        }

        private void Task_2()
        {
            /*
             Дан двумерный массив размерностью 5×5, 
             заполненный случайными числами из диапазона от –100 до 100.
             Определить сумму элементов массива, расположенных
             между минимальным и максимальным элементами.
            */
            Console.WriteLine("Задача 2.");
            int rows = 5;
            int cols = 5;
            int[,] arrB = new int[rows, cols];
            int min = arrB[0, 0];
            int max = arrB[0, 0];
            Random rnd = new Random();
            // определяем минимум и максимум
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arrB[i, j] = rnd.Next(-100, 101);
                    if(min > arrB[i, j])
                    {
                        min = arrB[i, j];
                    }
                    if(max < arrB[i, j])
                    {
                        max = arrB[i, j];
                    }
                    Console.Write(arrB[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int SummMinMax = 0;
            Console.WriteLine("Элементы, находящиеся между " + min + " и " + max);
            bool StopFlag = false;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arrB[i, j] == min || arrB[i, j] == max) // если текущий элемент равен минимальному или максимальному
                    {                                           // то начинаем выводит и суммировать эти элементы
                        bool first = true;
                        for(int k = i; k < rows; k++)
                        {
                            int l = 0;  // если cтрока следующая, то надо начинать с 0 индекса
                            if (first)  // если строка та же, где находится min или max, то надо начинать со следующего элемента
                            {
                                l = j+1;
                            }
                            for(; l < cols; l++)
                            {
                                first = false;
                                
                                if (arrB[k, l] == min || arrB[k, l] == max)
                                {
                                    StopFlag = true;
                                    break;
                                }
                                SummMinMax += arrB[k, l];
                                Console.Write(arrB[k, l] + "\t");
                                
                            }
                            if (StopFlag)
                            {
                                break;
                            }
                        }
                    }
                    if (StopFlag)
                    {
                        break;
                    }
                }
                
                if (StopFlag)
                {
                    Console.WriteLine();
                    break;
                }
            }
            Console.WriteLine("Сумма элементов, находящихся между " + min + " и " + max + " = " + SummMinMax);

        }

        private void Task_4()
        {
            /*
            Создайте приложение, которое производит операции над матрицами:
            ■ Умножение матрицы на число;
            ■ Сложение матриц;
            ■ Произведение матриц.
            */
            Console.WriteLine("Задача 4.");
            Random rnd = new Random();


//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Console.WriteLine("Умножение матрицы на число.");
            Console.Write("Введите множитель: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество строк матрицы -> ");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы -> ");
            int cols = Convert.ToInt32(Console.ReadLine());
            int[,] matrix1 = new int[rows, cols];
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix1[i, j] = rnd.Next(0, 6);
                    Console.Write(matrix1[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix1[i, j] *= number;
                    Console.Write(matrix1[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

 //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Console.WriteLine("Сложение матриц.");
            Console.Write("Введите количество строк матрицы -> ");
            rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы -> ");
            cols = Convert.ToInt32(Console.ReadLine());
            int[,] matrix2 = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix2[i, j] = rnd.Next(0, 6);
                }
            }
            int[,] matrix3 = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix3[i, j] = rnd.Next(0, 6);
                }
            }

            int[,] matrix4 = new int[rows, cols];
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0;j < cols; j++)
                {
                    matrix4[i, j] = matrix2[i, j] + matrix3[i, j];
                }
            } 

            // прорисовываем результаты
            for(int i = 0;i < rows; i++)
            {
                for( int j = 0; j < cols; j++)
                {
                    Console.Write(matrix2[i, j] + "\t");
                }
               
                if(i == rows/2)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.Write("\t");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix3[i, j] + "\t");
                }
                
                if (i == rows/2)
                {
                    Console.Write("=");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.Write("\t");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix4[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            Console.WriteLine("Умножение матриц.");
            Console.Write("Введите количество строк первой матрицы -> ");
            rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов первой матрицы -> ");
            cols = Convert.ToInt32(Console.ReadLine());
            int[,] matrix5 = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix5[i, j] = rnd.Next(0, 6);
                    Console.Write(matrix5[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.Write("Введите количество строк второй матрицы -> ");
            int rows2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов второй матрицы -> ");
            int cols2 = Convert.ToInt32(Console.ReadLine());
            int[,] matrix6 = new int[rows2, cols2];
            
            if (rows == cols2)
            {
                // заполняем случайными значениями вторую матрицу
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        matrix6[i, j] = rnd.Next(0, 6);
                        Console.Write(matrix6[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
               
                    int[,] matrix7 = new int[rows, cols2];
                    int l = 0;
                    for (int i = 0; i < rows; ++i)
                    {
                        // умножаем строку первой матрицы на стобцы второй матрицы
                        int g = 0;
                        for (int j = 0; j < cols2; ++j, ++g)
                        {
                            int summMult = 0;
                            for (int k = 0; k < cols; k++)
                            {
                                
                                summMult += matrix5[l, k] * matrix6[k, g];
                               
                            }
                            
                            matrix7[i, j] = summMult; 

                        }
                        l++;

                    }

                    for (int i = 0; i < rows; ++i)
                    {
                        for (int j = 0; j < cols2; ++j)
                        {
                            Console.Write(matrix7[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                
                
            }else if (cols == rows2)
            {
                // заполняем случайными значениями вторую матрицу
                for (int i = 0; i < rows2; i++)
                {
                    for (int j = 0; j < cols2; j++)
                    {
                        matrix6[i, j] = rnd.Next(0, 6);
                        Console.Write(matrix6[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                int[,] matrix7 = new int[rows, cols2];
                int l = 0;
                for (int i = 0; i < rows; ++i)
                {
                    // умножаем строку первой матрицы на стобцы второй матрицы
                    int g = 0;
                    for (int j = 0; j < cols2; ++j, ++g)
                    {
                        int summMult = 0;
                        for (int k = 0; k < cols; k++)
                        {

                            summMult += matrix5[l, k] * matrix6[k, g];

                        }

                        matrix7[i, j] = summMult;

                    }
                    l++;

                }
                 // вывод результата на экран
                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < cols2; ++j)
                    {
                        Console.Write(matrix7[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Эти матрицы нельзя перемножить.");
            }
        }

    }
}

