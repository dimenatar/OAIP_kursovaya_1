using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_comparison
{
    public static class Sortings
    {
        public static void BubbleSort(int[] arr)
        {
            int length = arr.Length;
            int temp;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void CocktailSort(int[] arr)
        {
            bool swapped;
            int temp;
            do
            {
                swapped = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
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
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
            } 
            while (swapped);
        }

        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            int temp, minIndex;
            for (int i = 0; i < n - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
        }

        public static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            int key, j;
            for (int i = 1; i < n; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void GnomeSort(int[] arr)
        {
            int n = arr.Length;
            int i = 0;
            int temp;
            while (i < n)
            {
                if (i == 0 || arr[i] >= arr[i - 1])
                {
                    i++;
                }
                else
                {
                    temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                    i--;
                }
            }
        }

        public static void SpiderSort(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            bool swapped = true;
            int temp;
            while (left < right && swapped)
            {
                swapped = false;
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
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

        public static void FlaggedBubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped = true;
            int temp;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                n--;
            }
        }

        public static void StoneSort(int[] arr)
        {
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
                    if (arr[i] > arr[i + 1])
                    {
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
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
                start = start + 1;
            }
        }

        public static void CombSort(int[] arr)
        {
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
                    if (arr[i] > arr[i + gap])
                    {
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
