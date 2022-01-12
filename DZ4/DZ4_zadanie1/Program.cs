using System;

namespace DZ4_zadanie1
{
    class Program
    {
        static void Main()
        {
            TestSolution1();
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
            } while (negativeSum !< (Double.MinValue + 1000) && (MultiplyMinMax > (Double.MaxValue - 1000) && MultiplyMinMax < (Double.MinValue + 1000)));
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
    }
}
