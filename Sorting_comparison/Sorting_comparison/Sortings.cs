namespace Sorting_comparison
{
    public static class Sortings
    {
        public static void BubbleSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = 0;
            comparings = 0;
            int length = arr.Length;
            int temp;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    comparings++;
                    if (arr[j] > arr[j + 1])
                    {
                        swaps++;
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void CocktailSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = comparings = 0;
            bool swapped;
            int temp;
            do
            {
                swapped = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    comparings++;
                    if (arr[i] > arr[i + 1])
                    {
                        swaps++;
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                swapped = false;
                for (int i = arr.Length - 2; i >= 0; i--)
                {
                    comparings++;
                    if (arr[i] > arr[i + 1])
                    {
                        swaps++;
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
            } 
            while (swapped);
        }

        public static void SelectionSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = comparings = 0;
            int n = arr.Length;
            int temp, minIndex;
            for (int i = 0; i < n - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    comparings++;
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                comparings++;
                if (minIndex != i)
                {
                    swaps++;
                    temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
        }

        public static void InsertionSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = comparings = 0;
            int n = arr.Length;
            int key, j;
            for (int i = 1; i < n; i++)
            {
                key = arr[i];
                j = i - 1;
                comparings++;
                while (j >= 0 && arr[j] > key)
                {
                    swaps++;
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void GnomeSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = comparings = 0;
            int n = arr.Length;
            int i = 0;
            int temp;
            while (i < n)
            {
                comparings++;
                if (i == 0 || arr[i] >= arr[i - 1])
                {
                    i++;
                }
                else
                {
                    swaps++;
                    temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                    i--;
                }
            }
        }

        public static void SpiderSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = comparings = 0;
            int left = 0;
            int right = arr.Length - 1;
            bool swapped = true;
            int temp;
            while (left < right && swapped)
            {
                swapped = false;
                for (int i = left; i < right; i++)
                {
                    comparings++;
                    if (arr[i] > arr[i + 1])
                    {
                        swaps++;
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    comparings++;
                    if (arr[i] < arr[i - 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                        swapped = true;
                    }
                }
                left++;
            }
        }

        public static void FlaggedBubbleSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = comparings = 0;
            int n = arr.Length;
            bool swapped = true;
            int temp;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    comparings++;
                    if (arr[i] > arr[i + 1])
                    {
                        swaps++;
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                n--;
            }
        }

        public static void StoneSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = comparings = 0;
            int n = arr.Length;
            bool swapped = true;
            int start = 0;
            int end = n - 1;
            int temp;
            while (swapped)
            {
                swapped = false;
                for (int i = start; i < end; ++i)
                {
                    comparings++;
                    if (arr[i] > arr[i + 1])
                    {
                        swaps++;
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }

                swapped = false;
                end = end - 1;

                for (int i = end - 1; i >= start; --i)
                {
                    comparings++;
                    if (arr[i] > arr[i + 1])
                    {
                        swaps++;
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                start = start + 1;
            }
        }

        public static void CombSort(int[] arr, out int swaps, out int comparings)
        {
            swaps = comparings = 0;
            int n = arr.Length;
            int gap = n;
            bool swapped = true;
            int temp;
            while (gap > 1 || swapped == true)
            {
                gap = (gap * 10) / 13;

                if (gap < 1)
                {
                    gap = 1;
                }

                swapped = false;
                for (int i = 0; i < n - gap; ++i)
                {
                    comparings++;
                    if (arr[i] > arr[i + gap])
                    {
                        swaps++;
                        temp = arr[i];
                        arr[i] = arr[i + gap];
                        arr[i + gap] = temp;
                        swapped = true;
                    }
                }
            }
        }
    }
}
