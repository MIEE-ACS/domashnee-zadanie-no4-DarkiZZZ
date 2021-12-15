using System;
using System.Linq;

// Variant 21 Sokolov UTS-21

namespace Solution
{
    class Solution
    {
        static void Main()
        {
            TestSolution1();
            TestSolution2();
        }

        public static void TestSolution1()
        {
            int size;
            double MultiplyMinMax = 1;
            Console.Write("Введите размер одномерного массива: ");
            string str = Console.ReadLine();
            while (!int.TryParse(str, out size) || int.Parse(str) < 1)
            {
                Console.WriteLine("Ошибка ввода! Введите положительное целое число a");
                Main();
            }
            double negativeSum = 0;
            int maxIndex = 0, minIndex = 0;
            Random rand = new Random(DateTime.Now.Millisecond);
            double[] myArray = new double[size];
            double max = myArray[0], min = myArray[0];
            do
            {

                for (int i = 0; i < size; i++)
                {
                    int multiplier = rand.Next(int.MinValue / 100000, int.MaxValue / 100000);
                    myArray[i] = rand.NextDouble() * multiplier;
                    if (myArray[i] < 0)
                    {
                        negativeSum = negativeSum + myArray[i];
                    }

                }
                //Находим индексы минимального и максимального элементов
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] >= max) { max = myArray[i]; maxIndex = i; }
                    if (myArray[i] <= min) { min = myArray[i]; minIndex = i; }
                }
                int kol = 0;
                foreach (var item in myArray)
                {
                    Console.WriteLine("{0}      Индекс: {1}", item.ToString(), kol);
                    kol++;
                }
                Console.WriteLine("\nmax это {0} с индексом {1} и min это {2} с индексом {3}", max, maxIndex, min, minIndex);

                // произведение
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (minIndex < maxIndex)
                    {
                        if (i > minIndex && i < maxIndex)
                        {
                            MultiplyMinMax = MultiplyMinMax * myArray[i];
                        }
                    }
                    else if (maxIndex < minIndex)
                    {
                        if (i < minIndex && i > maxIndex)
                        {
                            MultiplyMinMax = MultiplyMinMax * myArray[i];
                        }
                    }
                }
            } while (negativeSum! < (Double.MinValue + 1000) && (MultiplyMinMax > (Double.MaxValue - 1000) && MultiplyMinMax < (Double.MinValue + 1000)));
            Console.WriteLine("\n===========================");
            Console.WriteLine("Сумма отрицательных элементов массива: ");
            Console.Write(negativeSum + "\n");
            Console.WriteLine("===========================");
            Console.WriteLine("Произведение элементов массива, расположенных между максимальным и минимальным элементами: ");
            Console.Write(MultiplyMinMax);
            Console.WriteLine("\n===========================");

            //Сортровка эл-тов массива по возрастанию:

            Array.Sort(myArray);
            Console.WriteLine("Отсортированный массив:\n");
            for (int i = 0; i < myArray.Length; i++) // вывод отсортированного массива                 
                Console.WriteLine(" " + myArray[i]);
            Console.ReadKey();

        }

        public static void TestSolution2()
        {
            int rows, columns;
            Console.Write("Введите количество строк:");
            String rowsString = Console.ReadLine();
            while (!int.TryParse(rowsString, out rows) || int.Parse(rowsString) < 1)
            {
                Console.WriteLine("Ошибка ввода! Введите положительные целые значения строк и столбцов!");
                Main();
            }
            Console.Write("Введите количество столбцов:");
            String columnsString = Console.ReadLine();
            while (!int.TryParse(columnsString, out columns) || int.Parse(columnsString) < 1)
            {
                Console.WriteLine("Ошибка ввода! Введите положительные целые значения строк и столбцов!");
                Main();
            }
            int[,] nums = new int[rows, columns];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    nums[i, j] = random.Next(100);
                    Console.Write("{0,4}", nums[i, j] + " ");
                }
                Console.WriteLine();
            }
            // Перебираем каждый элемент матрицы и если он равен 0, тогда инкрементируем локальную переменную amountOfElements и 
            // выводим потом на экран в каждой строке. Если строка не содержит нулевые элементы матрицы, инкрементируем 
            // локальную переменную amountOfStrings
            int amountOfElements = 0;
            int amountOfStrings = 0;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (nums[i, j] == 0)
                    {
                        ++amountOfElements;
                    }
                }
                Console.WriteLine("Строка {0} содержит {1} нулевых элементов", (i + 1), amountOfElements);
                if (amountOfElements == 0)
                {
                    ++amountOfStrings;
                }
                else
                {
                    amountOfElements = 0;
                }
            }

            // Выводим на экран локальную переменную amountOfStrings
            Console.WriteLine("Количество строк не содержащих нулевые элементы: " + amountOfStrings);
            Console.WriteLine();

            //Находим максимальное значение в матрице
            int maxElement = 0;
            int determineElement = 0;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if (nums[i, j] == maxElement)
                    {
                        ++determineElement;
                    }

                    if (nums[i, j] > maxElement)
                    {
                        maxElement = nums[i, j];
                        determineElement = 1;
                    }

                }
            }
            while (determineElement < 2)
            {
                if (determineElement <= 1)
                {
                    Console.WriteLine("Максимальное значение: {0} не повторяется в матрице, поэтому ищем новое максимальное значение, которое встречается два или более раз", maxElement);
                    int maxElemPrediduschiy = maxElement;
                    maxElement = 0;
                    determineElement = 0;
                    for (int i = 0; i < rows; ++i)
                    {
                        for (int j = 0; j < columns; ++j)
                        {
                            if ((nums[i, j] == maxElement) && (nums[i, j] < maxElemPrediduschiy))
                            {
                                ++determineElement;
                            }

                            if ((nums[i, j] > maxElement) && (nums[i, j] < maxElemPrediduschiy))
                            {
                                maxElement = nums[i, j];
                                determineElement = 1;
                            }

                        }
                    }
                }
            }

            // Находим максимальное 
            Console.WriteLine("Максимальный элемент: {0}, встречается {1} раз(а)", maxElement, determineElement);
            Console.ReadKey();
        }
    }
}
