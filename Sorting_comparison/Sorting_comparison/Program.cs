namespace Sorting_comparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte menuChoice = 1;
            int[] array = new int[0];
            string delimiter = ", ";

            List<string> headers = new List<string>() { "Алгоритм", "Время сортировки", "Перестановки", "Сравнения" };

            ShowMenu(menuChoice, array, delimiter, headers);
        }

        private static void ShowMenu(byte menuChoice, int[] array, string delimiter, List<string> headers)
        {
            while (true)
            {
                Console.WriteLine("Меню");
                Console.WriteLine("1. Считать из файла массив");
                Console.WriteLine("2. Сформировать файл с рандомными значениями");
                Console.WriteLine("3. Отсортировать массив одним методом и вывести информацию");
                Console.WriteLine("4. Отсортировать массив всеми методами сортировок и вывести ифнормацию");
                Console.WriteLine("5. Выход");

                while (!byte.TryParse(Console.ReadLine(), out menuChoice) || menuChoice <= 0 || menuChoice >= 6)
                {
                    Console.WriteLine("Пожалуйста, введите цифру от 1 до 5");
                }

                switch (menuChoice)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите название файла");
                            string? fileName;

                            if ((fileName = Console.ReadLine()) == null)
                            {
                                Console.WriteLine("Неверное название файла");
                                break;
                            }

                            array = FileHelper.GetNumbersArrayFromFile(fileName, delimiter);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите количество элементов");
                            int amount;
                            while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                            {
                                Console.WriteLine("Пожалуйста, введите цифру от 1");
                            }
                            Console.WriteLine("Введите название файла");
                            string path;

                            while ((path = Console.ReadLine()) == null)
                            {
                                Console.WriteLine("Пожалуйста, введите коректное название файла");
                            }

                            array = FileHelper.CreateFileWithRandomElements(path, amount, delimiter);
                            break;
                        }
                    case 3:
                        {
                            PerformSingleSortingsSubMenu(array, headers);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"Размер массива: {array.Length}");
                            List<Analytics> analytics = new List<Analytics>
                            {
                                TestBubbleSort(array),
                                TestCombSort(array),
                                TestCocktailSort(array),
                                TestGnomeSort(array),
                                TestFlaggedBubbleSort(array),
                                TestStoneSort(array),
                                TestSpiderSort(array),
                                TestInsertionSort(array),
                                TestSelectionSort(array)
                            };
                            OutputHelper.OutputTableToConsole(headers, analytics);
                            break;
                        }
                    case 5:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }

            }
        }

        private static void PerformSingleSortingsSubMenu(int[] array, List<string> headers)
        {
            byte submenuSortingChoice = 1;

            Console.WriteLine("2.1 Пузырьком");
            Console.WriteLine("2.2 Коктельная");
            Console.WriteLine("2.3 Комбинированная");
            Console.WriteLine("2.4 Пузырьком с флагом");
            Console.WriteLine("2.5 Гномья");
            Console.WriteLine("2.6 Вставками");
            Console.WriteLine("2.7 Выбором");
            Console.WriteLine("2.8 Паучья");
            Console.WriteLine("2.9 Каменная");

            while (!byte.TryParse(Console.ReadLine(), out submenuSortingChoice) || submenuSortingChoice <= 0 || submenuSortingChoice >= 10)
            {
                Console.WriteLine("Пожалуйста, введите цифру от 1 до 9");
            }

            Console.WriteLine($"Количество элементов в массиве: {array.Length}");

            List<Analytics> analytics = new List<Analytics>();

            switch (submenuSortingChoice)
            {
                case 1:
                    {
                        analytics.Add(TestBubbleSort(array));
                        break;
                    }
                case 2:
                    {
                        analytics.Add(TestCocktailSort(array));
                        break;
                    }
                case 3:
                    {
                        analytics.Add(TestCombSort(array));
                        break;
                    }
                case 4:
                    {
                        analytics.Add(TestFlaggedBubbleSort(array));
                        break;
                    }
                case 5:
                    {
                        analytics.Add(TestGnomeSort(array));
                        break;
                    }
                case 6:
                    {
                        analytics.Add(TestInsertionSort(array));
                        break;
                    }
                case 7:
                    {
                        analytics.Add(TestSelectionSort(array));
                        break;
                    }
                case 8:
                    {
                        analytics.Add(TestSpiderSort(array));
                        break;
                    }
                case 9:
                    {
                        analytics.Add(TestStoneSort(array));
                        break;
                    }
            }
            OutputHelper.OutputTableToConsole(headers, analytics);
        }

        private static Analytics TestBubbleSort(int[] array)
        {
            int[] arrayCopy = (int[]) array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.BubbleSort(arrayCopy, out swaps, out comparings), "Сортировка пузырьком");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }

        private static Analytics TestCocktailSort(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.CocktailSort(arrayCopy, out swaps, out comparings), "Шейкерная сортировка");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }

        private static Analytics TestCombSort(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.CombSort(arrayCopy, out swaps, out comparings), "Сортировка расческой");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }

        private static Analytics TestFlaggedBubbleSort(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.FlaggedBubbleSort(arrayCopy, out swaps, out comparings), "Сортировка пузырьком с флагом");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }

        private static Analytics TestGnomeSort(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.GnomeSort(arrayCopy, out swaps, out comparings), "Гномья сортировка");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }

        private static Analytics TestInsertionSort(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.InsertionSort(arrayCopy, out swaps, out comparings), "Сортировка вставками");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }

        private static Analytics TestSelectionSort(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.SelectionSort(arrayCopy, out swaps, out comparings), "Сортировка выбором");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }

        private static Analytics TestSpiderSort(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.SpiderSort(arrayCopy, out swaps, out comparings), "Паучья сортировка");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }

        private static Analytics TestStoneSort(int[] array)
        {
            int[] arrayCopy = (int[])array.Clone();
            ulong swaps = 0, comparings = 0;
            var analytics = ResourceListener.GetAnalytics(() => Sortings.StoneSort(arrayCopy, out swaps, out comparings), "Каменная сортировка");
            analytics.Swaps = swaps;
            analytics.Comparings = comparings;
            return analytics;
        }
    }
}