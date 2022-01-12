using System;

namespace DZ4_zadanie2
{
    class Program
    {
        static void Main()
        {
            TestSolution2();
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
