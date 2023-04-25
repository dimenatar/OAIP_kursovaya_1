using System.IO.MemoryMappedFiles;
using System.Text;

namespace Sorting_comparison
{
    public static class FileHelper
    {
        public static int[] GetNumbersArrayFromFile(string path, string delimiter = " ")
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File doesn't exists. Creating new empty file");
                File.Create(path);
                return new int[0];
            }
            int[] numbers;
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(path, FileMode.Open))
            {
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    string[] numberStrings = Encoding.UTF8.GetString(buffer).Split(delimiter);
                    numbers = new int[numberStrings.Length];
                    for (int i = 0; i < numberStrings.Length; i++)
                    {
                        if (!int.TryParse(numberStrings[i], out numbers[i]))
                        {
                            Console.WriteLine($"Found non integer value int file: {path}");
                        }
                    }
                }
            }
            return numbers;
        }
    }
}
