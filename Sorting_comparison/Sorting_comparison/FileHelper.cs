using System.IO.MemoryMappedFiles;
using System.Text;

namespace Sorting_comparison
{
    public static class FileHelper
    {
        public static int[] GetNumbersArrayFromFile(string path, string delimiter = " ")
        {
            path = CheckFileFormat(path);

            if (!File.Exists(path))
            {
                Console.WriteLine("File doesn't exists");
                return Array.Empty<int>();
            }

            List<int> numbers = new List<int>();
            //int[] numbers;
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(path, FileMode.Open))
            {
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    var line = Encoding.UTF8.GetString(buffer);
                    string[] numberStrings = Encoding.UTF8.GetString(buffer).Split(delimiter);
                    int number;
                    //numbers = new int[numberStrings.Length];
                    for (int i = 0; i < numberStrings.Length; i++)
                    {
                        if (!int.TryParse(numberStrings[i], out number))
                        {
                            Console.WriteLine($"Found non integer value <{numberStrings[i]}> in file: {path}");
                        }
                        else
                        {
                            numbers.Add(number);
                        }
                    }
                }
            }
            return numbers.ToArray();
        }

        public static int[] CreateFileWithRandomElements(string path, int amount, string delimiter)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Количество элементов должно быть больше 0");
                return Array.Empty<int>();
            }

            path = CheckFileFormat(path);

            int[] numbers = GetRandomInt32(amount);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                var writer = new StreamWriter(stream, new UTF8Encoding(false, true));

                for (int i = 0; i < amount; i++)
                {
                    if (i != amount - 1)
                    {
                        writer.Write(numbers[i] + delimiter);
                    }
                    else
                    {
                        writer.Write(numbers[i]);
                    }
                }
                writer.Flush();
            }
            return numbers;
        }

        public static int[] GetRandomInt32(int amount)
        {
            Random random = new Random();
            int[] numbers = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                numbers[i] = random.Next(int.MinValue, int.MaxValue);
            }
            return numbers;
        }

        private static string CheckFileFormat(string path)
        {
            if (path.Length >= 4)
            {
                if (string.Join("", path.TakeLast(4)).Equals(".txt"))
                {
                    return path;
                }
            }
            return path + ".txt";
        }
    }
}
